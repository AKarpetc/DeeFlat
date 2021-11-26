using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Course.Services.Courses.GetAllCourses
{
    public class GetAllCoursesQuery : IQuery<IEnumerable<GetCourseDTO>>
    {
    }
}
