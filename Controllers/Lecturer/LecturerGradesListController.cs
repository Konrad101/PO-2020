using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Lecturer
{
    public class LecturerGradesListController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();
        


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            PartialCourseGrade grade = manager.GetGrade(id);
            return View(grade);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        private void AddGrade()
        {

        }
    }
}
