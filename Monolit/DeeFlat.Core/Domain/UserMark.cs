using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class UserMark : BaseEntity
    {
        public int Mark { get; set; }

        public Guid UserGroupId { get; set; }

        public virtual UserGroup UserGroup { get; set; }

        public Guid CourseActivityId { get; set; }

        public virtual CourseActivity CourseActivity { get; set; }

        public string Comment { get; set; }
    }
}
