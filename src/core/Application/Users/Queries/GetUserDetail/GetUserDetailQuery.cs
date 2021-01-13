﻿using System;
using MediatR;

namespace Application.Users.Queries.GetUser
{
    public class GetUserDetailQuery : IRequest<UserDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}