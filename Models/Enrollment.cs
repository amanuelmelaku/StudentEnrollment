namespace StudentEnrollment.Models
{
    public class Enrollment
    {
     //   public int ID { get; set; }, if you use an id it won't become a pure join table.
     //   but you can add more fields to it (Enrollment) and get all of them by the id 

        public int StudentId { get; set; }
        public int CourseId {  get; set; }
        public DateTime EnrolledDate { get; set; } 

        public Course Course { get; set; }
        public Student Student { get; set; }

            
            }
}
