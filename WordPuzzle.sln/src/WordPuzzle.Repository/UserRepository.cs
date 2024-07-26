using Microsoft.EntityFrameworkCore;
using WordPuzzle.Model;

namespace WordPuzzle.Repository;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public User? GetUser(int id)
    {
        return _context.Users.Find(id);
    }

    public User? GetUserByUserName(string userName) {
        return _context.Users.SingleOrDefault(u => u.UserName.Equals(userName));
    }

    public bool UserExists(string userName) {
        var user = GetUserByUserName(userName);
        return user != null;
    }

    public int CountUsers() {
        return _context.Users.Count();
    }

    public int AddUser(User user)
    {
        _context.Add(user);
        return _context.SaveChanges();
    }

    public int AddUsers(ISet<User> users)
    {
        _context.AddRange(users);
        return _context.SaveChanges();
    }

}