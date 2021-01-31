using System.Collections.Generic;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    interface IDao
    {
        public void AddReview(FinalThesisReview review);
        public void EditReview(FinalThesisReview review);
        public FinalThesisReview GetReview(int reviewId);
        public List<FinalThesisReview> GetReviews(Lecturer lecturer);
        public void AddQuestion(Question question);
        public void EditQuestion(Question question);
        public List<Question> GetQuestions(FinalExam finalExam);
        public void AddFinalThesis();
        public void EditFinalThesis();
        public List<SubmissionThesis> GetSubmissionTheses(int edition);
        public List<Attendance> GetAttendences(Participant participant, Course course);
        public List<Attendance> GetAttendences(Course course);
        public List<Course> GetCourses(Participant participant, int edition);
        public List<Lecturer> GetLecturers(int editio);
        public List<Participant> GetParticipants(Course course);
        public void AddGrade(PartialCourseGrade grade);
        public void EditGrade(Participant participant, PartialCourseGrade grade, Course course);
        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant);
        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant, Course course);
    }
}
