using System.Collections.Generic;
using Otc.ComponentModel.DataAnnotations;
using System.Linq;
using Otc.DomainBase.Exceptions;

namespace Otc.Validations.Helpers
{
    public class ValidationHelper
    {
        /// <summary>
        /// Valida as propriedades do modelo informado e dispara uma ValidationException caso não seja valido.
        /// </summary>
        /// <typeparam name="T">Tipo do modelo que sera validado</typeparam>
        /// <param name="model">Instancia do modelo que sera validado</param>
        /// <exception cref="ModelValidationException" />
        public static void ThrowValidationExceptionIfNotValid(params object[] model)
        {
            if (model == null)
            {
                throw new System.ArgumentNullException(nameof(model));
            }

            for (int i = 0; i < model.Length; i++)
            {
                ValidateModel(model[i]);
            }
        }

        private static void ValidateModel(object model)
        {
            if (!ModelValidator.TryValidate(model, out IEnumerable<ValidationResult> errors))
            {
                throw new ModelValidationException(
                    errors.Select(e =>
                        new ModelValidationError(e.ErrorKey, e.ErrorMessage)).ToArray());
            }
        }
    }
}
