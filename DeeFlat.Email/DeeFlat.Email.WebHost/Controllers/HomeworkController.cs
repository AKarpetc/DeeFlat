using DeeFlat.Abstractions.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeeFlat.Email.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public HomeworkController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task GetHomeworkCompleted()
        {
            await _publishEndpoint.Publish<IHomeworkCompleted>(new HomeworkCompleted()
            {
                Id = Guid.Empty,
                Name = "Тестовое домашнее задание",
                Date = DateTime.Now,
                Subject = "Тест",
                To = new List<string>() { "test@gmail.com", "test2@gmail.com" }
            });
        }
    }
}
