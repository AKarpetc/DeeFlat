using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Course.Core.Domain.Enums;

namespace DeeFlat.Course.Core.Domain
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CourseStatuses Status { get; set; }

    }
}
