using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.Core.Domain;
using DeeFlat.Dictionaries.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Skills.AddSkill
{
    public class AddSkillCommandHandler : BaseCommandHandler<AddSkillCommand>
    {
        private readonly DeeFlatDictDbContext _db;

        public AddSkillCommandHandler(DeeFlatDictDbContext db)
        {
            _db = db;
        }

        protected async override Task Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            _db.Skills.Add(new Skill(request.Name));
            await _db.SaveChangesAsync();
        }
    }
}
