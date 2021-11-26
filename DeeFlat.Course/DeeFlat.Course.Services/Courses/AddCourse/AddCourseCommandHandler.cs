using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Exceptions;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.Course.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBCource = DeeFlat.Course.Core.Domain.Course;

namespace DeeFlat.Course.Services.Courses.AddCourse
{
    public class AddCourseCommandHandler : BaseCommandHandler<AddCourseCommand>
    {
        IRepository<DBCource> _repository;
        public AddCourseCommandHandler(IRepository<DBCource> repository)
        {
            _repository = repository;
        }

        protected async override Task Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {

            if (!Enum.IsDefined(typeof(CourseStatuses), request.Status))
            {
                throw new EntityIsNotFoundException("Статуса не существует");
            }

            await _repository.CreateAsync(new DBCource
            {
                Name = request.Name,
                Status = request.Status,
                Description = request.Description
            });
        }
    }
}
