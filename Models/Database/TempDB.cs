using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database.Sql
{
    public class TempDB : IDao
    {
        public void AddFinalThesis()
        {
            throw new NotImplementedException();
        }

        public void AddGrade(Participant participant, PartialCourseGrade grade, Course course)
        {
            throw new NotImplementedException();
        }

        public void AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void AddReview(FinalThesisReview review)
        {
            throw new NotImplementedException();
        }

        public void EditFinalThesis()
        {
            throw new NotImplementedException();
        }

        public void EditGrade(Participant participant, PartialCourseGrade grade, Course course)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void EditReview(FinalThesisReview review)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses(Participant participant)
        {
            List<Course> courses = new List<Course>();
            const int HOW_MANY = 5;
            for(int i = 0; i < HOW_MANY; i++)
            {
                courses.Add(GenerateCourse(i + 1));
            }
            return courses;
        }

        private Course GenerateCourse(int id)
        {
            string[] coursesIds = { "hk-123b", "ab-312c", "lp-290y"};
            string[] names = { "Analiza matematyczna", "MSiD", "Bazy danych", "WF"};

            Course course = new Course();
            Random random = new Random();
            course.CourseId = coursesIds[random.Next(coursesIds.Length)] + id;
            course.Name = names[random.Next(names.Length)];
            course.ECTSPoints = random.Next(10);
            course.Semester = 1 + random.Next(7);

            return course;
        }

        public List<Lecturer> GetLecturers()
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            const int HOW_MANY = 10;
            for (int i = 0; i < HOW_MANY; i++)
            {
                lecturers.Add(GenerateLecturer(i + 1));
            }
            return lecturers;
        }

        private Lecturer GenerateLecturer(int id)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.LecturerId = id;
            FillUserData(lecturer);

            return lecturer;
        }

        private void FillUserData(User user)
        {
            string[] names = { "Jan", "Jakub", "Piotr", "Aleksandra", "Michalina" };
            string[] surnames = { "Buk", "Kos", "Wrona", "Tracz" };
            string[] emails = { "emmail@wp.pl", "kgb@o2.pl", "blok@gmail.com" };
            string[] mailingadresses = { "ul. Bukowa 2, Wroclaw", "al. Jerozolimskie 52/3" };
            string[] degrees = { "Inżynier", "Magister", "Doktor" };
            Random random = new Random();

            user.Name = names[random.Next(names.Length)];
            user.Surname = surnames[random.Next(surnames.Length)];
            user.Email = emails[random.Next(emails.Length)];
            user.Birthdate = new DateTime(1988 + random.Next(7), 1 + random.Next(12), 1 + random.Next(28));
            user.MailingAddress = mailingadresses[random.Next(mailingadresses.Length)];
            user.Degree = degrees[random.Next(degrees.Length)];
        }

        public List<Participant> GetParticipants(Course course)
        {
            List<Participant> participants = new List<Participant>();
            const int HOW_MANY = 7;
            for (int i = 0; i < HOW_MANY; i++)
            {
                participants.Add(GenerateParticipant(i + 1));
            }

            return participants;
        }

        private Participant GenerateParticipant(int id)
        {
            Participant participant = new Participant();
            string[] secondNames = { "Grzegorz", "Ewelina", "Paweł", "" };
            string[] pesels = { "93011596091", "90112871042", "95120553790" };
            string[] phones = { "920193849", "285910294", "829401928" };
            string[] motherNames = { "Marta", "Zuzanna", "Nina" };
            string[] fatherNames = { "Krystian", "Marcin", "Norbert" };
            DateTime[] startDates = { new DateTime(2018, 10, 01), new DateTime(2019, 10, 01) };
            DateTime[] endDates = { new DateTime(2020, 12, 20) };

            Random random = new Random();

            participant.ParticipantId = id;
            participant.Index = random.Next(100000, 999999).ToString();
            participant.SecondNameU = secondNames[random.Next(secondNames.Length)];
            participant.Pesel = pesels[random.Next(pesels.Length)];
            participant.PhoneNumber = phones[random.Next(phones.Length)];
            participant.MothersName = motherNames[random.Next(motherNames.Length)];
            participant.FathersName = fatherNames[random.Next(fatherNames.Length)];
            participant.StartDate = startDates[random.Next(startDates.Length)];
            participant.EndDate = endDates[random.Next(endDates.Length)];

            FillUserData(participant);
            return participant;
        }

        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant)
        {
            return GenerateGrades(15);
        }

        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant, Course course)
        {

            return GenerateGrades(5);
        }

        private List<PartialCourseGrade> GenerateGrades(int howMany)
        {
            List<PartialCourseGrade> grades = new List<PartialCourseGrade>();
            string[] comments = { "Bardzo dobrze", "Dobrze", "Mogło być lepiej", "" };
            Random random = new Random();

            for (int i = 0; i < howMany; i++)
            {
                PartialCourseGrade grade = new PartialCourseGrade();
                grade.GradeDate = new DateTime(2020, random.Next(1, 12), random.Next(1, 29));
                if (random.Next(2) % 2 == 0)
                {
                    grade.GradeValue = Grade.Grade40;
                } else
                {
                    grade.GradeValue = Grade.Grade50;
                }
                grade.Comment = comments[random.Next(comments.Length)];
                grades.Add(grade);
            }
            
            return grades;
        }

        public List<Question> GetQuestions(FinalExam finalExam)
        {
            List<Question> questions = new List<Question>();
            Random random = new Random();
            const int HOW_MANY = 5;
            string[] contents = { "Czym jest android?", "Dlaczego relacyjne bazy danych są najlepsze?" };
            string[] answers = { "To jest jakiś żart.", "Nie wiem" };
            for(int i = 0; i < HOW_MANY; i++)
            {
                Question question = new Question();
                question.QuestionId = i + 1;
                question.Content = contents[random.Next(contents.Length)];
                question.Points = random.Next(1, 10);
                question.Answer = answers[random.Next(answers.Length)];
            }

            return questions;
        }

        public FinalThesisReview GetReview(int reviewId)
        {
            return GenerateReview(reviewId);
        }

        public List<FinalThesisReview> GetReviews(Lecturer lecturer)
        {
            List<FinalThesisReview> reviews = new List<FinalThesisReview>();
            const int HOW_MANY = 5;
            for(int i = 0; i < HOW_MANY; i++)
            {
                reviews.Add(GenerateReview(i + 1));
            }

            return reviews;
        }

        private FinalThesisReview GenerateReview(int id)
        {
            FinalThesisReview review = new FinalThesisReview();
            Random random = new Random();
            string[] topics = { "Zastosowania relacyjnych baz danych",
                "Sztuczna inteligencja w spekulacji na rynku",
                "Aplikacje monitorujące akcje użytkownika pod kątem zdrowia" 
            };
            review.FormId = id;
            review.ThesisTopic = topics[random.Next(topics.Length)];
            review.ParticipantData = GenerateParticipant(1);
            review.TitleCompability = "Tytul zgodny";
            review.ThesisStructureComment = "Struktura pracy ok";
            review.NewProblem = "Praca stanowi nowe ujęcie problemu";
            review.SourcesUse = "Wykorzystano wiele źródeł";
            review.SourcesCharacteristics = "Wykorzystane źródła są wyszukane";
            review.FormalWorkSide = "Formalna ocena strony pracy";
            review.SubstantiveThesisGrade = "Rzeczowa ocena pracy";
            review.ThesisGrade = "Celujący";
            review.FormDate = new DateTime(2021, 01, random.Next(1, 29));
            int status = random.Next(1, 5);
            switch (status)
            {
                case 1:
                    review.Status = ThesisStatus.APPROVED;
                    break;
                case 2:
                    review.Status = ThesisStatus.NOT_APPROVED;
                    break;
                case 3:
                    review.Status = ThesisStatus.IN_PROGRESS;
                    break;
                default:
                    review.Status = ThesisStatus.WAITING;
                    break;
            }

            return review;
        }
    }
}
