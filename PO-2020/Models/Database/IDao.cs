using System.Collections.Generic;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    interface IDao
    {
        public void AddReview(FinalThesisReview review);
        public void EditReview(FinalThesisReview review);
        public FinalThesisReview GetReview(int reviewId);
        public List<FinalThesisReview> GetReviews(int lecturerId);
        public void AddQuestion(Question question);
        public int GetMaxGradeId();
        public void EditQuestion(Question question);
        public void DeleteQuestion(int questionId);
        public List<Question> GetQuestions(int finalExamId);
        public Question GetQuestion(int questionId);
        public void AddFinalThesis();
        public void EditSubmissionThesis(SubmissionThesis submissionThesis);
        public void EditFinalThesisLecturer(int finalThesisId, int lecturerId);
        public List<SubmissionThesis> GetSubmissionTheses(int edition);
        public SubmissionThesis GetSubmissionThesis(int thesisId);
        public List<Attendance> GetAttendances(Participant participant, Course course);
        public List<Attendance> GetAttendances(Course course);
        public List<ClassesUnit> GetClassesUnitsDate(Course course);
        public List<Course> GetCourses(int edition);
        public List<Course> GetCourses(int edition, Participant participant);
        public List<Lecturer> GetLecturers(int edition);
        public List<Participant> GetParticipants();
        public List<Participant> GetParticipants(Course course);
        public void AddGrade(PartialCourseGrade grade);
        public void EditGrade(PartialCourseGrade grade);
        public PartialCourseGrade GetGrade(int idGrade);
        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant);
        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant, Course course);
        public List<FinalExam> GetFinalExams(int managerId);
        public int GetFinalExamQuestionsAmount(int finalExamId);
    }
}
