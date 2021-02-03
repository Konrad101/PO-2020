using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using PO_implementacja_StudiaPodyplomowe.Models.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO_implementacja_StudiaPodyplomowe.Models.Validators.Tests
{
    [TestClass()]
    public class DataValidatorTests
    {
        [TestMethod()]
        public void DateIsValidTest()
        {
            Assert.IsTrue(DataValidator.DateIsValid("31-01-2020"));
            Assert.IsFalse(DataValidator.DateIsValid("32.01.2020"));
            Assert.IsTrue(DataValidator.DateIsValid("31.01.2020"));
            Assert.IsFalse(DataValidator.DateIsValid("29.02.2021"));
            Assert.IsFalse(DataValidator.DateIsValid("01.02.2023"));
        }


        [TestMethod()]
        public void NumberIsValidTest()
        {
            Assert.IsFalse(DataValidator.NumberIsValid(""));
            Assert.IsFalse(DataValidator.NumberIsValid(" "));
        }
    }
}