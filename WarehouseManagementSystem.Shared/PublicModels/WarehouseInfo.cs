namespace WarehouseManagementSystem.Shared.PublicModels
{
    public class WarehouseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfZones { get; set; }
        public int NumberOfLockers { get; set; }
        public int BookedZones { get; set; }
        public int BookedLockers { get; set; }
        public int OverallSpace { get; set; }
        public int OccupiedSpace { get; set; }
    }
}
