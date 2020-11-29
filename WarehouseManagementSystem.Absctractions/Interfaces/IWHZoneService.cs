using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IWHZoneService
    {
        Task CreateZone(Whzones zone);
        Task<Whzones[]> GetWhZones(int whId);
        Task<Whzones> GetZoneById(int zoneId);
    }
}