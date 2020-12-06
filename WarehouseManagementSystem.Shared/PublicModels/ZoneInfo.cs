using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Shared.PublicModels
{
    public class ZoneInfo
    {
        public Whzones Zone { get; set; }
        public bool IsBooked { get; set; }
        public bool IsEmpty { get; set; }
    }
}
