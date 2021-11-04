using DeeFlat.Abstractions.CQRS;
using System;

namespace DeeFlat.Groups.Services.Groups.RemoveGroupCommand
{
    public class RemoveGroupCommand : ICommand
    {
        public Guid GroupId { get; set; }
    }
}
