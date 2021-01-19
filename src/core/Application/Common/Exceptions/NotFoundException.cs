using System;
using System.Linq;
using System.Net;
using Domain.Shared.Exceptions;

namespace Application.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(ResultStatus resultStatus, string? item)
            : base(HttpStatusCode.NotFound, resultStatus, item + " Not Found.")
        {
        }
    }
}