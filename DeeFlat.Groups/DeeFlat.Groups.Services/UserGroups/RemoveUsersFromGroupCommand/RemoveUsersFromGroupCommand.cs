using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;

namespace DeeFlat.Groups.Services.UserGroups.RemoveUsersFromGroupCommand
{
    public class RemoveUsersFromGroupCommand : ICommand
    {
        public Guid GroupId { get; set; }

        public List<Guid> UserIds { get; set; }
    }
}
