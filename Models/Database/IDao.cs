using System.Collections.Generic;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    interface IDao
    {
        public void AddReview(Review review);
        public void EditReview(Review review);
        public Review GetReview(int reviewId);
        public List<Review> GetReviews(Lecturer lecturer);
        public void AddQuestion(Question question);
        public void EditQuestion(Question question);
        public List<Question> GetQuestions(FinalExam finalExam);
        public void AddFinalThesis();
        public void EditFinalThesis();
        //public Thesis GetFinalThesis();
        //public List<Attendence> getAttendences(nazwa studenta?, nazwa kursu?);
        //public List<Attendence> getAttendences(nazwa kursu?);
        public List<PartialGrade> GetGrades(Participant participant);
        public List<Course> GetCourses(Participant participant);
        public List<Lecturer> GetLecturers();
        public List<Participant> GetParticipants(Course course);
        public void AddGrade(Participant participant, PartialGrade grade, Course course);
        public void EditGrade(Participant participant, PartialGrade grade, Course course);
        public List<PartialGrade> GetParticipantsGrades(Participant participant);
        public List<PartialGrade> GetParticipantsGrades(Participant participant, Course course);
    }
}
