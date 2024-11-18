using EducationalPlatform.Models;

namespace EducationalPlatform.ViewModel
{
    public class CourseMaterialsViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<Material> Materials { get; set; }
    }
}
