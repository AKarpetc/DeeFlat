using DeeFlat.Abstractions.Abstractions;
using System;

namespace DeeFlat.Abstractions.Contracts
{
    public interface ILectureFinished : IBaseEmailMessage
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
