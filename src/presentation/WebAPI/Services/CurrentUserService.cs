using System;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            //todo get user id fom token
            UserId = Guid.NewGuid();
            IsAuthenticated = UserId != null;
        }

        public Guid UserId { get; }

        public bool IsAuthenticated { get; }
    }
}