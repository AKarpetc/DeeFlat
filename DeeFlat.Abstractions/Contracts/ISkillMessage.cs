using System;

namespace DeeFlat.Abstractions.Contracts
{
    public interface ISkillMessage
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
