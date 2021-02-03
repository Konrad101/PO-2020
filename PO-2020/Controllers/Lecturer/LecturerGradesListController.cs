using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Lecturer
{
    public class LecturerGradesListController : Controller
    {
        private DatabaseManager manager = new DatabaseManager();

        public IActionResult Index()
        {
            List<Models.Course> courses = manager.GetCourses(1);
            IEnumerable<SelectListItem> selectList = from c in courses
                                                     select new SelectListItem
                                                     {
                                                         Value = c.CourseId.ToString(),
                                                         Text = c.Name.ToString()
                                                     };
            ViewData["Courses"] = new SelectList(selectList, "Value", "Text", courses[0].CourseId.ToString());

            List<Models.Participant> participants = manager.GetParticipants();
            IEnumerable<SelectListItem> selectListParticipants = from p in participants
                                                                 select new SelectListItem
                                                                 {
                                                                     Value = p.ParticipantId.ToString(),
                                                                     Text = p.Name.ToString()
                                                                 };
            ViewData["Participants"] = new SelectList(selectListParticipants, "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            List<Models.Course> courses = manager.GetCourses(1);
            IEnumerable<SelectListItem> selectList = from c in courses
                                                     select new SelectListItem
                                                     {
                                                         Value = c.CourseId.ToString(),
                                                         Text = c.Name.ToString()
                                                     };
            ViewData["Courses"] = new SelectList(selectList, "Value", "Text", courses[0].CourseId.ToString());

            List<Models.Participant> participants = manager.GetParticipants();
            IEnumerable<SelectListItem> selectListParticipants = from p in participants
                                                     select new SelectListItem
                                                     {
                                                         Value = p.ParticipantId.ToString(),
                                                         Text = p.Name.ToString()
                                                     };
            ViewData["Participants"] = new SelectList(selectListParticipants, "Value", "Text");

            Console.WriteLine("Controller");
            Console.WriteLine(form["CourseSelect"] + "  " + form["StudSelect"] + "\n");
            var dict = new Dictionary<String, String>{
                { "course", form["CourseSelect"] },
                { "stud", form["StudSelect"] }
            };
            return RedirectToAction("Details", "LecturerGradesList", dict);
            //return View();
        }

        public IActionResult Edit(int id)
        {
            PartialCourseGrade grade = manager.GetGrade(id);
            List<Models.Grade> grades = Enum.GetValues(typeof(Grade))
                .Cast<Grade>()
                .ToList();
            IEnumerable<SelectListItem> selectList = from g in grades
                                                     select new SelectListItem
                                                     {
                                                         Value = g.ToString(),
                                                         Text = GradeConverter.ParseGrade(g).ToString()
                                                     };
            ViewData["Grades"] = new SelectList(selectList, "Value", "Text", grade.GradeValue);

            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection form)
        {
            PartialCourseGrade partialCourseGrade = new PartialCourseGrade();
            partialCourseGrade.PartialGradeId = id;
            partialCourseGrade.GradeDate = Convert.ToDateTime(form["DataTextField"]);
            partialCourseGrade.GradeValue = GradeConverter.GetGradeString(form["GradeId"]);
            partialCourseGrade.Comment = form["ComentTextArea"];
            Console.WriteLine(form["GradeId"]);
            manager.EditGrade(partialCourseGrade);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int id,IFormCollection form)
        {
            PartialCourseGrade partialCourseGrade = new PartialCourseGrade();
            int maxId = manager.GetMaxGradeId();
            partialCourseGrade.PartialGradeId = maxId + 1;
            partialCourseGrade.GradeDate = Convert.ToDateTime(form["DataTextField"]);
            partialCourseGrade.GradeValue = GradeConverter.GetGradeString(form["GradeId"]);
            partialCourseGrade.Comment = form["ComentTextArea"];
            // tutaj potrzeba referencji na liste ocen uczestnika
            // my robimy tak, ze zawsze jestes uczestnikiem o id = 1
            // ale którą liste ocen (ParticipantGradeListId) musimy uzyskać wcześniej z widoku, 
            // tam gdzie wybieramy kurs - bo wtedy można określić która to lista dla id kursu i id uczestnika

            // teraz: na sztywno
            ParticipantGradeList list = new ParticipantGradeList();
            list.ParticipantGradeListId = 1;
            partialCourseGrade.ParticipantGradeList = list;

            List<Grade> grades = Enum.GetValues(typeof(Grade))
                .Cast<Grade>()
                .ToList();
            IEnumerable<SelectListItem> selectList = from g in grades
                                                     select new SelectListItem
                                                     {
                                                         Value = g.ToString(),
                                                         Text = GradeConverter.ParseGrade(g).ToString()
                                                     };
            ViewData["Grades"] = new SelectList(selectList, "Value", "Text");

            manager.AddGrade(partialCourseGrade);
            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            List<Models.Course> courses = manager.GetCourses(1);
            IEnumerable<SelectListItem> selectList = from c in courses
                                                     select new SelectListItem
                                                     {
                                                         Value = c.CourseId.ToString(),
                                                         Text = c.Name.ToString()
                                                     };
            ViewData["Courses"] = new SelectList(selectList, "Value", "Text", courses[0].CourseId.ToString());

            List<Models.Participant> participants = manager.GetParticipants();
            IEnumerable<SelectListItem> selectListParticipants = from p in participants
                                                                 select new SelectListItem
                                                                 {
                                                                     Value = p.ParticipantId.ToString(),
                                                                     Text = p.Name.ToString()
                                                                 };
            ViewData["Participants"] = new SelectList(selectListParticipants, "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Details(IFormCollection form)
        {

            return View();
        }
    }
}
