using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Exceptions;
using DeeFlat.Dictionaries.DataAccess.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Groups.Services.Groups.EditGroupCommand
{
    public class EditGroupCommandHandler : BaseCommandHandler<EditGroupCommand>
    {
        private readonly DeeFlatGroupDbContext _db;

        public EditGroupCommandHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(EditGroupCommand command, CancellationToken cancellationToken)
        {
            var group = _db.Groups.SingleOrDefault(x => x.Id == command.Id);

            if (group == null)
                throw new EntityIsNotFoundException("Группа не найдена!");

            group.Name = command.Name;
            group.Code = command.Code;
            group.StartDate = command.StartDate;
            group.EndDate = command.EndDate;

            await _db.SaveChangesAsync();
        }
    }
}
