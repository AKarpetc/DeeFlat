using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Homework.Services.Producers
{
    public interface IHomeworkProducer
    {
        Task SendHomeworkAcceptedAsync(Guid courseId, Guid pupilId, Guid teacherId);
    }
}
