using Users.Model;
using Auth;

namespace Connection;
public class UserRepository : IUserRepository
{   
    private readonly AppDbContext _context = new AppDbContext();
    
    private bool isUniqueEmail(string email)
    {
        var emails = _context.Users
            .Select(u => u.Email);
       
        if(! emails.Contains(email))
        {
            return true;
        }
        
        return false;
    }
    
    private bool isUniqueName(string name)
    {
        var names = _context.Users
            .Select(u => u.Name);
       
        if(! names.Contains(name))
        {
            return true;
        }
        
        return false;
    }  
    
    public void Add(User user)
    {   
        
        if(! isUniqueEmail(user.Email))
        {
            throw new Exception("email has to be unique");
        }
        
        if(! isUniqueName(user.Name))
        {
            throw new Exception("Name has to be unique");
        }
        
        user.UserPassword = Keys.HashingPassword(user.UserPassword);

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

        var id = _context.Users
            .Where(u => u.Name == userName)
            .Select(u => u.UserId);
        
        return id.FirstOrDefault();
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
