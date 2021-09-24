using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Skills.AddSkill
{
    public class AddSkillCommand : ICommand
    {
        public string Name { get; set; }
    }
}
