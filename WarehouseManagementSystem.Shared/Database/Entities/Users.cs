namespace WarehouseManagementSystem.Shared.Database.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
    }
}
