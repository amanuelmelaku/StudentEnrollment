using StudentEnrollment.Dtos.Course;

namespace StudentEnrollment.Services.CourseService
{
    public interface ICourseService 
    {
        Task<List<CourseDto>> ViewCourses();

        Task<CourseDto> DeleteCourse(int id);
        Task<CourseDto> Update(Course course);

        Task<CourseDto> Add(CourseDto newCourse);

    }
}
