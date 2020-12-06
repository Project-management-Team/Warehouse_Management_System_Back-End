namespace WarehouseManagementSystem.Api.Controllers.Models
{
    public class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int IsAdmin { get; set; }
    }
}
