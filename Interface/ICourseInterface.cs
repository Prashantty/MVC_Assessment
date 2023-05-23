using MVC_Assessment.Models;

namespace MVC_Assessment.Interface
{
    public interface ICourseInterface
    {
        List<Course> GetCourse();
        Course Create(Course course);
        Course GetCourseById(int id);
        int Edit(int id, Course course);
        int Delete(int id);
    }
}
