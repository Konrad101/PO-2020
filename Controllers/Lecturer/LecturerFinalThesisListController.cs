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
            List<FinalThesisReview> reviews = manager.GetReviews(1);
            return View(reviews);
        }

        public IActionResult Confirm(int id)
        {
            manager.EditReviewStatus(id, (int)ThesisStatus.APPROVED);
            return RedirectToAction("Index");
        }

        public IActionResult Discard(int id)
        {
            manager.EditReviewStatus(id, (int)ThesisStatus.DISCARD);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            IDao dao = new DatabaseManager();
            FinalThesisReview review = dao.GetReview(id);
            SubmissionThesis submission = manager.GetSubmissionForThesisId(review.FinalThesis.FinalThesisId);
                        
            ViewBag.thesisTopic = submission.ThesisTopic;
            ViewBag.name = review.FinalThesis.Participant.Name;
            ViewBag.surname = review.FinalThesis.Participant.Surname;

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
