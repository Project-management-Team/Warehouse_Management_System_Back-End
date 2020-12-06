using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface ITruckService
    {
        Task CreateTruck(Trucks truck);
        Task DeleteTruck(int truckId);
        Task PutItemToCell(int cellId, int itemId);
        Task<TruckCells[]> GetTruckCells(int truckId);
        Task<Trucks> GetTruck(int truckId);
        Task<Trucks[]> GetAllTrucks();
    }
}