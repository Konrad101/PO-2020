using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    interface IDao
    {
        public void EddReview(Review review);
        public Review GetReview();
        public List<Review> GetReviews(Lecturer lecturer);
        public void AddQuestion(Question question);
        public void EditQuestion(Question question);
        public List<Question> GetQuestions(FinalExam finalExam);
        public void AddFinalThesis();
        public void EditFinalThesis();
        //public Thesis GetFinalThesis();
        //public List<Attendence> getAttendences(nazwa studenta?, nazwa kursu?);
        //public List<Attendence> getAttendences(nazwa kursu?);
        public Course GetCourse();
        public List<Course> GetCourses(Participant participant);
        public List<Lecturer> GetLecturers();
        public List<Participant> GetParticipants(Course course);
        public void AddGrade(Grade grade);
        public void EditGrade(Grade grade);
        public List<PartialGrade> GetParticipantsGrades(Participant participant);
        public List<PartialGrade> GetParticipantsGrades(Participant participant, Course course);
        public void AddGrade(PartialGrade grade, Participant participant);
        
    }
}
