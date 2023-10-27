using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Model;

public enum Roles
{
    Common = 1,
    Admin = 2,
}

[Table("Users")]
public class User
{   
    private Roles _role;
    public Roles? Role
    {
        get{return _role;}
        
        set
        {
            if(value != null)
            {
                _role = value.Value;
            }
            else{throw new ArgumentNullException("role");}
        }
    }

    private string _name = "";
    public string? Name
    {
        get{return _name;}
        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name");
            }
            if(value.Length <= 2)
            {
                throw new Exception("the name has to have at least 3 characters");
            }
            else{ _name = value;} 
        }
    }
    
    private string _userPassword = "";
    public string? UserPassword
    {
        get{return _userPassword;}
        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("password");
            }
            
            if(value.Length <= 2)
            {
                throw new Exception("the name has to have at least 3 characters");
            }
            
            else{ _userPassword = value;}

        }
    }

    private string _email = "";
    public string? Email
    {
        get{ return _email;}
        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("email");
            }
            if(! value.Contains('@') || ! value.Contains('.') || value.Length < 10)
            {
                throw new ArgumentException("use a valid email");
            }
            else{ _email = value;}
        }
    }
    
    private Guid _userId = Guid.NewGuid();
    public Guid UserId
    {
        get{ return _userId; }
        private set{ _userId = value; }
    }
    
    public User(string? name, string? email, string? userPassword, Roles? role)
    {
        Name = name;
        Email = email;
        UserPassword = userPassword;
        Role = role;
    }
}

 
