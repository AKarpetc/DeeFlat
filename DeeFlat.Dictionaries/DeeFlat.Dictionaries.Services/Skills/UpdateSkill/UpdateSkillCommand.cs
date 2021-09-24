using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Skills.UpdateSkill
{
    public class UpdateSkillCommand : BaseDTO, ICommand
    {
        public string Name { get; set; }
    }
}
