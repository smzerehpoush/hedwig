using System;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        Guid IsAuthenticated { get; }
    }
}