using DeeFlat.Abstractions.Abstractions;
using System;
using System.Collections.Generic;

namespace DeeFlat.Homework.Core.Domain
{
    public class Chat : BaseEntity
    {
        public IEnumerable<Guid> ChatParticipants { get; set; }
        
    }
}
