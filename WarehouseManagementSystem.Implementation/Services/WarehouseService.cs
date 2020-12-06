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

    public sealed class WarehouseService : ServiceBase, IWarehouseService
    {
        public WarehouseService(WHManagmentSystemContext context) : base(context) { }

        public async Task CreateWareHouse(Warehouse warehouse)
        {
            DbContext.Warehouse.Add(warehouse);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Warehouse[]> GetAllWarehouses()
        {
            var warehouses = await DbContext.Warehouse.ToArrayAsync();
            return warehouses;
        }

        public async Task<WarehouseInfo> GetWarehouseReport(int whId)
        {
            var warehouse = await DbContext.Warehouse.Include(w => w.Whzones).ThenInclude(z => z.Whlockers).ThenInclude(l => l.Whcells).FirstOrDefaultAsync(w => w.Id == whId);

            if (warehouse == null) throw new Exception("No entity found");
            var bookedZones = await DbContext.StatusStrings.Where(s => warehouse.Whzones.Select(z => z.Id).Contains(s.Key) && s.Object == nameof(Whzones) && s.Value == "Booked").CountAsync();
            var bookedLockers = DbContext.StatusStrings.Where(s => warehouse.Whzones.SelectMany(z => z.Whlockers)
                                                                                          .Select(z => z.Id).Contains(s.Key) && s.Object == nameof(Whlockers) && s.Value == "Booked")
                                                                                          .Count();
            var overallSpace = warehouse.Whzones.SelectMany(z => z.Whlockers).SelectMany(l => l.Whcells).Count();
            var occupiedSpace = warehouse.Whzones.SelectMany(z => z.Whlockers).SelectMany(l => l.Whcells).Where(c => c.ItemId != null).Count();

            return new WarehouseInfo
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Address = warehouse.Address,
                NumberOfLockers = warehouse.Whzones.SelectMany(z => z.Whlockers).Count(),
                NumberOfZones = warehouse.Whzones.Count(),
                OverallSpace = overallSpace,
                OccupiedSpace = occupiedSpace,
                BookedLockers = bookedLockers,
                BookedZones = bookedZones
            };
        }
    }
}
