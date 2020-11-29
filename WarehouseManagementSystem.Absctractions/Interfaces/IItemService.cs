using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IItemService
    {
        Task CreateItem(Items item);
        Task<Items[]> GetWarehouseItems(int whId);
        Task MoveItem(int itemId, int currentCellId, int destinationCellId);
        Task RemoveItem(int itemId);
    }
}