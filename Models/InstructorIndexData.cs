using Microsoft.AspNetCore.Mvc;

namespace ContsoUniversityPressTARpe22.Models
{
    public class InstructorIndexData : Controller
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Course> Courses { get; set; }

    }
}
