using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;
using WarehouseManagementSystem.Shared.PublicModels;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IWarehouseService
    {
        Task CreateWareHouse(Warehouse warehouse);
        Task<Warehouse[]> GetAllWarehouses();
        Task<WarehouseInfo> GetWarehouseReport(int whId);
    }
}