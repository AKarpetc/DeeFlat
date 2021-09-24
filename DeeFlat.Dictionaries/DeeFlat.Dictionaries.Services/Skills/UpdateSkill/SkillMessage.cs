using DeeFlat.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Skills.UpdateSkill
{
    public class SkillMessage : ISkillMessage
    {
        public string Name { get; set; }
       
        public Guid Id { get; set; }
    }
}
