using StudentEnrollment.Dtos.Student;

namespace StudentEnrollment.Services.StudentService
{
    public interface IStudentService 
    {
        Task<AddStudentDto> Add( AddStudentDto Student);
        Task<ViewStudentDto> Remove( int id  );
        Task<UpdateStudentDto> Update(Student Student );

        Task<List<ViewStudentDto>> View();

    }
}
