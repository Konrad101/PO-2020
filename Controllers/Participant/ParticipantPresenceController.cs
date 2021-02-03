using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Participant
{
    public class ParticipantPresenceController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public ActionResult Index()
        {
            User user = new User();
            user.UserId = 1;
            List<Models.Course> courses = manager.GetCourses(1, user);
            IEnumerable<SelectListItem> selectList = from c in courses
                                                     select new SelectListItem
                                                     {
                                                         Value = c.CourseId.ToString(),
                                                         Text = c.Name
                                                     };
            ViewData["Courses"] = new SelectList(selectList, "Value", "Text");

            return View(courses);
        }

        [HttpPost]
        public ActionResult Index(IFormCollection form)
        {
            return RedirectToAction("Details","ParticipantPresence", form["CourseId"]);
        }

        public ActionResult Details(int courseId)
        {
            Console.WriteLine(courseId.ToString());
            User user = new User();
            user.UserId = 1;
            List<Models.Course> courses = manager.GetCourses(1, user);
            IEnumerable<SelectListItem> selectList = from c in courses
                                                     select new SelectListItem
                                                     {
                                                         Value = c.CourseId.ToString(),
                                                         Text = c.Name
                                                     };
            ViewData["Courses"] = new SelectList(selectList, "Value", "Text");

            return View(courses);
        }

    }
}
