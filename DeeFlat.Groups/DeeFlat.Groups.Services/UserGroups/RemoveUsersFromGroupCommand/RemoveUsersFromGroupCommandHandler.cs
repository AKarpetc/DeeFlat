using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Groups.Services.UserGroups.RemoveUsersFromGroupCommand
{
    public class RemoveUsersFromGroupCommandHandler : BaseCommandHandler<RemoveUsersFromGroupCommand>
    {
        private readonly DeeFlatGroupDbContext _db;

        public RemoveUsersFromGroupCommandHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(RemoveUsersFromGroupCommand command, CancellationToken cancellationToken)
        {
            var userGroups = _db.UserGroups.Where(x =>
                x.GroupId == command.GroupId &&
                command.UserIds.Contains(x.UserId)
            );

            foreach (var userGroup in userGroups)
            {
                userGroup.IsDeleted = true;
            }

            await _db.SaveChangesAsync();
        }
    }
}
