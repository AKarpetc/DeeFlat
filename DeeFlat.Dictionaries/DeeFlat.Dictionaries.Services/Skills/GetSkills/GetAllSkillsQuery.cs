using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Skills.GetSkills
{
    public class GetAllSkillsQuery : IQuery<IEnumerable<SkillDTO>>
    {
    }
}
