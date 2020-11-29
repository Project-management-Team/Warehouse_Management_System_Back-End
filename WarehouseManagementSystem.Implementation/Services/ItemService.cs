using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task RemoveItem(int itemId)
        {
            var item = await DbContext.Items.FirstOrDefaultAsync(i => i.Id == itemId);

            if (item == null)
            {
                throw new Exception("No entity found");
            }

            DbContext.Remove(item);
            await DbContext.SaveChangesAsync();
        }

        public async Task MoveItem(int itemId, int currentCellId, int destinationCellId)
        {
            var currentCell = await DbContext.Whcells.FirstOrDefaultAsync(i => i.Id == currentCellId);

            if (currentCell != null)
            {
                currentCell.ItemId = null;
            }

            var newCell = await DbContext.Whcells.FirstOrDefaultAsync(i => i.Id == destinationCellId);

            if (newCell == null)
            {
                throw new Exception("No entity found");
            }

            if (newCell.ItemId != null)
            {
                throw new Exception("Cell is not empty");
            }

            newCell.ItemId = itemId;

            await DbContext.SaveChangesAsync();
        }
    }
}
