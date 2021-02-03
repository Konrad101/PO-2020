using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.StudyFieldManager
{
    public class StudyFieldManagerFinalThesisApplicationsController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public IActionResult Index()
        {
            List<SubmissionThesis> submissionTheses = manager.GetSubmissionTheses(1);
            return View(submissionTheses);
        }

        public IActionResult Edit(int id)
        {
            SubmissionThesis submissionThesis = manager.GetSubmissionThesis(id);
            Models.Lecturer lecturer = submissionThesis.FinalThesis.Lecturer;
            List<Models.Lecturer> lecturers = manager.GetLecturers(1);
            IEnumerable<SelectListItem> selectList = from l in lecturers
                                                     select new SelectListItem
                                                     {
                                                         Value = l.LecturerId.ToString(),
                                                         Text = l.Name + " " + l.Surname
                                                     };
            ViewData["Lecturers"] = new SelectList(selectList, "Value", "Text", lecturer.LecturerId);


            return View(submissionThesis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection form)
        {
            SubmissionThesis submissionThesis = new SubmissionThesis();
            submissionThesis.SubmissionId = id;
            submissionThesis.ThesisTopic = form["ThesisTopic"];
            submissionThesis.TopicNumber = int.Parse(form["TopicNumber"]);
            submissionThesis.ThesisObjectives = form["ThesisObjectives"];
            submissionThesis.ThesisScope = form["TopicNumber"];
            manager.EditSubmissionThesis(submissionThesis);
            int finalThesisId = manager.GetSubmissionThesis(id).FinalThesis.FinalThesisId;
            manager.EditFinalThesisLecturer(finalThesisId, int.Parse(form["LecturerId"]));
            return RedirectToAction("Index");
        }

        public IActionResult Confirm(int id)
        {
            manager.EditSubmissionThesesStatus(id, (int)ThesisStatus.APPROVED);
            return RedirectToAction("Index");
        }

        public IActionResult Discard(int id)
        {
            manager.EditSubmissionThesesStatus(id, (int)ThesisStatus.DISCARD);
            return RedirectToAction("Index");
        }
    }
}
