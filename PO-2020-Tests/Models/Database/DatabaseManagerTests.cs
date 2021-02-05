using PO_implementacja_StudiaPodyplomowe.Models.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assert = NUnit.Framework.Assert;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database.Tests
{
    [TestClass()]
    public class DatabaseManagerTests
    {
        [TestMethod()]
        public void EditReviewStatusTest()
        {
            IDao manager = new DatabaseManager();
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
            IDao manager = new DatabaseManager();

            Question question = new Question();
            question.QuestionId = 1;
            question.Content = "Tresc";
            question.Answer = "Odp";

            FinalExam finalExam = new FinalExam();
            finalExam.ExamId = 1;
            question.FinalExams = finalExam;
            Assert.IsTrue(manager.EditQuestion(question));

            Question incompleteQuestion = new Question();

            try
            {
                manager.EditQuestion(new Question());
                Assert.Fail();
            }
            catch (NullReferenceException) { }

            incompleteQuestion.QuestionId = 1;
            finalExam.ExamId = -1;
            incompleteQuestion.FinalExams = finalExam;
            try
            {
                manager.EditQuestion(incompleteQuestion);
                Assert.Fail();
            } catch (ArgumentException) { }

            Question incorrectQuestion = new Question();
            incorrectQuestion.QuestionId = -1;
            try
            {
                manager.EditQuestion(incorrectQuestion);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }

        [TestMethod()]
        public void EditSubmissionThesisTest()
        {
            IDao dao = new DatabaseManager();

            SubmissionThesis submission = new SubmissionThesis();
            submission.SubmissionId = 1;
            submission.ThesisTopic = "Tresc";
            submission.TopicNumber = 2;
            submission.ThesisObjectives = "Cele pracy";
            submission.ThesisScope = "Cele pracy";
            submission.Status = ThesisStatus.APPROVED;
            FinalThesis finalThesis = new FinalThesis();
            finalThesis.FinalThesisId = 1;
            submission.FinalThesis = finalThesis;
            Edition edition = new Edition();    
            edition.Number = 1;
            submission.Edition = edition;

            Assert.IsTrue(dao.EditSubmissionThesis(submission));

            submission.SubmissionId = 100000;
            Assert.IsFalse(dao.EditSubmissionThesis(submission));

            try
            {
                SubmissionThesis incorrectSubmission = new SubmissionThesis();
                incorrectSubmission.SubmissionId = -1;
                dao.EditSubmissionThesis(incorrectSubmission);
                Assert.Fail();
            }
            catch (ArgumentException) { }

            try
            {
                submission.FinalThesis.FinalThesisId = -1;
                dao.EditSubmissionThesis(submission);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
    }
}