using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Implementation.Services
{
    public sealed class ItemService : ServiceBase, IItemService
    {
        public ItemService(WHManagmentSystemContext context) : base(context) { }

        public async Task CreateItem(Items item)
        {
            DbContext.Items.Add(item);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Items[]> GetWarehouseItems(int whId)
        {
            var items = await DbContext.Items.Where(i => i.Whcells.Any(c => c.Whlocker.Whzone.Whid == whId)).ToArrayAsync();
            return items;
        }
    }
}
