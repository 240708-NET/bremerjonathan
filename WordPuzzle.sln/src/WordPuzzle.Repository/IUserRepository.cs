using WordPuzzle.Model;

namespace WordPuzzle.Repository;

public interface IUserRepository
{
    User? GetUser(int id);
    User? GetUserByUserName(string userName);
    bool UserExists(string userName);
    int CountUsers();
    int AddUser(User user);
    int AddUsers(ISet<User> users);
}