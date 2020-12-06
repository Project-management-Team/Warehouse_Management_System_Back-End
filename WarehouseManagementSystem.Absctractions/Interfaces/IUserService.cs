using System.Threading.Tasks;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Abstractions.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(Users user);
        Task<Users> ValidateUser(Users user);
        Task<Users[]> GetAllUsers();
        Task DeleteUser(int userId);
    }
}