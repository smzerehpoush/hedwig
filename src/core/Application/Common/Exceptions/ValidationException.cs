using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Domain.Shared.Exceptions;
using FluentValidation.Results;

namespace Application.Common.Exceptions
{
    //The 422 (Unprocessable Entity) status code means the server understands the content type of the request entity
    //(hence a 415 (Unsupported Media Type) status code is inappropriate),
    //and the syntax of the request entity is correct
    //(thus a 400 (Bad Request) status code is inappropriate) but was unable to process the contained instructions.
    public class ValidationException : ServiceException
    {
        public ValidationException()
            : base(HttpStatusCode.UnprocessableEntity, ResultStatus.ValidationError,
                "One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}