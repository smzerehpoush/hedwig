using System;
using System.Net;
using Domain.Shared.Exceptions;

namespace Application.Common.Exceptions
{
    public class BadRequestException : ServiceException
    {
        private ResultStatus _resultStatus;

        public BadRequestException(string message, ResultStatus resultStatus)
            : base(HttpStatusCode.BadRequest, resultStatus, message)
        {
            _resultStatus = resultStatus;
        }
    }
}