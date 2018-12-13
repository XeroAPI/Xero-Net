using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xero.Api.Infrastructure.Model
{
    public class ValidationExceptionError
    {
        public string Reference { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }

        public ValidationExceptionError(DataContractBase element)
        {
            if (element.ValidationErrors != null)
                ValidationErrors = element.ValidationErrors;
            Reference = element.Reference;
        }
    }

}
