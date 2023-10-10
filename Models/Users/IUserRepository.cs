namespace Users.Model;
public interface IUserRepository
{
    void Add(User user);
    
    void RemoveUser(Guid userId);

    List<User> GetAllUsers();

    User? GetUser(Guid userId);


}
