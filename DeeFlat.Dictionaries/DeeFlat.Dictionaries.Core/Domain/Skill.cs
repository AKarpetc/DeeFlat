using DeeFlat.Abstractions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Core.Domain
{
    public class Skill : BaseEntity
    {
        public Skill(string name)
        {
            Name = name;
        }
        public Skill()
        {
        }

        public string Name { get; set; }
    }
}
