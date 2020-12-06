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
    public sealed class WHLockerService : ServiceBase, IWHLockerService
    {
        public WHLockerService(WHManagmentSystemContext context) : base(context) { }

        public async Task CreateLocker(Whlockers locker)
        {
            DbContext.Whlockers.Add(locker);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Whlockers[]> GetZoneLockers(int zoneId)
        {
            var lockers = await DbContext.Whlockers.Include(l => l.Whcells).Where(l => l.WhzoneId == zoneId).ToArrayAsync();
            return lockers;
        }

        public async Task<LockerInfo> GetLockerById(int lockerId)
        {
            var locker = await DbContext.Whlockers.Include(l => l.Whcells).FirstOrDefaultAsync(z => z.Id == lockerId);

            if (locker == null) throw new Exception("No entity found");
            var isBooked = await DbContext.StatusStrings.AnyAsync(s => s.Key == locker.Id && s.Object == nameof(Whlockers) && s.Value == "Booked");
            var isEmpty = !locker.Whcells.Any(c => c.ItemId != null);
            return new LockerInfo
            {
                Locker = locker,
                IsBooked = isBooked,
                IsEmpty = isEmpty
            };
        }

        public async Task RemoveLocker(int lockerId)
        {
            var locker = await DbContext.Whlockers.Include(l => l.Whcells).FirstOrDefaultAsync(i => i.Id == lockerId);

            if (locker == null)
            {
                throw new Exception("No entity found");
            }

            DbContext.RemoveRange(locker.Whcells);
            DbContext.Remove(locker);
            await DbContext.SaveChangesAsync();
        }

        public async Task MoveLocker(int lockerId, int newZoneId)
        {
            var locker = await DbContext.Whlockers.Include(l => l.Whcells).FirstOrDefaultAsync(i => i.Id == lockerId);

            if (locker == null)
            {
                throw new Exception("No entity found");
            }

            locker.WhzoneId = newZoneId;

            await DbContext.SaveChangesAsync();
        }

        public async Task BookLocker(int lockerId)
        {
            var locker = await DbContext.Whlockers.Include(l => l.Whcells).FirstOrDefaultAsync(i => i.Id == lockerId);

            if (locker == null)
            {
                throw new Exception("No entity found");
            }

            var bookStatus = new StatusStrings
            {
                Value = "Booked",
                Key = locker.Id,
                Object = nameof(Whlockers)
            };

            DbContext.Add(bookStatus);
            await DbContext.SaveChangesAsync();
        }

        public async Task FreeLocker(int lockerId)
        {
            var locker = await DbContext.Whlockers.Include(l => l.Whcells).FirstOrDefaultAsync(i => i.Id == lockerId);

            if (locker == null)
            {
                throw new Exception("No entity found");
            }

            var bookStatus = await DbContext.StatusStrings.FirstOrDefaultAsync(s => s.Key == locker.Id && s.Object == nameof(Whlockers) && s.Value == "Booked");

            if (bookStatus != null)
            {
                DbContext.Remove(bookStatus);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
