using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;

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

        public async Task<Whzones> GetZoneById(int zoneId)
        {
            var zone = await DbContext.Whzones.FirstOrDefaultAsync(z => z.Id == zoneId);
            return zone;
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
    }
}
