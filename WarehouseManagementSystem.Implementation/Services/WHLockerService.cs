using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;

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
            var lockers = await DbContext.Whlockers.Where(l => l.WhzoneId == zoneId).ToArrayAsync();
            return lockers;
        }

        public async Task<Whlockers> GetLockerById(int lockerId)
        {
            var locker = await DbContext.Whlockers.FirstOrDefaultAsync(z => z.Id == lockerId);
            return locker;
        }

        public async Task RemoveLocker(int lockerId)
        {
            var locker = await DbContext.Whlockers.Include(l=>l.Whcells).FirstOrDefaultAsync(i => i.Id == lockerId);

            if (locker == null)
            {
                throw new Exception("No entity found");
            }

            DbContext.RemoveRange(locker.Whcells);
            DbContext.Remove(locker);
            await DbContext.SaveChangesAsync();
        }
    }
}
