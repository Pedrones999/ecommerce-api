namespace Users.Model;
public interface IUserRepository
{
    void Add(User user);
    // void Remove(User user);

    List<User> GetAllUsers();

    //User GetUser(Guid userId);


}
