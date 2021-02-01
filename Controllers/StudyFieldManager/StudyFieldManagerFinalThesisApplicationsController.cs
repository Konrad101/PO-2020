using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.StudyFieldManager
{
    public class StudyFieldManagerFinalThesisApplicationsController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            SubmissionThesis submissionThesis = manager.GetSubmissionThesis(id);
            return View(submissionThesis);
        }
    }
}
