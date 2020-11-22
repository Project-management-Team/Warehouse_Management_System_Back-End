using System.Collections.Generic;

namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class Whzones
    {
        public Whzones()
        {
            Whlockers = new HashSet<Whlockers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Whid { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public virtual Warehouse Wh { get; set; }
        public virtual ICollection<Whlockers> Whlockers { get; set; }
    }
}
