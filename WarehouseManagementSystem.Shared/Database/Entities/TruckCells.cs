namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class TruckCells
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public int? ItemId { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        public virtual Items Item { get; set; }
        public virtual Trucks Truck { get; set; }
    }
}
