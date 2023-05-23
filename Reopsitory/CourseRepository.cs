using MVC_Assessment.Context;
using MVC_Assessment.Interface;
using MVC_Assessment.Models;

namespace MVC_Assessment.Reopsitory
{
    public class CourseRepository : ICourseInterface
    {
        TravelDbContext _db;
        public CourseRepository(TravelDbContext db)
        {
            _db = db;
        }
        public Course Create(Course course)
        {
           _db.courses.Add(course);
            _db.SaveChanges();
            return course;
        }

        public int Delete(int id)
        {
            Course ob = GetCourseById(id);
            if (ob != null)
            {
                foreach (Course us in _db.courses)
                {
                    if (us.CourseId == id)
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

        public int Edit(int id, Course course)
        {
            Course ob = GetCourseById(id);
            if (ob != null)
            {
                foreach (Course us in _db.courses)
                {
                    if (us.CourseId == id)
                    {

                        us.CourseName = course.CourseName;
                        us.Duration = course.Duration;
                        us.Description = course.Description;


                    }
                }
                _db.SaveChanges();
                return 0;
            }
            else return 1;
        }

        public List<Course> GetCourse()
        {
           return _db.courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _db.courses.FirstOrDefault(x => x.CourseId == id);
        }
    }
}
