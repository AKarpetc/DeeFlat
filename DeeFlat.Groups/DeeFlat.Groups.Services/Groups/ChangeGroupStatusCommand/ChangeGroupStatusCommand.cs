using DeeFlat.Abstractions.CQRS;
using DeeFlat.Groups.Core.Domain;
using System;

namespace DeeFlat.Groups.Services.Groups.ChangeGroupStatusCommand
{
    public class ChangeGroupStatusCommand : ICommand
    {
        public Guid GroupId { get; set; }

        public GroupStatuses GroupsStatusId { get; set; }
    }
}
