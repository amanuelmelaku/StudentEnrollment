using StudentEnrollment.Dtos.Course;
using StudentEnrollment.Data;
using System.Linq.Expressions;
namespace StudentEnrollment.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private List<Course> courses = new List<Course>()
        {
            new Course {Id=1, Title = "Data Structure and Algorithms", Description=" new Algorithims"},
            new Course {Id=1, Title = "Data Structure and Algorithms", Description=" new Algorithims"},
        };
        public CourseService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<CourseDto> Add(CourseDto newCourse)
        {
            //Map Dto to Entity
            var course = _mapper.Map<Course>(newCourse);


            _context.Courses.Add(course);
            

            //map Dto to entity
            var addCourseDto = _mapper.Map<CourseDto>(course);
            await _context.SaveChangesAsync();
            return addCourseDto;
        }

        public async Task<CourseDto> DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                Console.WriteLine($"there is no course referenced by the id: {id}");
                return null;
            }

            _context.Courses.Remove(course);
           await _context.SaveChangesAsync();

            //Mapping Dto before returning
            var deleteDto = _mapper.Map<CourseDto>(course);
            return deleteDto;

        }

        public async Task<CourseDto> Update(Course updateCourse)
        {
            var dbCourse = _context.Courses.FirstOrDefault(c => c.Id == updateCourse.Id);

            if (dbCourse == null)
            {
                Console.WriteLine($"there is no course referenced by the id: {updateCourse.Id}");
                return null;
            }
            dbCourse.Title = updateCourse.Title;
            dbCourse.Description = updateCourse.Description;

            var dtoUpdate = _mapper.Map<CourseDto>(dbCourse);
           await _context.SaveChangesAsync();
            return dtoUpdate;
        }

        public async Task<List<CourseDto>> ViewCourses()
        {
            var viewDto =_context.Courses.Select(c => _mapper.Map<CourseDto>(c)).ToList();
            return viewDto;
        }


    }
}
