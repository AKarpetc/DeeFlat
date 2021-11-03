using DeeFlat.Abstractions.Abstractions;
using System;
using System.Collections.Generic;

namespace DeeFlat.Abstractions.Contracts
{
    public interface IHomeworkCompleted : IBaseEmailMessage
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
