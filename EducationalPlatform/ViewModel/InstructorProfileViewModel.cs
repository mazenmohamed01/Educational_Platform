using EducationalPlatform.Models;

namespace EducationalPlatform.ViewModel
{
    internal class InstructorProfileViewModel
    {
        public string Image {  get; set; }
        public int InstructorId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? JoinDate { get; set; }
        public List<Course> Courses { get; set; }
    }
}