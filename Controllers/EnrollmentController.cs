using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Dtos.Enrollment;
using StudentEnrollment.Services.EnrollmentService;

namespace StudentEnrollment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Enroll([FromBody] EnrollmentDto dto)
        {

            await _enrollmentService.Enroll(dto.StudentId, dto.CourseId);
            return true;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> UnEnroll(EnrollmentDto dto)
        {
            await _enrollmentService.Unenroll(dto.StudentId, dto.CourseId);
            return true;
        }

        [HttpGet("student/{studentId}/course")]
        public async Task<IEnumerable<Course>> Coursesenrolled(int studentId)
        {
          var response = await _enrollmentService.GetEnrollmentByStudent(studentId);
            return response;

        }

        [HttpGet("course/{courseId}/studetnt")]
        public async Task<IEnumerable<Student>> StudentsInCourse(int courseId)
        {
            var response = await _enrollmentService.GetEnrollmentByCourse(courseId);
            return response;
        }
       
    }
}
