using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;
using WarehouseManagementSystem.Shared.PublicModels;

namespace WarehouseManagementSystem.Implementation.Services
{
    public sealed class WHZoneService : ServiceBase, IWHZoneService
    {
        public WHZoneService(WHManagmentSystemContext context) : base(context) { }

        public async Task CreateZone(Whzones zone)
        {
            DbContext.Whzones.Add(zone);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Whzones[]> GetWhZones(int whId)
        {
            var zones = await DbContext.Whzones.Where(z => z.Whid == whId).ToArrayAsync();
            return zones;
        }

        public async Task<ZoneInfo> GetZoneById(int zoneId)
        {
            var zone = await DbContext.Whzones.Include(z => z.Whlockers).FirstOrDefaultAsync(z => z.Id == zoneId);
            if (zone == null) throw new Exception("No entity found");
            var isBooked = await DbContext.StatusStrings.AnyAsync(s => s.Key == zone.Id && s.Object == nameof(Whzones) && s.Value == "Booked");
            var isEmpty = !zone.Whlockers.Any();
            return new ZoneInfo
            {
                Zone = zone,
                IsBooked = isBooked,
                IsEmpty = isEmpty
            };
        }

        public async Task RemoveZone(int zoneId)
        {
            var zone = await DbContext.Whzones.Include(z => z.Whlockers).ThenInclude(l => l.Whcells).FirstOrDefaultAsync(i => i.Id == zoneId);

            if (zone == null)
            {
                throw new Exception("No entity found");
            }

            DbContext.RemoveRange(zone.Whlockers.SelectMany(l => l.Whcells));
            DbContext.RemoveRange(zone.Whlockers);
            DbContext.Remove(zone);
            await DbContext.SaveChangesAsync();
        }

        public async Task BookZone(int zoneId, int amount)
        {
            var zone = await DbContext.Whzones.Include(z => z.Whlockers).ThenInclude(l => l.Whcells).FirstOrDefaultAsync(i => i.Id == zoneId);

            if (zone == null)
            {
                throw new Exception("No entity found");
            }

            if (zone.Whlockers.SelectMany(l => l.Whcells).Where(c => c.ItemId == null).Count() < amount) throw new Exception("Zone does not have enough free space");

            var bookStatus = new StatusStrings
            {
                Value = "Booked",
                Key = zone.Id,
                Object = nameof(Whzones)
            };

            DbContext.Add(bookStatus);
            await DbContext.SaveChangesAsync();
        }

        public async Task FreeZone(int zoneId)
        {
            var zone = await DbContext.Whzones.FirstOrDefaultAsync(i => i.Id == zoneId);

            if (zone == null)
            {
                throw new Exception("No entity found");
            }

            var bookStatus = await DbContext.StatusStrings.FirstOrDefaultAsync(s => s.Key == zone.Id && s.Object == nameof(Whzones) && s.Value == "Booked");

            if (bookStatus != null)
            {
                DbContext.Remove(bookStatus);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
