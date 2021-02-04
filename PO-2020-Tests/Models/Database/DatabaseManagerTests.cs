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
            try
            {
                manager.EditReviewStatus(100000, ThesisStatus.APPROVED);
                Assert.Fail();
            }
            catch
            {
            }
            try
            {
                manager.EditReviewStatus(1, ThesisStatus.DISCARD);
                FinalThesisReview review = manager.GetReview(1);
                Assert.IsTrue(review.FormStatus == ThesisStatus.DISCARD);
            }
            catch
            {
                Assert.Fail();
            }
            try
            {
                manager.EditReviewStatus(1, ThesisStatus.WAITING);
                FinalThesisReview review = manager.GetReview(1);
                Assert.IsTrue(review.FormStatus == ThesisStatus.WAITING);
            }
            catch
            {
                Assert.Fail();
            }
            try
            {
                manager.EditReviewStatus(1, ThesisStatus.APPROVED);
                FinalThesisReview review = manager.GetReview(1);
                Assert.IsTrue(review.FormStatus == ThesisStatus.APPROVED);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void EditQuestionTest()
        {
            DatabaseManager manager = new DatabaseManager();

            Question question = new Question();
            question.QuestionId = 1;
            question.Content = "Tresc";
            question.Answer = "Odp";

            FinalExam finalExam = new FinalExam();
            finalExam.ExamId = 1;
            question.FinalExams = finalExam;

            Assert.IsTrue(manager.EditQuestion(question));

            Assert.IsFalse(manager.EditQuestion(new Question()));
            Question incorrectQuestion = new Question();
            incorrectQuestion.QuestionId = -1;
            Assert.IsFalse(manager.EditQuestion(incorrectQuestion));
        }
    }
}