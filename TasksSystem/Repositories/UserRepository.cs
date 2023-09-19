using Microsoft.EntityFrameworkCore;
using TasksSystem.Data;
using TasksSystem.Models;
using TasksSystem.Repositories.Interfaces;

namespace TasksSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<UserModel> SearchById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }


        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userId = await SearchById(id);

            if (userId == null)
            {
                throw new Exception($"User Id {id} not Found");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;

        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userId = await SearchById(id);

            if (userId == null)
            {
                throw new Exception($"User Id {id} not Found");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();
            return true;

        }




    }
}
