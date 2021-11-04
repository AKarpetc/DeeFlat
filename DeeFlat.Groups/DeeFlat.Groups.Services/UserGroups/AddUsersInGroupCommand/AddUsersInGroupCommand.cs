using DeeFlat.Abstractions.CQRS;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DeeFlat.Groups.Services.UserGroups.AddUsersInGroupCommand
{
    public class AddUsersInGroupCommand : ICommand
    {
        public Guid GroupId { get; set; }

        public List<Guid> UserIds { get; set; }
    }

    public class AddUsersInGroupCommandValidator : AbstractValidator<AddUsersInGroupCommand>
    {
        public AddUsersInGroupCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserIds).NotEmpty().ForEach(x => x.NotEmpty().NotEqual(Guid.Empty));
        }
    }
}
