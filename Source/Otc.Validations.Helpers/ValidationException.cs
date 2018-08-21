using Otc.DomainBase.Exceptions;
using System;
using System.Linq;

namespace Otc.Validations.Helpers
{
    [Obsolete("Use 'Otc.DomainBase.Exceptions.ModelValidationException' instead.")]
    public class ValidationException : ModelValidationException
    {
        public ValidationException() : base()
        {
        }

        public ValidationException(params ValidationError[] errors) 
            : base(errors.Cast<ModelValidationError>().ToArray())
        {
        }
    }
}
