using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Dtos.Student;
using StudentEnrollment.Services.StudentService;
using System.Threading.Tasks;

namespace StudentEnrollment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
   

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }



       
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent([FromBody] AddStudentDto addStudentDto)
        {

           

            var addedStudent = await _studentService.Add(addStudentDto);
            return  Ok(addedStudent);
        }


        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(UpdateStudentDto updatedStudentDto)
        {
            var student = new Student()
            {
                Id = updatedStudentDto.Id,
                Name = updatedStudentDto.Name,
                Email = updatedStudentDto.Email,
                Department = updatedStudentDto.Department,
            };

            var updatedStudent = await _studentService.Update(student);

            if(updatedStudent == null)
            {
                Console.WriteLine("don't have a student to update");
            }
            return Ok(updatedStudent);
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> ViewStudents( )
        {
            
            var viewStudents  = await _studentService.View();
            return Ok(viewStudents);

        }

        [HttpDelete]
        public async Task<ActionResult<List<Student>>> DeleteStudents(int id)
        {
            var response = await _studentService.Remove(id);
            return Ok(response);

        }

        


    }
} 
