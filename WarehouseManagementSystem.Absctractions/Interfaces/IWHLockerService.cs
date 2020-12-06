using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;
using WarehouseManagementSystem.Shared.PublicModels;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IWHLockerService
    {
        Task CreateLocker(Whlockers locker);
        Task<LockerInfo> GetLockerById(int lockerId);
        Task<Whlockers[]> GetZoneLockers(int zoneId);
        Task RemoveLocker(int lockerId);
        Task FreeLocker(int lockerId);
        Task BookLocker(int lockerId);
    }
}