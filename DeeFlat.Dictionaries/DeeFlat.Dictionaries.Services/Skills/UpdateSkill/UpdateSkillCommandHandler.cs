using DeeFlat.Abstractions.Contracts;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Exceptions;
using DeeFlat.Dictionaries.Core.Domain;
using DeeFlat.Dictionaries.DataAccess.Data;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Skills.UpdateSkill
{
    public class UpdateSkillCommandHandler : BaseCommandHandler<UpdateSkillCommand>
    {
        private readonly DeeFlatDictDbContext _db;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateSkillCommandHandler(DeeFlatDictDbContext db, IPublishEndpoint publishEndpoint)
        {
            _db = db;
            _publishEndpoint = publishEndpoint;
        }

        protected async override Task Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = _db.Skills.Find(request.Id);

            if (skill == null)
            {
                throw new EntityIsNotFoundException("Навык для обновление не найден");
            }

            skill.Name = request.Name;

            await _db.SaveChangesAsync();

            await _publishEndpoint.Publish<ISkillMessage>(new SkillMessage
            {
                Name = request.Name,
                Id = request.Id
            });
        }
    }
}
