using System.Reflection.Metadata.Ecma335;

namespace MVC_Assessment.Models
{
    public class Batch
    {

        public int BatchID { get; set; }
        public string BatchName { get; set; }

        public string Trainer { get; set; }

        public DateTime? StartDate { get; set; }    
        
        public int CourseId { get; set; }    
        public Course Course { get; set; }


    }
}
