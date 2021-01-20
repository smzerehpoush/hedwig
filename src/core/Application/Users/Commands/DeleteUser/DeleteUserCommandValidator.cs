using System;
using FluentValidation;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.UserId).NotNull().NotEmpty();
            RuleFor(v => v.UserId).NotEqual(Guid.Empty);
        }
    }
}