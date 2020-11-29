namespace WarehouseManagementSystem.Api.Controllers.Models
{
    public class CellModel
    {
        public string Name { get; set; }
        public int WhlockerId { get; set; }
        public int? ItemId { get; set; }
        public int Status { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
