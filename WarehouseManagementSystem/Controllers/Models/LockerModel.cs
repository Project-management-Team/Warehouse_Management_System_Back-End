namespace WarehouseManagementSystem.Api.Controllers.Models
{
    public class LockerModel
    {
        public string Name { get; set; }
        public int WhzoneId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
