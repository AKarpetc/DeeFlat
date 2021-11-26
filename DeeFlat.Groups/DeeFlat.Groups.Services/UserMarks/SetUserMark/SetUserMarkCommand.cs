using DeeFlat.Abstractions.CQRS;
using System;

namespace DeeFlat.Groups.Services.UserMarks.SetUserMark
{
    public class SetUserMarkCommand : ICommand
    {
        public Guid UserGroupId { get; set; }

        public Guid CourseActivityId { get; set; }

        public int Mark { get; set; }       

        public string Comment { get; set; }
    }
}
