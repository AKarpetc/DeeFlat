using DeeFlat.Abstractions.CQRS;
using System;

namespace DeeFlat.Groups.Services.Groups.AddGroupCommand
{
    public class AddGroupCommand : ICommand
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
