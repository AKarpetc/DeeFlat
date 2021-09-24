using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.UpdateUser
{
    public class UpdateUserCommandHandler : BaseCommandHandler<UpdateUserCommand>
    {
        protected override Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
