using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Course.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Course.Services.Courses.AddCourse
{
    public class AddCourseCommand : ICommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CourseStatuses Status { get; set; }
    }
}
