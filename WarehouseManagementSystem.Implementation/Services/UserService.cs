using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Shared.Database.Context;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Implementation.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(WHManagmentSystemContext context) : base(context) { }

        public async Task CreateUser(Users user)
        {
            if (DbContext.Users.Any(u => u.Login == user.Login)) throw new Exception("Login is already in use");

            DbContext.Add(user);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Users> ValidateUser(Users user)
        {
            var validUser = await DbContext.Users.FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);

            return validUser;
        }

        public async Task<Users[]> GetAllUsers()
        {
            return await DbContext.Users.ToArrayAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                DbContext.Remove(user);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
