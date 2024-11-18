namespace EducationalPlatform.ViewModel
{
    public class StudentProfileViewModel
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? JoinDate { get; set; }
        public string Gender { get; set; }
        public List<CourseViewModel> RegisteredCourses { get; set; }
    }
}
