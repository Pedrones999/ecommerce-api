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
    public Roles Role
    {
        get{return _role;}
        
        set
        {
            _role = value;
        }
    }

    private string _name = "";
    public string Name
    {
        get{return _name;}
        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            if(value.Length <= 2)
            {
                throw new Exception("the name has to have at least 3 characters");
            }
            else{ _name = value;} 
        }
    }
    
    private string _userPassword = "";
    public string UserPassword
    {
        get{return _userPassword;}
        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            else{ _userPassword = value;}
        }
    }

    private string _email = "";
    public string Email
    {
        get{ return _email;}
        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            else{ _email = value;}
        }
    }
    
    private Guid _userId;
    public Guid UserId
    {
        get{return _userId;}
        set
            {
                _userId = Guid.NewGuid();
            }
    }
    
    public User(string name, string email, string userPassword, Roles role)
    {
        Name = name;
        Email = email;
        UserPassword = userPassword;
        Role = role;
    }
}

 
