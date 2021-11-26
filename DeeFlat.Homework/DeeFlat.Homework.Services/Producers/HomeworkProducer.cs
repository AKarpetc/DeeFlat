using DeeFlat.Homework.Services.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace DeeFlat.Homework.Services.Producers
{
    public class HomeworkProducer : IHomeworkProducer
    {
        readonly IBus _bus;
        public HomeworkProducer(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendHomeworkAcceptedAsync(Guid courseId, Guid pupilId, Guid teacherId)
        {
            var message = new HomeworkAccepted(courseId, pupilId, teacherId);

            await _bus.Publish(message);
        }
    }
}
