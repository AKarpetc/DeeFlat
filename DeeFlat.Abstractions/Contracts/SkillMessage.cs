using DeeFlat.Abstractions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Abstractions.Contracts
{
    public interface ISkillMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
