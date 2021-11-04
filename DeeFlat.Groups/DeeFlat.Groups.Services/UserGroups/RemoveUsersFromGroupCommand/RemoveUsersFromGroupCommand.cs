using DeeFlat.Abstractions.CQRS;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DeeFlat.Groups.Services.UserGroups.RemoveUsersFromGroupCommand
{
    public class RemoveUsersFromGroupCommand : ICommand
    {
        public Guid GroupId { get; set; }

        public List<Guid> UserIds { get; set; }
    }

    public class RemoveUsersFromGroupCommandValidator : AbstractValidator<RemoveUsersFromGroupCommand>
    {
        public RemoveUsersFromGroupCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserIds).NotEmpty().ForEach(x => x.NotEmpty().NotEqual(Guid.Empty));
        }
    }
}
