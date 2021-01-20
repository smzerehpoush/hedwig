using System;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Guid.NewGuid();
            IsAuthenticated = UserId != null;
        }

        public Guid UserId { get; }

        public bool IsAuthenticated { get; }
    }
}