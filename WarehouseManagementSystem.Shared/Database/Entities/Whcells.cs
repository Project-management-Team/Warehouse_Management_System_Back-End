namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class Whcells
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WhlockerId { get; set; }
        public int? ItemId { get; set; }
        public int Status { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public virtual Items Item { get; set; }
        public virtual Whlockers Whlocker { get; set; }
    }
}
