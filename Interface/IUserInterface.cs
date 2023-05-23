using MVC_Assessment.Models;

namespace MVC_Assessment.Interface
{
    public interface IUserInterface
    {

        List<User> GetUser();
        User Create(User user);
        User GetUserById(int id);
        int Edit(int id, User user);
        int Delete(int id);
       // public List<User> GetUser1(int id);

    }
}
