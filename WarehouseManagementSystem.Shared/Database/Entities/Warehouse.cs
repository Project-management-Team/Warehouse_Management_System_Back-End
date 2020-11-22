using System.Collections.Generic;

namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Whzones = new HashSet<Whzones>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Whzones> Whzones { get; set; }
    }
}
