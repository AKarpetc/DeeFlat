using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Groups.Core.Domain
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public GroupStatuses GroupStatusId { get; set; }

        public virtual GroupStatus GroupStatus { get; set; }
    }
}
