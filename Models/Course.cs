using System.Reflection.Metadata.Ecma335;

namespace MVC_Assessment.Models
{
    public class Course
    {
        public enum Courses
        {
            DotNet,
            Java,
            DotNetFullStack,
            Cloud,
            MERN
        } 


        public int CourseId { get; set; }

        public Courses CourseName { get; set; }

        public string Description { get; set; } 

        public int Duration { get; set; }

        public Boolean IsActive { get; set; } = true; 

    }
    
}
