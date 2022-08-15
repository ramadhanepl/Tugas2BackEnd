namespace Tugas2BackEnd.DTO
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class EnrollmentReadDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
    }
}
