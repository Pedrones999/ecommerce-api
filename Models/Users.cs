namespace Users.Model;

public enum Roles
{
    Common = 1,
    Admin = 2,
}

public class User
{   
    private Roles _role;
    private string _name = "";
    private string _userPassword = "";
    private string _email = "";
    private readonly Guid _uuid = Guid.NewGuid();
    
    public Roles Role
    {
        get{return _role;}
        
        set
        {
            throw new ArgumentException("role cannot be changed");
        }
    }
    public Guid Uuid
    {
        get{return _uuid;}
        
        set
        {
            throw new ArgumentException("uuid cannot be changed");
        }
    }
    
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
}

 
