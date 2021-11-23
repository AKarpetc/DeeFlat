using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using DeeFlat.Groups.Core.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Groups.Services.UserGroups.AddUsersInGroupCommand
{
    public class AddUsersInGroupCommandHandler : BaseCommandHandler<AddUsersInGroupCommand>
    {
        private readonly DeeFlatGroupDbContext _db;

        public AddUsersInGroupCommandHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(AddUsersInGroupCommand command, CancellationToken cancellationToken)
        {
            var userGroups = command.UserIds.Select(userId => new UserGroup()
            {
                GroupId = command.GroupId,
                UserId = userId,
                Created = DateTime.Now
            });

            _db.UserGroups.AddRange(userGroups);

            await _db.SaveChangesAsync();
        }
    }
}
