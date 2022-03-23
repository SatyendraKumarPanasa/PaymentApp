using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Api
{
    public class ValidationProblemDetailsExample : IExamplesProvider<ValidationProblemDetails>
    {
        public ValidationProblemDetails GetExamples()
        {
            var errors = new Dictionary<string, string[]>
            {
                { "FieldName1", new string[] { "FieldName1 is required." } },
                { "FieldName2", new string[] { "The field FieldName2 must be a string with a maximum length of 20." } },
            };

            return new ValidationProblemDetails(errors)
            {
                Type = "https://httpstatuses.com/422",
                Title = "One or more model validation errors occurred.",
                Status = 422,
                Detail = "See the errors property for details.",
                Instance = "Endpoint Name",
            };
        }
    }
}
