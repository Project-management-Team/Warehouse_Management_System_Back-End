using System.Collections.Generic;

namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class Items
    {
        public Items()
        {
            TruckCells = new HashSet<TruckCells>();
            Whcells = new HashSet<Whcells>();
        }

        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public virtual ICollection<TruckCells> TruckCells { get; set; }
        public virtual ICollection<Whcells> Whcells { get; set; }
    }
}
