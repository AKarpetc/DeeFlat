using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CourseStatuses StatusId { get; set; }

        public virtual CourseStatus Status { get; set; }

    }
}
