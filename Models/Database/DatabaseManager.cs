using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    public class DatabaseManager : IDao
    {
        private static readonly string CONNECTION_DATA_PATH = "db_conf.txt";
        private MySqlConnection conn;

        public DatabaseManager()
        {
            ConnectToDatabase();
        }

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

        // non-tested
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

        // non-tested
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
                review.FormStatus = (ThesisStatus)int.Parse(rdr[10].ToString());
            }
            rdr.Close();
            conn.Close();
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
                "NATURAL JOIN FinalThesesReview FTR " +
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
            conn.Close();
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
            string sql = $"SELECT Q.questionId, Q.content, Q.points, Q.answer " +
                $"FROM Questions " +
                "NATURAL JOIN FinalExams FE " +
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
            conn.Close();
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

        // tested
        public List<SubmissionThesis> GetSubmissionTheses(int edition)
        {
            List<SubmissionThesis> submissions = new List<SubmissionThesis>();
            List<int> thesesIds = new List<int>();
            List<int> editiondsNum = new List<int>();

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
                submission.Status = (ThesisStatus)int.Parse(rdr[5].ToString());
                thesesIds.Add(int.Parse(rdr[6].ToString()));
                editiondsNum.Add(int.Parse(rdr[7].ToString()));
                submissions.Add(submission);
            }
            rdr.Close();
            conn.Close();

            // tworzenie kluczy obcych
            for (int i = 0; i < submissions.Count; i++)
            {
                conn.Open();
                int finalThesisId = thesesIds[i];
                // create final thesis by id
                string querry = $"SELECT * FROM FinalTheses " +
                $"WHERE finalThesisId = {finalThesisId}";
                cmd = new MySqlCommand(querry, conn);
                rdr = cmd.ExecuteReader();

                rdr.Read();
                FinalThesis finalThesis = new FinalThesis();
                finalThesis.FinalThesisId = int.Parse(rdr[0].ToString());
                finalThesis.DeliveryDeadline = DateTime.Parse(rdr[1].ToString());

                int participantId = int.Parse(rdr[2].ToString());
                rdr.Close();
                conn.Close();

                conn.Open();
                querry = $"SELECT * FROM Participants P " +
                $"WHERE P.participantId = {participantId}";
                cmd = new MySqlCommand(querry, conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                finalThesis.Participant = GetParticipantFromReader(rdr);
                rdr.Close();
                conn.Close();

                submissions[i].FinalThesis = finalThesis;

                // edition here
                conn.Open();
                querry = "SELECT SM.managerId, SM.userId, SM.primaryEmploymentPlace FROM Editions E" +
                    "NATURAL JOIN StudyFieldManager SM " +
                    $"WHERE edNumber = {edition}";
                cmd = new MySqlCommand(querry, conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                Edition submissionEdition = new Edition();
                submissionEdition.Number = edition;

                StudyFieldManager manager = new StudyFieldManager();
                manager.ManagerId = int.Parse(rdr[0].ToString());
                manager.UserId = int.Parse(rdr[1].ToString());
                manager.PrimaryEmploymentPlace = rdr[2].ToString();
                submissionEdition.StudyFieldManager = manager;

                submissions[i].Edition = submissionEdition;
                submissions[i].Edition.StudyFieldManager = manager;

                rdr.Close();
                conn.Close();
            }

            foreach (SubmissionThesis s in submissions)
            {
                FillUserData(s.Edition.StudyFieldManager);
            }

            return submissions;
        }

        public SubmissionThesis GetSubmissionThesis(int thesisId)
        {
            throw new NotImplementedException();
        }

        // tested
        public List<Attendance> GetAttendances(Participant participant, Course course)
        {
            List<Attendance> participantAttendances = new List<Attendance>();
            List<Attendance> courseAttendances = GetAttendances(course);
            foreach (Attendance attendance in courseAttendances)
            {
                if (attendance.Participant.ParticipantId == participant.ParticipantId)
                {
                    participantAttendances.Add(attendance);
                }
            }
            return participantAttendances;
        }

        // tested
        public List<Attendance> GetAttendances(Course course)
        {
            List<Attendance> attendances = new List<Attendance>();
            conn.Open();
            string sql = $"SELECT P.*, CU.*, L.userId FROM Courses C " +
                $"JOIN ClassesUnits CU ON C.courseId = CU.courseID " +
                $"JOIN Lecturers L ON L.lecturerId = CU.lecturerId " +
                $"JOIN Attendances A ON A.classUnitId = CU.classUnitId " +
                $"JOIN Participants P ON P.participantId = A.participantId " +
                $"WHERE C.courseId = {course.CourseId}";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Attendance attendance = new Attendance();
                // tworze referencje na uczestnika
                attendance.Participant = GetParticipantFromReader(rdr);

                // tworze referencje na jednostke zajec
                int dataOffset = 12;
                ClassesUnit classesUnit = new ClassesUnit();
                classesUnit.ClassUnitId = int.Parse(rdr[dataOffset].ToString());
                classesUnit.ClassBeginning = DateTime.Parse(rdr[dataOffset + 1].ToString());
                classesUnit.ClassEnding = DateTime.Parse(rdr[dataOffset + 2].ToString());
                classesUnit.ClassroomNumber = rdr[dataOffset + 3].ToString();
                classesUnit.ClassesForm = (ClassesForm)int.Parse(rdr[dataOffset + 4].ToString());

                // jednostka zajec ma kurs, wiec kolejna referencja
                classesUnit.ClassCourse = course;

                // jednostka zajec ma prowadzacego, wiec kolejna
                Lecturer lecturer = new Lecturer();
                lecturer.LecturerId = int.Parse(rdr[dataOffset + 5].ToString());
                lecturer.UserId = int.Parse(rdr[dataOffset + 6].ToString());
                classesUnit.ClassLecturer = lecturer;

                attendance.ClassesUnit = classesUnit;
                attendances.Add(attendance);
            }
            rdr.Close();
            conn.Close();

            // uzupelniam dane uzytkownikow
            foreach (Attendance a in attendances)
            {
                FillUserData(a.Participant);
                FillUserData(a.ClassesUnit.ClassLecturer);
            }

            return attendances;
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
            conn.Close();
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

        // tested
        public List<Participant> GetParticipants(Course course)
        {
            List<Participant> participants = new List<Participant>();
            conn.Open();

            string sql = $"SELECT P.* FROM Participants P " +
                $"JOIN ParticipantsWithCourses PC ON P.participantId = PC.participantId " +
                $"JOIN Courses C ON C.courseId = PC.courseId JOIN Users U ON U.userId = P.userId " +
                $"JOIN Editions E ON E.edNumber = C.edNumber " +
                $"WHERE C.courseId = {course.CourseId} ORDER BY 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                participants.Add(GetParticipantFromReader(rdr));
            }
            rdr.Close();
            conn.Close();
            foreach(Participant p in participants)
            {
                FillUserData(p);
            }
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

        // zrobic tez edycje przynaleznosci do ktorej listy ocen nalezy?
        // brakuje nam usuwania w DAO
        public void EditGrade(PartialCourseGrade grade)
        {
            conn.Open();
            string sql = "UPDATE PartialCourseGrades " +
                $"SET gradeDate = {grade.GradeDate}, gradeValue = {grade.GradeValue}, " +
                $"comment = {grade.Comment} " +
                $"WHERE partialGradeId = {grade.PartialGradeId}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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
            conn.Close();
            return partialGrades;
        }

        public PartialCourseGrade GetGrade(int idGrade)
        {
            conn.Open();
            string sql = $"SELECT * FROM PartialCourseGrades " +
                $"WHERE partialGradeId = {idGrade}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            PartialCourseGrade grade = new PartialCourseGrade();

            while (rdr.Read())
            {
                grade.PartialGradeId = int.Parse(rdr[0].ToString());
                grade.GradeDate = DateTime.Parse(rdr[1].ToString());
                Enum.TryParse(rdr[2].ToString(), out Grade myGrade);
                grade.GradeValue = myGrade;

                //grade.GradeValue = GradeConverter.GetGrade(float.Parse(rdr[2].ToString()));
                grade.Comment = rdr[3].ToString();
            }
            conn.Close();
            return grade;
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
            conn.Close();
            return partialGrades;
        }

        // reader ma miec tylko dane participanta w kolejnosci jak w bazie,
        // bez danych usera - to sie samo uzupelni
        private Participant GetParticipantFromReader(MySqlDataReader rdr, int dataOffset = 0)
        {
            Participant participant = new Participant();
            if (rdr.FieldCount > 10)
            {
                participant.ParticipantId = int.Parse(rdr[0 + dataOffset].ToString());
                participant.UserId = int.Parse(rdr[1 + dataOffset].ToString());
                participant.Index = rdr[2 + dataOffset].ToString();
                participant.SecondName = rdr[3 + dataOffset].ToString();
                participant.Pesel = rdr[4 + dataOffset].ToString();
                participant.PhoneNumber = rdr[5 + dataOffset].ToString();
                participant.MothersName = rdr[6 + dataOffset].ToString();
                participant.FathersName = rdr[7 + dataOffset].ToString();
                participant.StartDate = DateTime.Parse(rdr[8 + dataOffset].ToString());
                participant.EndDate = DateTime.Parse(rdr[9 + dataOffset].ToString());
                participant.ActiveParticipantStatus = int.Parse(rdr[10 + dataOffset].ToString()) == 1;
                participant.IfPassedFinalExam = int.Parse(rdr[11 + dataOffset].ToString()) == 1;
            }

            return participant;
        }

        // musi miec user id uzupelnione, reszta sie sama uzupelni
        private void FillUserData(User user)
        {
            string sql = $"SELECT * FROM Users WHERE userId = {user.UserId}";

            conn.Close();
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
            conn.Close();
        }

        
    }
}
