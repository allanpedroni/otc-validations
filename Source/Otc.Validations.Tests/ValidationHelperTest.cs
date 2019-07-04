using Otc.DomainBase.Exceptions;
using Otc.Validations.Helpers;
using Otc.Validations.Tests.Data;
using System;
using System.Collections.Generic;
using Xunit;

namespace Otc.Validations.Tests
{
    public class ValidationHelperTest
    {
        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithOneParameter()
        {
            var model = new Model() { SubClass = new SubClass() };

            ValidationHelper.ThrowValidationExceptionIfNotValid(model);
        }

        [Fact]
        public void ThrowValidationExceptionIfNotValid_WithMoreThanOneParameter()
        {
            var modelA = new Model() { SubClass = new SubClass() };
            var modelB = new Model() { SubClass = new SubClass() };

            ValidationHelper.ThrowValidationExceptionIfNotValid(modelA, modelB);
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
