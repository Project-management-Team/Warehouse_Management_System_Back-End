using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IWarehouseService
    {
        Task CreateWareHouse(Warehouse warehouse);
        Task<Warehouse[]> GetAll();
    }
}