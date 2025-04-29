        
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Threading.Tasks;
using StudentEnrollment.Dtos.Student;
using AutoMapper;
using StudentEnrollment.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace StudentEnrollment.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public StudentService(IMapper mapper, DataContext context)
        {
            try
            {
                _mapper = mapper;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception:" + ex.Message);
                throw;
            }

           _context = context;
        }

      

        public async Task<ViewStudentDto> Remove(int id)

        {

            var dbStudents = _context.Students.FirstOrDefault(s=> s.Id == id);
            if (dbStudents == null) 
             { 
                Console.WriteLine($"no student record found fot the id : {id}");
                return null;
                }

            // Students = Db set name 

            _context.Students.Remove(dbStudents);
            await _context.SaveChangesAsync();

            //Map to Dto before returning 
            var studentDto = _mapper.Map<ViewStudentDto>(dbStudents);      
            return studentDto;
        }
            
            

        public async Task<UpdateStudentDto> Update(Student updatedStudent)
        {
            
            var dbStudent = _context.Students.FirstOrDefault(s => s.Id == updatedStudent.Id); 
            if(dbStudent == null)
            {
                Console.WriteLine($"there is no student with the id: {updatedStudent.Id}");

            }

            dbStudent.Name = updatedStudent.Name;
            dbStudent.Email = updatedStudent.Email;
            dbStudent.Department = updatedStudent.Department;

            var updateDto = _mapper.Map<UpdateStudentDto>(dbStudent);
            await _context.SaveChangesAsync();
            return updateDto;
        }

        public async Task<List<ViewStudentDto>> View()
        {

            var viewDto = _context.Students.Select(s => _mapper.Map<ViewStudentDto>(s)).ToList();
            return viewDto;
        }   

        public async Task<AddStudentDto> Add(AddStudentDto newStudentDto)
        {   

            //Map (DTO => Entity)
             var newStudent=_mapper.Map<Student>(newStudentDto);
          

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync(); // it can end here, the bottom one just help to see hat you entered

            //map back (Entity => DTO)
            var createdDto = _mapper.Map<AddStudentDto>(newStudent);
            return createdDto;
        }

     


    }
}
