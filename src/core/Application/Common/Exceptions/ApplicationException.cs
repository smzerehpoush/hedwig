using System;
using System.Net;
using Domain.Shared.Exceptions;

namespace Application.Common.Exceptions
{
    public class ApplicationException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
    
        public ResultStatus ResultStatus{ get; private set;}

        public ApplicationException(HttpStatusCode statusCode, ResultStatus resultStatus)
        {
            StatusCode = statusCode;
            ResultStatus = resultStatus;
        }

        public ApplicationException(HttpStatusCode statusCode, ResultStatus resultStatus, string? message) : base(message)
        {
            StatusCode = statusCode;
            ResultStatus = resultStatus;
        }

        public ApplicationException(HttpStatusCode statusCode, ResultStatus resultStatus, string? message,
            Exception? innerException) : base(message,
            innerException)
        {
            StatusCode = statusCode;
            ResultStatus = resultStatus;
        }
    }
}