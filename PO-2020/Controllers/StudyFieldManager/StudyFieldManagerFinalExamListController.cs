﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO_implementacja_StudiaPodyplomowe.Models;
using PO_implementacja_StudiaPodyplomowe.Models.Database;
using PO_implementacja_StudiaPodyplomowe.Models.Validators;
using System.Collections.Generic;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.StudyFieldManager
{
    public class StudyFieldManagerFinalExamListController : Controller
    {
        private IDao manager = DaoSingleton.GetInstance().Dao;
        private static int examId;

        public IActionResult Index()
        {
            List<FinalExam> exams = manager.GetFinalExams(1);
            List<int> examsQuestionsAmount = new List<int>();
            for (int i = 0; i < exams.Count; i++)
            {
                examsQuestionsAmount.Add(manager.GetFinalExamQuestionsAmount(exams[i].ExamId));
            }
            ViewBag.examsQuestionsAmount = examsQuestionsAmount;
            return View(exams);
        }

        public IActionResult Edit(int id)
        {
            examId = id;
            List<Question> examQuestions = manager.GetQuestions(id);
            ViewBag.questionsAvailable = examQuestions.Count > 0;
            return View(examQuestions);
        }

        public IActionResult DeleteQuestion(int id)
        {
            manager.DeleteQuestion(id);
            return RedirectToAction("Edit", new { id = examId });
        }

        public IActionResult AddQuestion()
        {
            ViewBag.dataIsValid = true;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddQuestion(IFormCollection form)
        {
            List<bool> fieldsValidation = GetQuestionFieldsValidation(form);
            bool dataIsValid = ValidateQuestionData(form, fieldsValidation);
            if (!dataIsValid)
            {
                ViewBag.fieldsValidation = fieldsValidation;
                ViewBag.form = form;
                return View();
            }

            Question question = new Question();
            int maxId = manager.GetMaxQuestionId();
            question.QuestionId = maxId + 1;
            question.Content = form["Content"];
            question.Points = int.Parse(form["Points"]);
            question.Answer = form["Answer"];
            FinalExam finalExam = new FinalExam();
            finalExam.ExamId = examId;
            question.FinalExams = finalExam;

            manager.AddQuestion(question);
            return RedirectToAction("Edit", new { id = examId });
        }

        public IActionResult EditQuestion(int id)
        {
            Question question = manager.GetQuestion(id);
            ViewBag.dataIsValid = true;
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuestion(int id, IFormCollection form)
        {
            List<bool> fieldsValidation = GetQuestionFieldsValidation(form);
            bool dataIsValid = ValidateQuestionData(form, fieldsValidation);
            if (!dataIsValid)
            {
                ViewBag.fieldsValidation = fieldsValidation;
                return View();
            }

            Question question = new Question();
            question.QuestionId = id;
            question.Content = form["Content"];
            question.Points = int.Parse(form["Points"]);
            question.Answer = form["Answer"];

            manager.EditQuestion(question);

            return RedirectToAction("Edit", new { id = examId });
        }

        private List<bool> GetQuestionFieldsValidation(IFormCollection form)
        {
            List<bool> fieldsValidation = new List<bool>();
            fieldsValidation.Add(DataValidator.FieldContentIsValid(form["Content"], maxLength: 1023));
            fieldsValidation.Add(DataValidator.FieldContentIsValid(form["Answer"], maxLength: 2047));
            fieldsValidation.Add(DataValidator.NumberIsValid(form["Points"], minRange: 1));

            return fieldsValidation;
        }

        private bool ValidateQuestionData(IFormCollection form, List<bool> fieldsValidation)
        {
            bool dataIsValid = true;
            foreach (bool fieldValidation in fieldsValidation)
            {
                if (!fieldValidation)
                {
                    dataIsValid = false;
                }
            }
            ViewBag.dataIsValid = dataIsValid;
            ViewBag.form = form;
            return dataIsValid;
        }
    }
}
