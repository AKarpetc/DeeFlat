using DeeFlat.Core.Abstractions;
using DeeFlat.Core.Domain;
using DeeFlat.DataAccess.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Services.Courses.AddCourseCommand
{
    public class AddCourseCommandHandler : BaseCommandHandler<AddCourseCommand>
    {
        private readonly DeeFlatDBContext _db;

        public AddCourseCommandHandler(DeeFlatDBContext db)
        {
            _db = db;
        }

        protected override async Task Handle(AddCourseCommand command, CancellationToken cancellationToken)
        {
            var course = new Course()
            {
                Name = command.Name,
                Description = command.Description,
                StatusId = CourseStatuses.New
            };

            _db.Course.Add(course);
            await _db.SaveChangesAsync();
        }
    }
}
