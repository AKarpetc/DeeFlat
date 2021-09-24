using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.AddUserComand
{
    public class AddUserCommandHandler : BaseCommandHandler<AddUserCommand>
    {
        protected override async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
