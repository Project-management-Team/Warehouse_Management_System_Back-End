using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Implementation.Services
{
    public class TruckService : ServiceBase, ITruckService
    {
        public TruckService(WHManagmentSystemContext context) : base(context) { }

        public async Task CreateTruck(Trucks truck)
        {
            truck.TruckCells = new List<TruckCells>();
            for (int i = 0; i < truck.Height; i++)
            {
                for (int j = 0; j < truck.Width; j++)
                {
                    var truckCell = new TruckCells
                    {
                        Row = i,
                        Column = j
                    };

                    truck.TruckCells.Add(truckCell);
                }
            }

            DbContext.Add(truck);
            await DbContext.SaveChangesAsync();
        }

        public async Task PutItemToCell(int cellId, int itemId)
        {
            if (!DbContext.Items.Any(i => i.Id == itemId)) throw new Exception("No item found");

            var truckCell = await DbContext.TruckCells.FirstOrDefaultAsync(c => c.Id == cellId);

            if(truckCell == null) throw new Exception("No cell found");

            truckCell.ItemId = itemId;

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteTruck(int truckId)
        {
            var truck = await DbContext.Trucks.Include(t=>t.TruckCells).FirstOrDefaultAsync(t => t.Id == truckId);

            if (truck == null) return;

            DbContext.RemoveRange(truck.TruckCells);
            DbContext.Remove(truck);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TruckCells[]> GetTruckCells(int truckId)
        {
            var truckCells = await DbContext.TruckCells.Include(c => c.Item).Where(c => c.TruckId == truckId).ToArrayAsync();

            return truckCells;
        }

        public async Task<Trucks> GetTruck(int truckId)
        {
            var truck = await DbContext.Trucks.Include(c => c.TruckCells).FirstOrDefaultAsync(c => c.Id == truckId);

            return truck;
        }

        public async Task<Trucks[]> GetAllTrucks()
        {
            return await DbContext.Trucks.ToArrayAsync();
        }
    }
}
