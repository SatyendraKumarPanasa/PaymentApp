using System.Collections.Generic;
using System.Linq;

namespace dCaf.Core
{
#nullable disable
    public class Response<T> 
    {
        public Response()
        {
        }

        public Response(IDictionary<string, string[]> errors)
        {
            Errors = errors;
        }

        public T Result { get; set; }

        public IDictionary<string, string[]> Errors { get; set; }

        public void AddError(string errorCode, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                return;
            }
            AddError(errorCode, new string[] { errorMessage });
        }

        public void AddError(string errorCode, string[] errorMessages)
        {
            var filteredErrorMessages = errorMessages?.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            if(filteredErrorMessages == null || filteredErrorMessages.Any() == false)
            {
                return;
            }

            if (Errors == null)
            {
                Errors = new Dictionary<string, string[]>();
            }

            if (Errors.ContainsKey(errorCode))
            {
                var errors = Errors[errorCode].ToList();
                errors.AddRange(filteredErrorMessages);
                Errors[errorCode] = errors.ToArray();
            }
            else
            {
                Errors.Add(errorCode, filteredErrorMessages.ToArray());
            }
        }

    }
#nullable enable
}
