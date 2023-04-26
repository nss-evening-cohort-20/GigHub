using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IUserRepository
    {
        void Delete(int id);
        List<User> GetAllUsers();
        User GetUserById(int id);
        void Insert(User user);
        void Update(User user);
    }
}