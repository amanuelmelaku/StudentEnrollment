
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Identity.Client;
using StudentEnrollment.Data;
using StudentEnrollment.Models;
using System.Threading.Tasks;

namespace StudentEnrollment.Services.EnrollmentService
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EnrollmentService(IMapper mapper, DataContext context)
        {
           _mapper = mapper;
           _context = context;
        }

        public async Task<bool> Enroll(int studentId, int courseId)
        {

            //check if any of the id match the id
            var studentExists = await _context.Students.AnyAsync(s => s.Id == studentId);
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);

            //check if either course or student doesn't exist, or both  
            if(!studentExists || !courseExists)
            {
                return false;
            }

            //check if record already exists
            var exists = await _context.Enrollments.FindAsync(studentId, courseId);

            if (exists != null)
            {
                return false;
            }

            //create object of enrollment 
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };

            //add to db
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync(); //save
            return true;
        }
        public async Task<bool> Unenroll(int studentId, int courseId)
        {
            //check if the student and course exist 
            var studetntExists = await _context.Students.AnyAsync(s => s.Id == studentId);
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);

            if (!studetntExists || !courseExists)
            {
                return false;
            }

            //check if the record  in the enrolled exists 
            var enrollment = await _context.Enrollments.FindAsync(studentId, courseId);
            if (enrollment == null)
            {
                return false;
            }


          
          _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
           
        }
        public async Task<IEnumerable<Student>> GetEnrollmentByCourse(int courseId)
        {
            return await _context.Enrollments
                .Where(e=> e.CourseId == courseId)
                .Include(e => e.Student)  // Student (property in Enrollment.cs)
                .Select(e=> e.Student) // Student (property in Enrollment.cs)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetEnrollmentByStudent(int studentId)
        {
            return await _context.Enrollments
                 .Where(e => e.StudentId == studentId)
                 .Include(e => e.Course)
                 .Select(e => e.Course)
                 .ToListAsync();
        }




      

    }
}
