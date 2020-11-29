using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;

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

        public async Task<Warehouse[]> GetAll()
        {
            var warehouses = await DbContext.Warehouse.ToArrayAsync();
            return warehouses;
        }
    }
}
