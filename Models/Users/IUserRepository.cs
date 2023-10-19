namespace Users.Model;
public interface IUserRepository
{
    void Add(User user);
    
    void RemoveUser(Guid userId);

    List<User> GetAllUsers();

    Guid? GetIdByName(string userName);

    User? GetUser(Guid? userId);

    void UpdateUser(Guid userId, string? password = null, string? name = null, string? email = null, Roles? role = null);



}
