using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Groups.Services.Groups.GetGroupsQuery
{
    public class GroupDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DropDownDTO Status { get; set; }
    }
}
