using System;
using Application.Common.Exceptions;
using Domain.Shared.Exceptions;

namespace Application.Users.Commands.DeleteUser
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid id) : base(ResultStatus.UserNotFound, $"user with UserId {id}")
        {
        }
    }
}