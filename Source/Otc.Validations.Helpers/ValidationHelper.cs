using System.Collections.Generic;
using Otc.ComponentModel.DataAnnotations;
using System.Linq;
using Otc.DomainBase.Exceptions;
using System;

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
            ThrowValidationExceptionIfNotValid(false, model);
        }

        public static void ThrowValidationExceptionIfNotValid(bool groupKeyErros, params object[] model)
        {
            if (model == null)
            {
                throw new System.ArgumentNullException(nameof(model));
            }

            var validationErrorResults = new List<ValidationResult>();

            for (int i = 0; i < model.Length; i++)
            {
                validationErrorResults.AddRange(GetErrosFromModel(model[i]));
            }

            var erros = GetAllModelValidationErrors(validationErrorResults, groupKeyErros);

            if (validationErrorResults.Any())
            {
                throw new ModelValidationException(erros.ToArray());
            }
        }

        private static IEnumerable<ModelValidationError> GetAllModelValidationErrors(List<ValidationResult> validationResults, bool groupKeyErros)
        {
            IEnumerable<ValidationResult> validationErrorResults = validationResults;

            if (groupKeyErros)
            {
                validationErrorResults = validationResults
                    .GroupBy(x => x.ErrorKey)
                    .Select(y => y.FirstOrDefault())
                    .Distinct();
            }

            return validationErrorResults
                .Select(e =>
                            new ModelValidationError(e.ErrorKey, e.ErrorMessage));
        }

        private static IEnumerable<ValidationResult> GetErrosFromModel(object model)
        {
            ModelValidator.TryValidate(model, out IEnumerable<ValidationResult> errors);
            return errors;
        }
    }
}
