namespace MVC_Assessment.Models
{
    public class User
    {
        public enum UserRole
        {
            Manager,
            Employee
        }

        public int Id{ get; set; }

        public string Name  { get; set; }

        public int Contact { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set;  }    

        public Boolean IsActive { get; set; }  = true;

        public UserRole Role { get; set; }  


        public int ManagerId { get; set; }

    }
}
