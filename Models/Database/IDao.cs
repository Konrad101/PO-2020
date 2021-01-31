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
        //public Thesis GetFinalThesis();
        //public List<Attendence> getAttendences(nazwa studenta?, nazwa kursu?);
        //public List<Attendence> getAttendences(nazwa kursu?);
        public List<PartialCourseGrade> GetGrades(Participant participant);
        public List<Course> GetCourses(Participant participant);
        public List<Lecturer> GetLecturers();
        public List<Participant> GetParticipants(Course course);
        public void AddGrade(Participant participant, PartialCourseGrade grade, Course course);
        public void EditGrade(Participant participant, PartialCourseGrade grade, Course course);
        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant);
        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant, Course course);
    }
}
