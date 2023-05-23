using System.Reflection.Metadata.Ecma335;

namespace MVC_Assessment.Models
{
    public class Request
    {

        public int RequestID { get; set; }
        public DateTime? RequestDate { get; set; }
        
        public string Comment { get; set; } 
        
        public int CouseId { get; set; }  
        
        public  string BatchName { get; set; }

        public int ManagerId { get; set; }  

        public int UserId { get; set; }  


    }
}
