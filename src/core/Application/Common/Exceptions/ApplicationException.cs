using System;
using System.Net;
using Domain.Shared.Exceptions;

namespace Application.Common.Exceptions
{
    public class ApplicationException : Exception
    {
        private readonly HttpStatusCode _statusCode;
        private readonly ResultStatus _resultStatus;

        public ApplicationException(HttpStatusCode statusCode, ResultStatus resultStatus)
        {
            _statusCode = statusCode;
            _resultStatus = resultStatus;
        }

        public ApplicationException(HttpStatusCode statusCode, ResultStatus resultStatus, string? message) : base(message)
        {
            _statusCode = statusCode;
            _resultStatus = resultStatus;
        }

        public ApplicationException(HttpStatusCode statusCode, ResultStatus resultStatus, string? message,
            Exception? innerException) : base(message,
            innerException)
        {
            _statusCode = statusCode;
            _resultStatus = resultStatus;
        }
    }
}