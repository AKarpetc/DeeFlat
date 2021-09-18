using DeeFlat.Core.DTO;

namespace DeeFlat.Services.Courses.GetAllCoursesQuery
{
    public class CourseDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public EnumDropDownDTO Status { get; set; }
    }
}
