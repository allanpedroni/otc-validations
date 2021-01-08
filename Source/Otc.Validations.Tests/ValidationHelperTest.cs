using Otc.DomainBase.Exceptions;
using Otc.Validations.Helpers;
using Otc.Validations.Tests.Data;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Otc.Validations.Tests
{
    public class ValidationHelperTest
    {
        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithOneParameter()
        {
            Model model = new() {
                D = new string[] { "testando" },
                SubClasses= new List<SubClass>()
                {
                    new SubClass() { Nome = "A" },
                    new SubClass() { Nome = "B" },
                    new SubClass() { Nome = "C" },
                }
            };

            //TODO: Ajustar a lista pois não está pegando o valor, por exemplo, Name da lista, vindo sempre null
            ValidationHelper.ThrowValidationExceptionIfNotValid(false, model);
        }

        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithMoreThanOneParameter()
        {
            Model modelA = new() { SubClass = new SubClass() { Nome = "t" }, D = new string[] { "testando" } };
            Model modelB = new() { SubClass = null };

            var error = Assert.ThrowsAny<ModelValidationException>(() =>
            {
                ValidationHelper.ThrowValidationExceptionIfNotValid(modelA, modelB);
            });

            Assert.Contains("FieldD", error.Errors.FirstOrDefault().Key);

        }

        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithOneParameter_ArgumentNullException()
        {
            Assert.ThrowsAny<ArgumentNullException>(() =>
            {
                Model model = null;
                ValidationHelper.ThrowValidationExceptionIfNotValid(model);
            });
        }

        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithMoreThanOneParameter_ArgumentNullException()
        {
            Assert.ThrowsAny<ArgumentNullException>(() =>
            {
                Model modelA = null;
                Model modelB = null;

                ValidationHelper.ThrowValidationExceptionIfNotValid(modelA, modelB);
            });
        }

        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithOneParameter_ModelValidationException()
        {
            Assert.ThrowsAny<ModelValidationException>(() =>
            {
                var model = new Model();
                ValidationHelper.ThrowValidationExceptionIfNotValid(model);
            });
        }

        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithMoreThanOneParameter_ModelValidationException()
        {
            Assert.ThrowsAny<ModelValidationException>(() =>
            {
                var modelA = new Model();
                var modelB = new Model();

                ValidationHelper.ThrowValidationExceptionIfNotValid(modelA, modelB);
            });
        }
    }
}
