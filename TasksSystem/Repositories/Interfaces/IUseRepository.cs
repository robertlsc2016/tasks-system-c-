using TasksSystem.Models;

namespace TasksSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //TASK PARA CHAMADA ASSINCRONA
        Task<List<UserModel>> SearchAllUsers();
        Task<UserModel> SearchById(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);

    }
}
