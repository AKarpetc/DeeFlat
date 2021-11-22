using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Homework.Core.Domain
{
    public class Chat : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Guid PupilId { get; set; }
        public Guid AssignedTeacherId { get; set; }
    }
}
