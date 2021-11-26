using DeeFlat.Abstractions.Contracts;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Consumers
{
    public class SkillMessageIS4Consumer : IConsumer<ISkillMessage>
    {
        private readonly IRepository<UserSkill> _userRepository;
        public SkillMessageIS4Consumer(IRepository<UserSkill> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Consume(ConsumeContext<ISkillMessage> context)
        {
            var skill = context.Message;

            var userSkills = await _userRepository.GetWhereAsync(x => x.SkilId == skill.Id);

            foreach (var userSkill in userSkills)
            {
                userSkill.SkilName = skill.Name;
            }

            await _userRepository.SaveAsync();

        }
    }
}
