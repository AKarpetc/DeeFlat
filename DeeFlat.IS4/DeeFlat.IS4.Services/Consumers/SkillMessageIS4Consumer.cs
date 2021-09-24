using DeeFlat.Abstractions.Contracts;
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
        public async Task Consume(ConsumeContext<ISkillMessage> context)
        {
            //Обновить название всех навыков у пользователей которые обновились

        }
    }
}
