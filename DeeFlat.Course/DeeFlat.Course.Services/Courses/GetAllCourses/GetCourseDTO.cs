using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Course.Services.Courses.GetAllCourses
{
    public class GetCourseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string StatusName { get; set; }

        public int CountActivities { get; set; }

    }
}
