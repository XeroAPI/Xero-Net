using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Infrastructure.Model;

namespace Xero.Api.Infrastructure.Exceptions
{
    [Serializable]
    public class ValidationException : BadRequestException
    {
        public List<ValidationExceptionError> Errors { get; set; }

        public ValidationException(ApiException apiException)
            : base(apiException)
        {
            if (apiException.Elements != null && apiException.Elements.Any())
            {
                Errors = apiException.Elements.Select(e => new ValidationExceptionError(e)).ToList();
            }
        }
    }
}