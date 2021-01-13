using System;
using System.Linq;
using System.Net;
using Domain.Shared.Exceptions;

namespace Application.Common.Exceptions
{
    public class NotFoundException : ServiceException
    {
        public NotFoundException(ResultStatus resultStatus, string? message)
            : base(HttpStatusCode.NotFound, resultStatus, message + " Not Found.")
        {
        }
    }
}