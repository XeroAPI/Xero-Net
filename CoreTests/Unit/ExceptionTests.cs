using System.Collections.Generic;
using NUnit.Framework;
using Xero.Api.Infrastructure.Exceptions;
using Xero.Api.Infrastructure.Model;

namespace CoreTests.Unit
{
    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        public void ManageNullValidationErrorsInApiException()
        {
            var validationException = new ValidationException(ApiException);
            Assert.That(validationException.ValidationErrors, Has.Count.EqualTo(5));
        }

        private ApiException ApiException
        {
            get
            {
                return new ApiException
                {
                    Elements = new List<DataContractBase>
                    {
                        new DataContractBase
                        {
                            ValidationErrors = new List<ValidationError>
                            {
                                new ValidationError {Message = "Validation Error 1"}
                            }
                        },
                        new DataContractBase
                        {
                            ValidationErrors = new List<ValidationError>
                            {
                                new ValidationError {Message = "Validation Error 2"}
                            }
                        },
                        new DataContractBase
                        {
                            ValidationErrors = new List<ValidationError>
                            {
                                new ValidationError {Message = "Validation Error 3"}
                            }
                        },
                        new DataContractBase
                        {
                            ValidationErrors = new List<ValidationError>
                            {
                                new ValidationError {Message = "Validation Error 4"}
                            }
                        },
                        new DataContractBase
                        {
                            ValidationErrors = new List<ValidationError>
                            {
                                new ValidationError {Message = "Validation Error 5"}
                            }
                        },
                        new DataContractBase
                        {
                            ValidationErrors = null // this is a valid data condition for large responses
                        }
                    }
                };
            }
        }
    }
}