using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Dtos.Course;
using StudentEnrollment.Services.CourseService;

namespace StudentEnrollment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> Add([FromBody]CourseDto courseDto) {

     

           var addedCourse= await _courseService.Add(courseDto);
            return addedCourse;

        }

        [HttpDelete]
        public async Task<ActionResult<List<CourseDto>>> Delete(int id)
        {
            var response = await _courseService.DeleteCourse(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> View()
        {
            var response = await _courseService.ViewCourses();
            return Ok(response);   
        }

        [HttpPut]
        public async  Task<ActionResult<CourseDto>> Update(CourseDto courseDto)
        {
            var course = new Course()
            {
                Id = courseDto.Id,
                Title = courseDto.Title,
                Description = courseDto.Description,
            };

            
            var updated = await _courseService.Update(course);
            if(updated == null)
            {
                Console.WriteLine($"no course updated");
            }

            return Ok(updated);
        }


    }
}
