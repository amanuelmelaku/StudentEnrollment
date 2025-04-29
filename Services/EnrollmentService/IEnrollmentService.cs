namespace StudentEnrollment.Services.EnrollmentService
{
    public interface IEnrollmentService
    {
       Task<bool> Enroll(int studentId, int courseId);

        Task<bool> Unenroll(int studentId, int courseId);

       Task<IEnumerable<Student>> GetEnrollmentByCourse(int courseId);
        Task<IEnumerable<Course>> GetEnrollmentByStudent(int studentId);
    }
}
