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

    public User? GetUser(Guid? userId)
    {
        var user = _context.Users.Find(userId);
        return user;
    }

        public Guid? GetIdByName (string userName)
    {
        List<User> All = GetAllUsers();
        foreach(var user in All)
        {
            if(user.Name == userName)
            {
                return user.UserId;
            }
        
        }
        
        return null;
    }

    public void RemoveUser(Guid userId)
    {
        var user = _context.Users.Find(userId);
        
        if(user != null)
        {    
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public void UpdateUser(Guid userId, string? password = null, string? name = null, string? email = null, Roles? role = null)
    {
        var user = _context.Users.Find(userId);
        
        if(user != null)
        {

            if(password != null)
            {
                user.UserPassword = password;
            }
            
            if(name != null)
            {
                user.Name = name;
            }

            if(email != null)
            {
                user.Email = email;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
            
        }
    }
}
