using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Participant
{
    public class ParticipantPresenceController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public ActionResult Index()
        {
            Models.Participant participant = new Models.Participant();
            participant.ParticipantId = 1;
            List<Course> courses = manager.GetCourses(1, participant);
            ViewBag.coursesDataAvailable = courses.Count > 0;
            if (courses.Count > 0)
            {
                IEnumerable<SelectListItem> selectList = from c in courses
                                                         select new SelectListItem
                                                         {
                                                             Value = c.CourseId.ToString(),
                                                             Text = c.Name
                                                         };
                ViewData["Courses"] = new SelectList(selectList, "Value", "Text");
            } else
            {
                ViewData["Courses"] = new SelectList(GetEmptySelectList(), "Value", "Text");
            }

            return View(courses);
        }

        [HttpPost]
        public ActionResult Index(IFormCollection form)
        {
            var dict = new Dictionary<String, String>{
                { "course", form["CourseId"] },
            };
            return RedirectToAction("Details", "ParticipantPresence", dict);
        }

        public ActionResult Details(string course)
        {
            Course courseObject = new Course();
            courseObject.CourseId = course;
            Models.Participant participant = new Models.Participant();
            participant.ParticipantId = 1;
            List<Course> courses = manager.GetCourses(1, participant);
            IEnumerable<SelectListItem> selectList = from c in courses
                                                     select new SelectListItem
                                                     {
                                                         Value = c.CourseId.ToString(),
                                                         Text = c.Name
                                                     };
            ViewData["Courses"] = new SelectList(selectList, "Value", "Text");

            List<ClassesUnit> classesUnits = manager.GetClassesUnitsDate(courseObject);
            List<Attendance> attendances = manager.GetAttendances(participant, courseObject);
            ViewBag.attendancesAvailable = classesUnits.Count > 0;

            List<bool> attendancesBool = new List<bool>();
            foreach (ClassesUnit unit in classesUnits)
            {
                bool found = false;
                foreach (Attendance item in attendances)
                {
                    if (unit.ClassUnitId == item.ClassesUnit.ClassUnitId)
                    {
                        found = true;
                        break;
                    }
                }
                attendancesBool.Add(found);
            }

            ViewData["classesUnits"] = classesUnits;
            ViewData["attendancesBool"] = attendancesBool;
            int presentQuantity = 0;
            int absentQuantity = 0;
            foreach (var item in attendancesBool)
            {
                if (item)
                {
                    presentQuantity++;
                }
                else
                {
                    absentQuantity++;
                }
            }
            int classUnitQuantity = presentQuantity + absentQuantity;

            int absentPercentage = 0;
            int presentPercentage = 0;
            if (classUnitQuantity != 0)
            {
                absentPercentage = (int)(absentQuantity / (double)classUnitQuantity * 100);
                presentPercentage = (int)(presentQuantity / (double)classUnitQuantity * 100);
            }

            ViewData["presentQuantity"] = presentQuantity;
            ViewData["absentQuantity"] = absentQuantity;
            ViewData["classUnitQuantity"] = classUnitQuantity;
            ViewData["absentPercentage"] = absentPercentage;
            ViewData["presentPercentage"] = presentPercentage;


            return View();
        }

        private List<SelectListItem> GetEmptySelectList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Text = "Brak",
                Value = "0"
            });

            return selectList;
        }

    }
}
