using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Lecturer
{
    public class LecturerFinalThesisListController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            IDao dao = new DatabaseManager();
            FinalThesisReview review = dao.GetReview(id);
            string title = "THESIS TITLE";
            ViewBag.thesisTitle = title;
            ViewBag.name = "imieeeee";
            ViewBag.surname = "nazwisko_student";
            
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection form)
        {
            FinalThesisReview review = new FinalThesisReview();
            review.FormId = id;
            review.TitleCompability = form["TitleCompability"];
            review.ThesisStructureComment = form["ThesisStructureComment"];
            review.NewProblem = form["NewProblem"];
            review.SourcesUse = form["SourcesUse"];
            review.FormalWorkSide = form["FormalWorkSide"];
            review.WayToUse = form["WayToUse"];
            review.SubstantiveThesisGrade = form["SubstantiveThesisGrade"];
            review.ThesisGrade = form["ThesisGrade"];
            review.FormDate = DateTime.Parse(form["FormDate"]);

            manager.EditReview(review);
            Console.WriteLine("ID: " + review.FormId);
            Console.WriteLine("Title compability: " + review.TitleCompability);
            Console.WriteLine("Grade " + review.ThesisGrade);

            return RedirectToAction("Index");
        }
    }
}
