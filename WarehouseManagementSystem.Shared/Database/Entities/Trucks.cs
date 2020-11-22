using System.Collections.Generic;

namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class Trucks
    {
        public Trucks()
        {
            TruckCells = new HashSet<TruckCells>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual ICollection<TruckCells> TruckCells { get; set; }
    }
}
