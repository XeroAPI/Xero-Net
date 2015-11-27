﻿using System.Collections.Generic;
using System.Linq;
using Xero.Api.Infrastructure.Model;

namespace Xero.Api.Infrastructure.Exceptions
{
    public class ValidationException
        : BadRequestException
    {
        public ValidationException(ApiException apiException)
            : base(apiException)
        {
            if (apiException.Elements != null && apiException.Elements.Any())
            {
                ValidationErrors = new List<ValidationError>();
                foreach (var ve in apiException
                    .Elements
                    .SelectMany(e => e.ValidationErrors))
                {
                    ValidationErrors.Add(ve);
                }
            }
        }

        public List<ValidationError> ValidationErrors { get; set; }

        public override string ToString()
        {
            return string.Join("\n", ValidationErrors.Select(p => p.Message));
        }
    }
}