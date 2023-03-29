using System.Collections;
using System.Collections.Generic;

namespace TatBlog.WebApi.Models
{
    public class ValidationFailureResponse
    {
        public IEnumerable Errors { get; set; }
        public ValidationFailureResponse(
            IEnumerable<string> errorMessages)
        {
            Errors = errorMessages;
        }

        
    }
}
