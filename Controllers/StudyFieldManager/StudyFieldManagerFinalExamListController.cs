using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.StudyFieldManager
{
    public class StudyFieldManagerFinalExamListController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();
        private static int examId;

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Edit(int id)
        {
            examId = id;
            return View();
        }

        public IActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddQuestion(IFormCollection form)
        {
            Question question = new Question();
            question.QuestionId = manager.GetMaxQuestionId();
            question.Content = form["Content"];
            question.Points = int.Parse(form["Points"]);
            question.Answer = form["Answer"];
            FinalExam finalExam = new FinalExam();
            finalExam.ExamId = examId;
            question.FinalExams = finalExam;

            manager.AddQuestion(question);

            return RedirectToAction("Index");
        }

        public IActionResult EditQuestion(int id)
        {
            Console.WriteLine("Edit, ID: " + id);
            IDao dao = new DatabaseManager();
            Question question = dao.GetQuestion(id);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuestion(int id, IFormCollection form)
        {
            Question question = new Question();
            question.QuestionId = id;
            question.Content = form["Content"];
            question.Points = int.Parse(form["Points"]);
            question.Answer = form["Answer"];

            manager.EditQuestion(question);
            Console.WriteLine("ID: " + question.QuestionId);
            Console.WriteLine("Points: " + question.Points);
            Console.WriteLine("IDAnswer " + question.Answer);

            return RedirectToAction("Index");
        }
    }
}
