using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Lecturer
{
    public class LecturerGradeAddController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public IActionResult Index()
        {
            return View();
        }

        // GET: LecturerGradeAddController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LecturerGradeAddController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartialCourseGrade grade)
        {
            try
            {
                if (ModelState.IsValid)
                    manager.AddGrade(grade);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
