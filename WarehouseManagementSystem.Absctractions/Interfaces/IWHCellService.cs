using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IWHCellService
    {
        Task CreateCell(Whcells cell);
        Task<Whcells> GetCellById(int cellId);
        Task<Items> GetCellItem(int cellId);
        Task RemoveCell(int cellId);
    }
}