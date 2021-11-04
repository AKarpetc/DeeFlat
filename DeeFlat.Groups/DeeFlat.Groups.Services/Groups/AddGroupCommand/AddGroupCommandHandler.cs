using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using DeeFlat.Groups.Core.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Groups.Services.Groups.AddGroupCommand
{
    public class AddGroupCommandHandler : BaseCommandHandler<AddGroupCommand>
    {
        private readonly DeeFlatGroupDbContext _db;

        public AddGroupCommandHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(AddGroupCommand command, CancellationToken cancellationToken)
        {
            var group = new Group()
            {
                Name = command.Name,
                Code = command.Code,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                GroupStatusId = GroupStatuses.Complectation,
                Created = DateTime.Now
            };

            _db.Groups.Add(group);

            await _db.SaveChangesAsync();
        }
    }
}
