using DeeFlat.Abstractions.CQRS;
using System;

namespace DeeFlat.Groups.Services.Groups.EditGroupCommand
{
    public class EditGroupCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
