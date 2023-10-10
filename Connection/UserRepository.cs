using Users.Model;

namespace Connection;
public class UserRepository : IUserRepository
{   
    private readonly AppDbContext _context = new AppDbContext();
    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUser(Guid userId)
    {
        var user = _context.Users.Find(userId);
        return user;
    }

    public void RemoveUser(Guid userId)
    {
        var user = _context.Users.Find(userId);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
