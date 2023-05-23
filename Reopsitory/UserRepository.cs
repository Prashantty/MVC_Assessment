using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using MVC_Assessment.Context;
using MVC_Assessment.Interface;
using MVC_Assessment.Models;

namespace MVC_Assessment.Reopsitory
{
    public class UserRepository : IUserInterface
    {

        TravelDbContext _db;

        public UserRepository(TravelDbContext db) 
        {
            _db = db;
        }

        public User Create(User user)
        {
            _db.users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public int Delete(int id)
        {
           User ob = GetUserById(id);  
            if(ob != null)
            {
                 foreach(User us in _db.users)
                {
                    if(us.Id == id)
                    {
                        us.IsActive = false;
                    }
                }
                _db.SaveChanges();
                return 0;
            }
            else
            {
                return 1;
            }
                                  
        }

        public int Edit(int id, User user)
        {
            User ob =  GetUserById(id);
            if (ob != null)
            {
                foreach (User us in _db.users)
                {
                    if (us.Id == id)
                    {

                        us.Name = user.Name;
                        us.UpdatedDate = user.UpdatedDate;
                        us.CreatedDate = user.CreatedDate;
                        //us.IsActive = user.IsActive;
                        us.Contact = user.Contact;
                        //us.ManagerId = user.ManagerId;
                        us.Role = user.Role;

                    }
                }
                _db.SaveChanges();
                return 0;
            }
            else return 1;
           
        }

        public List<User> GetUser()
        {
            return _db.users.ToList();
        }

        //public List<User> GetUser1(int id)
        //{
        //    var query = from Employee in _db.users
        //                join Manager in _db.users
        //                on Employee.Id equals Manager.Id
        //                select new
        //                {

        //                };
            

        //}

        public User GetUserById(int id)
        {
            return _db.users.FirstOrDefault(x => x.Id == id);
        }
    }
}
