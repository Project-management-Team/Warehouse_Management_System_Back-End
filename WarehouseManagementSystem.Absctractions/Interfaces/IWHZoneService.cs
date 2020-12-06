using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;
using WarehouseManagementSystem.Shared.PublicModels;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IWHZoneService
    {
        Task CreateZone(Whzones zone);
        Task<Whzones[]> GetWhZones(int whId);
        Task<ZoneInfo> GetZoneById(int zoneId);
        Task RemoveZone(int zoneId);
        Task BookZone(int zoneId, int amount);
        Task FreeZone(int zoneId);
    }
}