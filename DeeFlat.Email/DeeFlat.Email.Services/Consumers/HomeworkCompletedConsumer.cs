using DeeFlat.Abstractions.Contracts;
using DeeFlat.Email.Services.Services;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace DeeFlat.Email.Services.Consumers
{
    public class HomeworkCompletedConsumer : BaseEmailConsumer, IConsumer<IHomeworkCompleted>
    {
        public readonly IEmailService _emailService;

        public HomeworkCompletedConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Consume(ConsumeContext<IHomeworkCompleted> context)
        {
            try
            {
                var message = context.Message;

                string body = Render(context.Message);

                await _emailService.SendEmailAsync(message.To, message.Subject, body);
            }
            catch (Exception ex)
            {
                //TODO: Добавить логирование
                throw;
            }
        }
    }
}
