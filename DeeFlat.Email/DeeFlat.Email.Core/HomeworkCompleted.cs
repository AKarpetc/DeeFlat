using DeeFlat.Abstractions.Contracts;
using System;
using System.Collections.Generic;

namespace DeeFlat.Email.WebHost.Controllers
{
    public class HomeworkCompleted : IHomeworkCompleted
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Subject { get; set; }

        public IEnumerable<string> To { get; set; }
    }
}
