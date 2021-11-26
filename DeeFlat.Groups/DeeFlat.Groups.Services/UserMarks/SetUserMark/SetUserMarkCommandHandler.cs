using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using DeeFlat.Groups.Core.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Groups.Services.UserMarks.SetUserMark
{
    public class SetUserMarkCommandHandler : BaseCommandHandler<SetUserMarkCommand>
    {
        private readonly DeeFlatGroupDbContext _db;

        public SetUserMarkCommandHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(SetUserMarkCommand command, CancellationToken cancellationToken)
        {
            var userMark = _db.UserMarks.SingleOrDefault(x =>
                x.CourseActivityId == command.CourseActivityId &&
                x.UserGroupId == command.UserGroupId
                );

            if (userMark == null)
            {
                userMark = new UserMark()
                {
                    UserGroupId = command.UserGroupId,
                    CourseActivityId = command.CourseActivityId,
                    Comment = command.Comment,
                    Mark = command.Mark,
                    Created = DateTime.Now
                };

                _db.UserMarks.Add(userMark);
            }
            else
            {
                userMark.Comment = command.Comment;
                userMark.Mark = command.Mark;
            }

            await _db.SaveChangesAsync();
        }
    }
}
