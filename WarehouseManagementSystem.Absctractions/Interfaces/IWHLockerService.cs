using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IWHLockerService
    {
        Task CreateLocker(Whlockers locker);
        Task<Whlockers> GetLockerById(int lockerId);
        Task<Whlockers[]> GetZoneLockers(int zoneId);
    }
}