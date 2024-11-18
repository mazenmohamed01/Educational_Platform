namespace EducationalPlatform.ViewModel
{
    public class CourseViewModel
    {
        public int student_id {  get; set; }
        public int courseId {  get; set; }
        public string Image { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }  // Nullable to allow for courses without a price
        public string Level { get; set; }
        public string InstructorName { get; set; }
    }
}
