using Otc.DomainBase.Exceptions;
using System;

namespace Otc.Validations.Helpers
{
    [Obsolete("Use 'Otc.DomainBase.Exceptions.ModelValidationError' instead.")]
    public class ValidationError : ModelValidationError
    {
        public ValidationError(string key, string message) : base(key, message)
        {
        }
    }
}
