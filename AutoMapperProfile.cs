using StudentEnrollment.Dtos.Course;
using StudentEnrollment.Dtos.Enrollment;
using StudentEnrollment.Dtos.Student;

namespace StudentEnrollment
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, ViewStudentDto>();
            CreateMap<AddStudentDto, Student>();

            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Student, UpdateStudentDto>();

            CreateMap<AddStudentDto, Student>();
            CreateMap<Student, AddStudentDto>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto,Course>();

            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<EnrollmentDto, Enrollment>();
        }
    }
}
