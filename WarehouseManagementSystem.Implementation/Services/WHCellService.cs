using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Implementation.Services
{
    public sealed class WHCellService : ServiceBase, IWHCellService
    {
        public WHCellService(WHManagmentSystemContext context) : base(context) { }

        public async Task CreateCell(Whcells cell)
        {
            DbContext.Whcells.Add(cell);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Items> GetCellItem(int cellId)
        {
            var cell = await DbContext.Whcells.FirstOrDefaultAsync(c => c.Id == cellId);
            return cell.Item;
        }

        public async Task<Whcells> GetCellById(int cellId)
        {
            var cell = await DbContext.Whcells.FirstOrDefaultAsync(z => z.Id == cellId);
            return cell;
        }

        public async Task RemoveCell(int cellId)
        {
            var cell = await DbContext.Whcells.FirstOrDefaultAsync(i => i.Id == cellId);

            if (cell == null)
            {
                throw new Exception("No entity found");
            }

            DbContext.Remove(cell);
            await DbContext.SaveChangesAsync();
        }
    }
}
