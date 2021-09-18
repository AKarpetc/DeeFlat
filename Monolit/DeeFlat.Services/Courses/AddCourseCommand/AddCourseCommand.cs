using DeeFlat.Core.Abstractions;

namespace DeeFlat.Services.Courses.AddCourseCommand
{
    public class AddCourseCommand : ICommand
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
