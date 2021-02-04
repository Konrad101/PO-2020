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
            Assert.IsFalse(DataValidator.DateIsValid("16.05.2081"));
            Assert.IsTrue(DataValidator.DateIsValid("2020-04-16"));
            Assert.IsTrue(DataValidator.DateIsValid("2018.11-25"));
            Assert.IsTrue(DataValidator.DateIsValid("19-05-2001"));
            Assert.IsFalse(DataValidator.DateIsValid("32.01.2020"));
            Assert.IsTrue(DataValidator.DateIsValid("31.01.2020"));
            Assert.IsFalse(DataValidator.DateIsValid("29.02.2021"));
            Assert.IsFalse(DataValidator.DateIsValid("01.02.2023"));
            Assert.IsFalse(DataValidator.DateIsValid("30.02.2023"));
            Assert.IsFalse(DataValidator.DateIsValid("00.02.2020"));
            Assert.IsFalse(DataValidator.DateIsValid("01.01.1800"));
            Assert.IsFalse(DataValidator.DateIsValid(""));
            Assert.IsFalse(DataValidator.DateIsValid(" "));
            Assert.IsFalse(DataValidator.DateIsValid("WpisujeString"));
            Assert.IsFalse(DataValidator.DateIsValid("232"));
            Assert.IsFalse(DataValidator.DateIsValid("232.12"));
            Assert.IsFalse(DataValidator.DateIsValid(true.ToString()));
        }


        [TestMethod()]
        public void NumberIsValidTest()
        {
            Assert.IsFalse(DataValidator.NumberIsValid(""));
            Assert.IsFalse(DataValidator.NumberIsValid(" "));
            Assert.IsFalse(DataValidator.NumberIsValid("Szczegóły pytania"));
            Assert.IsFalse(DataValidator.NumberIsValid("123 pytania"));
            Assert.IsTrue(DataValidator.NumberIsValid("123"));
            Assert.IsFalse(DataValidator.NumberIsValid("123.2"));
            Assert.IsFalse(DataValidator.NumberIsValid("123.2f"));
            Assert.IsTrue(DataValidator.NumberIsValid("-203"));
            Assert.IsFalse(DataValidator.NumberIsValid("514415214752485214896258962148624851"));
            Assert.IsFalse(DataValidator.NumberIsValid("-57852147852147852148962145896258"));
        }

        [TestMethod()]
        public void FieldContentIsValidTest()
        {
            Assert.IsTrue(DataValidator.FieldContentIsValid("123 pytania"));
            Assert.IsFalse(DataValidator.FieldContentIsValid(""));
            Assert.IsFalse(DataValidator.FieldContentIsValid(" "));
            Assert.IsFalse(DataValidator.FieldContentIsValid("     "));
            Assert.IsTrue(DataValidator.FieldContentIsValid("Sara"));
            Assert.IsTrue(DataValidator.FieldContentIsValid("adamandy"));
            Assert.IsTrue(DataValidator.FieldContentIsValid("YOLO"));
            Assert.IsTrue(DataValidator.FieldContentIsValid("21321234"));
            Assert.IsTrue(DataValidator.FieldContentIsValid("Sasa21"));
            Assert.IsFalse(DataValidator.FieldContentIsValid("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", maxLength:20));
            Assert.IsTrue(DataValidator.FieldContentIsValid("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", maxLength:500));
            try
            {
                DataValidator.FieldContentIsValid("sda", maxLength: -20);
                Assert.Fail();

            }
            catch (ArgumentException)
            {
            }
            try
            {
                DataValidator.FieldContentIsValid("sda", maxLength: Int32.MinValue);
                Assert.Fail();

            }
            catch (ArgumentException)
            {
            }
            try
            {
                DataValidator.FieldContentIsValid("sda", maxLength: 0);
                Assert.Fail();

            }
            catch (ArgumentException)
            {
            }
            try
            {
                DataValidator.FieldContentIsValid("sda", maxLength: 256);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            try
            {
                DataValidator.FieldContentIsValid("sda", maxLength: Int32.MaxValue);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

    }
}