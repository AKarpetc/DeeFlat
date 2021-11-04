using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Groups.Core.Domain
{
    public class UserGroup : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
