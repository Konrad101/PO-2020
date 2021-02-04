using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Assert = NUnit.Framework.Assert;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database.Tests
{
    [TestClass()]
    public class DatabaseManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditReviewStatusTest()
        {
            DatabaseManager manager = new DatabaseManager();
            manager.EditReviewStatus(1, ThesisStatus.DISCARD);
        }

        /*
        [TestMethod()]
        public void EditReviewStatusTest()
        {
            DatabaseManager manager = new DatabaseManager();
            try
            {
                manager.EditReviewStatus(-1, ThesisStatus.APPROVED);
                Assert.Fail();
            }
            catch
            {
            }
            Thread.Sleep(500);
            try
            {
                manager.EditReviewStatus(100000, ThesisStatus.APPROVED);
                Assert.Fail();
            }
            catch
            {
            }
            Thread.Sleep(5000);
            try
            {
                manager.EditReviewStatus(1, ThesisStatus.DISCARD);
            }
            catch
            {
                Assert.Fail();
            }
            Thread.Sleep(500);
            try
            {
                manager.EditReviewStatus(1, ThesisStatus.WAITING);
            }
            catch
            {
                Assert.Fail();
            }
            Thread.Sleep(500);
            try
            {
                manager.EditReviewStatus(1, ThesisStatus.APPROVED);
            }
            catch
            {
                Assert.Fail();
            }           
        }
        */
    }
}