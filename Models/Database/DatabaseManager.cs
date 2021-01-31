using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using MySql.Data.MySqlClient;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    public class DatabaseManager : IDao
    {
        private static readonly string CONNECTION_DATA_PATH = "db_conf.txt";
        private MySqlConnection conn;

        public void ConnectToDatabase()
        {
            List<string> connectionData = ReadConnectionData();
            var name = connectionData[0];
            var username = connectionData[1];
            var password = connectionData[2];
            var server = connectionData[3];

            string myConnectionString = $"server={server};uid={username};" +
                $"pwd={password};database={name}";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<string> ReadConnectionData()
        {
            List<string> data = new List<string>();
            if (CONNECTION_DATA_PATH.Trim().Length > 0)
            {
                if (File.Exists(CONNECTION_DATA_PATH))
                {
                    using (StreamReader reader = File.OpenText(CONNECTION_DATA_PATH))
                    {
                        while (!reader.EndOfStream)
                        {
                            data.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return data;
        }

        public void AddReview(FinalThesisReview finalThesisReview)
        {
            conn.Open();
            string sql = "INSERT INTO FinalThesesReview " +
                "(formId, titleCompability, thesisStructureComment, newProblem, sourcesUse," +
                " formalWorkSide, wayToUse, substantiveThesisGrade, thesisGrade, formDate, " +
                "formStatus, finalThesisId) VALUES " +
                $"({finalThesisReview.FormId}, {finalThesisReview.TitleCompability}, {finalThesisReview.ThesisStructureComment}, " +
                $"{finalThesisReview.NewProblem}, {finalThesisReview.SourcesUse}, {finalThesisReview.FormalWorkSide}, " +
                $"{finalThesisReview.WayToUse}, {finalThesisReview.SubstantiveThesisGrade}, {finalThesisReview.ThesisGrade}, " +
                $"'{finalThesisReview.FormDate.ToString("yyyy-MM-dd")}', {finalThesisReview.FormStatus}, " +
                $"{finalThesisReview.FinalThesis.FinalThesisId})";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditReview(FinalThesisReview review)
        {
            conn.Open();
            string sql = "UPDATE FinalThesesFinalThesisReview " +
                $"SET titleCompability = {review.TitleCompability}, thesisStructureComment = {review.ThesisStructureComment}, " +
                $"newProblem = {review.NewProblem}, sourcesUse = {review.SourcesUse}, " +
                $"formalWorkSide = {review.FormalWorkSide}, wayToUse = {review.WayToUse}, " +
                $"substantiveThesisGrade = {review.SubstantiveThesisGrade}, thesisGrade = {review.ThesisGrade}, " +
                $"formDate = {review.FormDate}, formStatus = {review.FormStatus}, " +
                $"finalThesisId = {review.FinalThesis.FinalThesisId}" +
                $"WHERE formId = {review.FormId}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public FinalThesisReview GetReview(int reviewId)
        {
            conn.Open();
            string sql = $"SELECT * FROM FinalThesesFinalThesisReview " +
                $"WHERE formId = {reviewId}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            FinalThesisReview review = new FinalThesisReview();

            while (rdr.Read())
            {
                review.FormId = int.Parse(rdr[0].ToString());
                review.TitleCompability = rdr[1].ToString();
                review.ThesisStructureComment = rdr[2].ToString();
                review.NewProblem = rdr[3].ToString();
                review.SourcesUse = rdr[4].ToString();
                review.FormalWorkSide = rdr[5].ToString();
                review.WayToUse = rdr[6].ToString();
                review.SubstantiveThesisGrade = rdr[7].ToString();
                review.ThesisGrade = rdr[8].ToString();
                review.FormDate = DateTime.Parse(rdr[9].ToString());
                review.FormStatus = (ThesisStatus) int.Parse(rdr[10].ToString());
            }
            rdr.Close();
            return review;
        }

        public List<FinalThesisReview> GetReviews(Lecturer lecturer)
        {
            List<FinalThesisReview> reviews = new List<FinalThesisReview>();
            conn.Open();
            string sql = $"SELECT FTR.formId, FTR.titleCompability, FTR.thesisStructureComment, " +
                $"FTR.newProblem, FTR.sourcesUse, FTR.formalWorkSide, FTR.wayToUse, FTR.substantiveThesisGrade, " +
                $"FTR.thesisGrade, FTR.formDate, FTR.formStatus, FTR.finalThesisId " +
                "FROM Lecturers L " +
                "NATURAL JOIN FinalTheses FT " +
                "NATURAL JOIN FinalThesesFinalThesisReview FTR " +
                $"WHERE L.lecturerId = {lecturer.LecturerId}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                FinalThesisReview review = new FinalThesisReview();
                review.FormId = int.Parse(rdr[0].ToString());
                review.TitleCompability = rdr[1].ToString();
                review.ThesisStructureComment = rdr[2].ToString();
                review.NewProblem = rdr[3].ToString();
                review.SourcesUse = rdr[4].ToString();
                review.FormalWorkSide = rdr[5].ToString();
                review.WayToUse = rdr[6].ToString();
                review.SubstantiveThesisGrade = rdr[7].ToString();
                review.ThesisGrade = rdr[8].ToString();
                review.FormDate = DateTime.Parse(rdr[9].ToString());
                review.FormStatus = (ThesisStatus)int.Parse(rdr[10].ToString());
                reviews.Add(review);
            }
            rdr.Close();
            return reviews;
        }

        public void AddQuestion(Question question)
        {
            conn.Open();
            string sql = "INSERT INTO Questions " +
                "(questionId, content, points, answer, examId) VALUES " +
                $"({question.QuestionId}, {question.Content}, {question.Points}," +
                $" {question.Answer}, {question.FinalExams.ExamId})";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditQuestion(Question question)
        {
            conn.Open();
            string sql = "UPDATE Questions " +
                $"SET content = {question.Content}, points = {question.Points}, " +
                $"answer = {question.Answer}, examId = {question.FinalExams.ExamId} " +
                $"WHERE questionId = {question.QuestionId}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Question> GetQuestions(FinalExam finalExam)
        {
            List<Question> questions = new List<Question>();
            conn.Open();
            string sql = $"SELECT Q.questionId, Q.content, Q.points, Q.answer" +
                "NATURAL JOIN Questions Q " +
                $"WHERE FE.examId = {finalExam.ExamId}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Question question = new Question();
                question.QuestionId = int.Parse(rdr[0].ToString());
                question.Content = rdr[1].ToString();
                question.Points = int.Parse(rdr[2].ToString());
                question.Answer = rdr[3].ToString();
                question.FinalExams = finalExam;
                questions.Add(question);
            }
            rdr.Close();
            return questions;
        }

        //trzeba parametry dodac, ale dunno jakie
        public void AddFinalThesis()
        {
            throw new NotImplementedException();
        }

        public void EditFinalThesis()
        {
            throw new NotImplementedException();
        }

        public List<SubmissionThesis> GetSubmissionTheses(int edition)
        {
            List<SubmissionThesis> submissions = new List<SubmissionThesis>();
            conn.Open();
            string sql = $"SELECT ST.submissionId, ST.thesisTopic, ST.topicNumber, " +
                $"ST.thesisObjectives, ST.thesisScope, ST.submissionStatus, ST.finalThesisId, " +
                $"ST.edNumber " +
                "FROM Editions E " +
                "NATURAL JOIN SubmissionTheses ST " +
                $"WHERE E.edNumber = {edition}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                SubmissionThesis submission = new SubmissionThesis();
                submission.SubmissionId = int.Parse(rdr[0].ToString());
                submission.ThesisTopic = rdr[1].ToString();
                submission.TopicNumber = int.Parse(rdr[2].ToString());
                submission.ThesisObjectives = rdr[3].ToString();
                submission.ThesisScope = rdr[4].ToString();
                submission.Status = (ThesisStatus) int.Parse(rdr[5].ToString());

                int finalThesisId = int.Parse(rdr[6].ToString());

                // create final thesis by id
                string querry = $"SELECT * FROM FinalTheses " +
                $"WHERE finalThesisId = {finalThesisId}";
                MySqlCommand command = new MySqlCommand(querry, conn);
                MySqlDataReader reader = command.ExecuteReader();

                reader.Read();
                FinalThesis finalThesis = new FinalThesis();
                finalThesis.FinalThesisId = int.Parse(reader[0].ToString());
                finalThesis.DeliveryDeadline = DateTime.Parse(reader[1].ToString());
                int participantId = int.Parse(reader[2].ToString());
                reader.Close();

                querry = $"SELECT P.participantId, P.participantIndex, P.secondName, " +
                $"P.pesel, P.phoneNumber, P.mothersName, P.fathersName, P.startDate, P.endDate, " +
                $"P.activeParticipantStatus, P.ifPassedFinalExam FROM Participants P " +
                $"WHERE P.participantId = {participantId}";
                command = new MySqlCommand(querry, conn);
                reader = command.ExecuteReader();
                reader.Read();
                finalThesis.Participant = GetParticipantFromReader(reader);
                reader.Close();

                submission.FinalThesis = finalThesis;

                // edition here
                querry = "SELECT SM.managerId, SM.userId, SM.primaryEmploymentPlace FROM Editions E" +
                    "NATURAL JOIN StudyfieldManager SM" +
                    $"WHERE edNumber = {edition}";
                command = new MySqlCommand(querry, conn);
                reader = command.ExecuteReader();
                reader.Read();
                Edition submissionEdition = new Edition();
                submissionEdition.Number = edition;
        
                StudyFieldManager manager = new StudyFieldManager();
                manager.ManagerId = int.Parse(reader[0].ToString());
                manager.UserId = int.Parse(reader[1].ToString());
                manager.PrimaryEmploymentPlace = reader[2].ToString();
                FillUserData(manager);
                submissionEdition.StudyFieldManager = manager;

                submission.Edition = submissionEdition;
                reader.Close();

                submissions.Add(submission);
            }
            rdr.Close();
            return submissions;
        }

        public List<Attendance> GetAttendences(Participant participant, Course course)
        {
            throw new NotImplementedException();
        }

        public List<Attendance> GetAttendences(Course course)
        {
            List<Attendance> attendences = new List<Attendance>();
            conn.Open();
            // kazde z tych id bedzie mi potrzebne do tworzenia obiektow, kurs sie nie zmienia (parametr)
            string sql = $"SELECT P.participantId, CU.classUnitId, C.lecturerId, COUNT(A.participantId) FROM Courses C " +
                $"JOIN ClassesUnits CU ON C.courseId = CU.courseID " +
                $"JOIN Attendences A ON A.classUnitId = CU.classUnitId " +
                $"JOIN Participants P ON P.participantId = A.participantId " +
                $"WHERE C.courseId = {course.CourseId} GROUP BY P.userId";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Attendance attendance = new Attendance();

                // tworze referencje na uczestnika
                int participantId = int.Parse(rdr[0].ToString());
                string querry = $"SELECT * FROM Participants " +
                    $"WHERE participantId = {participantId}";
                MySqlCommand command = new MySqlCommand(querry, conn);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                attendance.Participant = GetParticipantFromReader(reader);
                reader.Close();

                // tworze referencje na jednostke zajec
                int classUnitId = int.Parse(rdr[1].ToString());
                querry = $"SELECT * FROM ClassesUnits " +
                    $"WHERE classUnitId = {classUnitId}";
                command = new MySqlCommand(querry, conn);
                reader = command.ExecuteReader();
                ClassesUnit classesUnit = new ClassesUnit();
                reader.Read();
                classesUnit.ClassUnitId = int.Parse(reader[0].ToString());
                classesUnit.ClassBeginning = DateTime.Parse(reader[1].ToString());
                classesUnit.ClassEnding = DateTime.Parse(reader[2].ToString());
                classesUnit.ClassroomNumber = reader[3].ToString();
                classesUnit.ClassesForm = (ClassesForm) int.Parse(reader[4].ToString());
                
                // jednostka zajec ma kurs, wiec kolejna referencja
                classesUnit.ClassCourse = course;
                reader.Close();

                // jednostka zajec ma prowadzacego, wiec kolejna
                int lecturerId = int.Parse(rdr[2].ToString());
                querry = $"SELECT userId FROM Lecturers " +
                    $"WHERE classUnitId = {classUnitId}";
                command = new MySqlCommand(querry, conn);
                reader = command.ExecuteReader();
                reader.Read();
                Lecturer lecturer = new Lecturer();
                lecturer.LecturerId = lecturerId;
                lecturer.UserId = int.Parse(reader[0].ToString());
                reader.Close();
                FillUserData(lecturer);
                classesUnit.ClassLecturer = lecturer;

                attendance.ClassesUnit = classesUnit;
                attendences.Add(attendance);
            }
            rdr.Close();
            return attendences;
        }

        public List<Course> GetCourses(Participant participant, int edition)
        {
            List<Course> participantCourses = new List<Course>();
            conn.Open();
            string sql = $"SELECT C.courseId, C.courseName FROM ParticipantsWithCourses PC" +
                "NATURAL JOIN Courses C NATURAL JOIN Editions E" +
                $"WHERE PC.participantId = {participant.ParticipantId} AND E.edNumber = {edition}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Course course = new Course();
                course.CourseId = rdr[0].ToString();
                course.Name = rdr[1].ToString();
                course.ECTSPoints = int.Parse(rdr[2].ToString());
                course.Semester = int.Parse(rdr[3].ToString());
                participantCourses.Add(course);
            }
            rdr.Close();
            return participantCourses;
        }

        public List<Lecturer> GetLecturers(int edition)
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            conn.Open();
            string sql = $"SELECT L.lecturerId, U.userName, U.surname, U.email," +
                $" U.birthdate, U.mailingAddress, U.degree FROM Lecturers L " +
                "JOIN Users U ON L.userId = U.userId JOIN Courses C ON C.lecturerId = " +
                "L.lecturerId JOIN Edition E ON E.edNumber = C.edNumber ORDER BY 3";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Lecturer lecturer = new Lecturer();
                lecturer.LecturerId = int.Parse(rdr[0].ToString());
                lecturer.Name = rdr[1].ToString();
                lecturer.Surname = rdr[2].ToString();
                lecturer.Email = rdr[3].ToString();
                lecturer.Birthdate = DateTime.Parse(rdr[4].ToString());
                lecturer.MailingAddress = rdr[5].ToString();
                lecturer.Degree = rdr[6].ToString();
                lecturers.Add(lecturer);
            }
            rdr.Close();
            conn.Close();
            return lecturers;
        }

        public List<Participant> GetParticipants(Course course)
        {
            List<Participant> participants = new List<Participant>();
            conn.Open();

            string sql = $"SELECT P.participantId, P.participantIndex, P.secondName, " +
                $"P.pesel, P.phoneNumber, P.mothersName, P.fathersName, P.startDate, P.endDate, " +
                $"P.activeParticipantStatus, P.ifPassedFinalExam FROM Participants P " +
                $"JOIN ParticipantsWithCourses PC ON P.participantId = PC.participantId " +
                $"JOIN Courses C ON C.courseId = PC.courseId JOIN Users U ON U.userId = P.userId " +
                $"JOIN Edition E ON E.edNumber = C.edNumber" +
                $"WHERE C.courseId = {course.CourseId} ORDER BY 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                participants.Add(GetParticipantFromReader(rdr));
            }
            rdr.Close();
            return participants;
        }

        public void AddGrade(PartialCourseGrade grade)
        {
            conn.Open();
            string sql = "INSERT INTO PartialCourseGrades " +
                "(partialGradeId, gradeDate, gradeValue, participantGradeListId, comment) VALUES " +
                $"({grade.PartialGradeId}, {grade.GradeDate.ToString("yyyy-MM-dd")}', " +
                $"{grade.GradeValue}, {grade.ParticipantGradeList.ParticipantGradeListId}, {grade.Comment})";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditGrade(Participant participant, PartialCourseGrade grade, Course course)
        {
            throw new NotImplementedException();
        }

        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant)
        {
            List<PartialCourseGrade> partialGrades = new List<PartialCourseGrade>();
            conn.Open();

            string sql = $"SELECT PG.GradeDate, PG.GradeValue, PG.Comment FROM PartialCourseGrades PCG " +
                $"JOIN ParticipantGradeList PGL ON PCG.participantGradeListId = PGL.participantGradeListId " +
                $"JOIN ParticipantsWithCourses PWC ON PWC.participantGradeListId = PCG.participantGradeListId " +
                $"JOIN Participants P ON P.participantId = PWC.participantId" +
                $"WHERE P.participantID = {participant.ParticipantId} ORDER BY 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                PartialCourseGrade partialGrade = new PartialCourseGrade();
                partialGrade.GradeDate = DateTime.Parse(rdr[0].ToString());
                partialGrade.GradeValue = GradeConverter.GetGrade(float.Parse(rdr[1].ToString()));
                partialGrade.Comment = rdr[2].ToString();
                partialGrades.Add(partialGrade);
            }
            rdr.Close();
            return partialGrades;
        }

        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant, Course course)
        {
            List<PartialCourseGrade> partialGrades = new List<PartialCourseGrade>();
            conn.Open();

            string sql = $"SELECT PG.GradeDate, PG.GradeValue, PG.Comment FROM PartialCourseGrades PCG " +
                $"JOIN ParticipantGradeList PGL ON PCG.participantGradeListId = PGL.participantGradeListId " +
                $"JOIN ParticipantsWithCourses PWC ON PWC.participantGradeListId = PCG.participantGradeListId " +
                $"JOIN Participants P ON P.participantId = PWC.participantId " +
                $"JOIN Courses C ON C.courseId = PWC.courseId " +
                $"WHERE P.participantID = {participant.ParticipantId} AND C.courseId = {course.CourseId}" +
                $"ORDER BY 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                PartialCourseGrade partialGrade = new PartialCourseGrade();
                partialGrade.GradeDate = DateTime.Parse(rdr[0].ToString());
                partialGrade.GradeValue = GradeConverter.GetGrade(float.Parse(rdr[1].ToString()));
                partialGrade.Comment = rdr[2].ToString();
                partialGrades.Add(partialGrade);
            }
            rdr.Close();
            return partialGrades;
        }

        // reader ma miec tylko dane participanta w kolejnosci jak w bazie,
        // bez danych usera - to sie samo uzupelni
        private Participant GetParticipantFromReader(MySqlDataReader rdr)
        {
            Participant participant = new Participant();
            if (rdr.FieldCount > 10)
            {
                participant.ParticipantId = int.Parse(rdr[0].ToString());
                participant.Index = rdr[1].ToString();
                participant.SecondName = rdr[2].ToString();
                participant.Pesel = rdr[3].ToString();
                participant.PhoneNumber = rdr[4].ToString();
                participant.MothersName = rdr[5].ToString();
                participant.FathersName = rdr[6].ToString();
                participant.StartDate = DateTime.Parse(rdr[7].ToString());
                participant.EndDate = DateTime.Parse(rdr[8].ToString());
                participant.ActiveParticipantStatus = bool.Parse(rdr[9].ToString());
                participant.IfPassedFinalExam = bool.Parse(rdr[10].ToString());
                FillUserData(participant);
            }

            return participant;
        }

        // musi miec user id uzupelnione, reszta sie sama uzupelni
        private void FillUserData(User user)
        {
            string sql = $"SELECT * FROM Users WHERE userId = {user.UserId}";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            
            user.Name = rdr[1].ToString();
            user.Surname = rdr[2].ToString();
            user.Email = rdr[3].ToString();
            user.Birthdate = DateTime.Parse(rdr[4].ToString());
            user.MailingAddress = rdr[5].ToString();
            user.Degree = rdr[6].ToString();
            
            rdr.Close();
        }
    }
}
