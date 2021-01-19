using System;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public class UserDeletedNotification : INotification
    {
        public Guid UserId { get; set; }
    }
}