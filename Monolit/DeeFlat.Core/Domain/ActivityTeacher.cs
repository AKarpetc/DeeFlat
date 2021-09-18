using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class ActivityTeacher : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid CourseActivityId { get; set; }

        public virtual CourseActivity CourseActivity { get; set; }
    }
}
