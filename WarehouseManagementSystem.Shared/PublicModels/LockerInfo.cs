using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Shared.PublicModels
{
    public class LockerInfo
    {
        public Whlockers Locker { get; set; }
        public bool IsBooked { get; set; }
        public bool IsEmpty { get; set; }
    }
}
