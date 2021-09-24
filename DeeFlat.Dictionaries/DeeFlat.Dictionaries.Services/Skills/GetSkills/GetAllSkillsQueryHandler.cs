using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Skills.GetSkills
{
    public class GetAllSkillsQueryHandler : BaseQueryHandlerAsync<GetAllSkillsQuery, IEnumerable<SkillDTO>>
    {
        private readonly DeeFlatDictDbContext _db;

        public GetAllSkillsQueryHandler(DeeFlatDictDbContext db)
        {
            _db = db;
        }

        public async override Task<IEnumerable<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _db.Skills.Select(x => new SkillDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
