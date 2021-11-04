using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Exceptions;
using DeeFlat.Dictionaries.DataAccess.Data;
using DeeFlat.Groups.Core.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Groups.Services.Groups.RemoveGroupCommand
{
    public class RemoveGroupCommandHandler : BaseCommandHandler<RemoveGroupCommand>
    {
        private readonly DeeFlatGroupDbContext _db;

        public RemoveGroupCommandHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(RemoveGroupCommand command, CancellationToken cancellationToken)
        {
            var group = _db.Groups.SingleOrDefault(x => x.Id == command.GroupId);

            if (group == null)
                throw new EntityIsNotFoundException("Группа не найдена!");

            if (group.GroupStatusId >= GroupStatuses.Teaching)
                throw new InvalidOperationException("Курс в текущем статусе не может быть удален!");

            group.IsDeleted = true;

            await _db.SaveChangesAsync();
        }
    }
}
