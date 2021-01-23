﻿using System;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid? UserId { get; set; }
    }
}