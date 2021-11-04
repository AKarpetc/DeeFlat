using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Groups.Core.Domain
{
    public class UserMark : BaseEntity
    {
        public int Mark { get; set; }

        public Guid UserGroupId { get; set; }

        public virtual UserGroup UserGroup { get; set; }

        public Guid CourseActivityId { get; set; }

        public string Comment { get; set; }
    }
}
