using System.Collections.Generic;

namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class Whlockers
    {
        public Whlockers()
        {
            Whcells = new HashSet<Whcells>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int WhzoneId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public virtual Whzones Whzone { get; set; }
        public virtual ICollection<Whcells> Whcells { get; set; }
    }
}
