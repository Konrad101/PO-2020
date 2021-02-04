using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Lecturer
{
    public class LecturerPresenceListController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public IActionResult Index()
        {
            List<Course> courses = manager.GetCourses(1);
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
            var dict = new Dictionary<String, String>{
                { "course", form["CourseId"] },
            };
            return RedirectToAction("Details", "LecturerPresenceList", dict);
        }

        public ActionResult Details(Dictionary<String, String> dict)
        {
            Course course = new Course();
            course.CourseId = dict["course"];

            List<Course> courses = manager.GetCourses(1);
            IEnumerable<SelectListItem> selectList = from c in courses
                                                     select new SelectListItem
                                                     {
                                                         Value = c.CourseId.ToString(),
                                                         Text = c.Name
                                                     };
            ViewData["Courses"] = new SelectList(selectList, "Value", "Text");

            List<Attendance> attendances = manager.GetAttendances(course);
            List<ClassesUnit> classesUnits = manager.GetClassesUnitsDate(course);
            List<Models.Participant> participants = manager.GetParticipants(course);
            List<bool> attendancesBool = new List<bool>();
            List<Tuple<Models.Participant, List<bool>>> participantAttendances = new List<Tuple<Models.Participant, List<bool>>>();

            foreach (Models.Participant part in participants)
            {
                bool is_find = false;
                foreach (ClassesUnit clas in classesUnits)
                {
                    foreach (Attendance att in attendances)
                    {
                        if (clas.ClassUnitId == att.ClassesUnit.ClassUnitId)
                        {
                            is_find = true;
                            break;
                        }
                    }
                    attendancesBool.Add(is_find);
                }
                int partId = part.ParticipantId;
                Tuple<Models.Participant, List<bool>> tup = new Tuple<Models.Participant, List<bool>>(part, attendancesBool);
                participantAttendances.Add(tup);

                attendancesBool = new List<bool>();
            }

            int presentQuantity = 0;
            int absentQuantity = 0;
            int totalPresentQuantity = 0;
            int totalAbsentQuantity = 0;
            List<Tuple<String, String, int, int>> finalList = new List<Tuple<String, String, int, int>>();

            foreach (var sth in participantAttendances)
            {
                foreach (bool item in sth.Item2)
                {
                    if (item)
                    {
                        presentQuantity++;
                        totalPresentQuantity++;
                    }
                    else
                    {
                        absentQuantity++;
                        totalAbsentQuantity++;
                    }
                }

                finalList.Add(new Tuple<string, string, int, int>(sth.Item1.Name, sth.Item1.Surname, presentQuantity, absentQuantity));

                presentQuantity = 0;
                absentQuantity = 0;
            }

            ViewData["finalList"] = finalList;

            int totalQuantity = totalAbsentQuantity + totalPresentQuantity;
            int absentPercentage = 0;
            int presentPercentage = 0;
            if (totalQuantity != 0)
            {
                absentPercentage = (int)(totalAbsentQuantity / (double)totalQuantity * 100);
                presentPercentage = (int)(totalPresentQuantity / (double)totalQuantity * 100);
            }

            totalQuantity = totalQuantity / finalList.Count();

            ViewData["presentQuantity"] = totalPresentQuantity;
            ViewData["absentQuantity"] = totalAbsentQuantity;
            ViewData["totalQuantity"] = totalQuantity;
            ViewData["absentPercentage"] = absentPercentage;
            ViewData["presentPercentage"] = presentPercentage;

            return View();
        }

        [HttpPost]
        public ActionResult Details(IFormCollection form)
        {
            var dict = new Dictionary<String, String>{
                { "course", form["CourseId"] },
            };
            return RedirectToAction("Details", "LecturerPresenceList", dict);
        }
    }
}
