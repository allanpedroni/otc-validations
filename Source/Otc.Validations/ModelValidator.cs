using System;
using System.Collections.Generic;
using Otc.ComponentModel.DataAnnotations;

namespace Otc.Validations
{
    /// <summary>
    /// Classe para validação das propriedades de um modelo baseado no DataAnnotations
    /// </summary>
    public static class ModelValidator
    {
        /// <summary>
        /// Valida as propriedades do modelo informado
        /// </summary>
        /// <typeparam name="T">Tipo do modelo que será validado</typeparam>
        /// <param name="model">Instância do modelo que será validado</param>
        /// <returns>Retorna verdadeiro quando todas as propriedades estiverem válidas e falso quando ao menos uma propriedade estiver inválida</returns>
        public static bool IsValid<T>(T model)
        {
            return TryValidate(model, out _);
        }

        /// <summary>
        /// Valida as propriedades do modelo informado
        /// </summary>
        /// <typeparam name="T">Tipo do modelo que será validado</typeparam>
        /// <param name="model">Instância do modelo que será validado</param>
        /// <param name="errors">IEnumerable de System.ComponentModel.DataAnnotations.ValidationResult com as mensagens de erro de validação de cada propriedade inválida</param>
        /// <returns>Retorna verdadeiro quando todas as propriedades estiverem válidas e falso quando ao menos uma propriedade estiver inválida</returns>
        public static bool TryValidate<T>(T model, out IEnumerable<ValidationResult> errors)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            errors = validationResults;
            return isValid;
        }
    }
}