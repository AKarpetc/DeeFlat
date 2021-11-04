using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Exceptions;
using DeeFlat.Dictionaries.DataAccess.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Groups.Services.Groups.ChangeGroupStatusCommand
{
    public class ChangeGroupStatusCommandHandler : BaseCommandHandler<ChangeGroupStatusCommand>
    {
        private readonly DeeFlatGroupDbContext _db;

        public ChangeGroupStatusCommandHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(ChangeGroupStatusCommand command, CancellationToken cancellationToken)
        {
            var group = _db.Groups.SingleOrDefault(x => x.Id == command.GroupId);

            if (group == null)
                throw new EntityIsNotFoundException("Группа не найдена!");

            if (group.GroupStatusId >= command.GroupsStatusId)
            {
                throw new InvalidOperationException("Переход в данный статус запрещен!");
            }

            group.GroupStatusId = command.GroupsStatusId;

            await _db.SaveChangesAsync();
        }
    }
}
