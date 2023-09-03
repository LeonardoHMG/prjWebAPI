using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUsersById(int id);
        Task<UserModel>Add(UserModel user);
        Task<UserModel>Update(UserModel user, int id);
        Task<bool>Delete(int id);
    }
}
