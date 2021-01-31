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

		public void AddReview(FinalThesisReview review)
        {
            conn.Open();
            string sql = "INSERT INTO FinalThesesForms " +
                "(formId, thesisTopic, participantData, titleCompability," +
                " thesisStructureComment, newProblem, sourcesUse," +
                " sourcesCharacteristics, formalWorkSide, substantiveThesisGrade," +
                " thesisGrade, formDate) VALUES " +
                $"({review.FormId}, {review.ThesisTopic}, {review.ParticipantData}," +
                $" {review.TitleCompability}, {review.ThesisStructureComment}, {review.NewProblem}," +
                $" {review.SourcesUse}, {review.SourcesCharacteristics}, {review.FormalWorkSide}," +
                $" {review.SubstantiveThesisGrade}, {review.ThesisGrade}, '{review.FormDate.ToString("yyyy-MM-dd")}')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditReview(FinalThesisReview review)
        {
            throw new NotImplementedException();
        }

        public FinalThesisReview GetReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public List<FinalThesisReview> GetReviews(Lecturer lecturer)
        {

            throw new NotImplementedException();
        }

        public void AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestions(FinalExam finalExam)
        {
            throw new NotImplementedException();
        }

        public void AddFinalThesis()
        {
            throw new NotImplementedException();
        }

        public void EditFinalThesis()
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses(Participant participant)
        {
            List<Course> participantCourses = new List<Course>();
            conn.Open(); 
            string sql = $"SELECT * FROM ParticipantsCourses PC" +
                "NATURAL JOIN Courses C" +
                $"WHERE participantId = {participant.ParticipantId}";
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

        public List<Lecturer> GetLecturers()
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            conn.Open();
            string sql = $"SELECT L.lecturerId, U.userName, U.surname, U.email," +
                $" U.birthdate, U.mailingAddress, U.degree FROM Lecturers L " +
                "JOIN Users U ON L.userId = U.userId";
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
                $"P.activeParticipantStatus, P.ifPassedFinalExam, U.userName, U.surname, U.email, " +
                $"U.birthdate, U.mailingAddress, U.degree FROM Participants P " +
                $"JOIN ParticipantsCourses PC ON P.participantId = PC.participantId " +
                $"JOIN Courses C ON C.courseId = PC.courseId JOIN Users U ON U.userId = P.userId" +
                $"WHERE C.courseId = {course.CourseId} ORDER BY 1";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Participant participant = new Participant();
                participant.ParticipantId = int.Parse(rdr[0].ToString());
                participant.Index = rdr[1].ToString();
                participant.SecondNameU = rdr[2].ToString();
                participant.Pesel = rdr[3].ToString();
                participant.PhoneNumber = rdr[4].ToString();
                participant.MothersName = rdr[5].ToString();
                participant.FathersName = rdr[6].ToString();
                participant.StartDate = DateTime.Parse(rdr[7].ToString());
                participant.EndDate = DateTime.Parse(rdr[8].ToString());
                participant.ActiveParticipantStatus = bool.Parse(rdr[9].ToString());
                participant.IfPassedFinalExam = bool.Parse(rdr[10].ToString());
                participant.Name = rdr[11].ToString();
                participant.Surname = rdr[12].ToString();
                participant.Email = rdr[13].ToString();
                participant.Birthdate = DateTime.Parse(rdr[14].ToString());
                participant.MailingAddress = rdr[15].ToString();
                participant.Degree = rdr[16].ToString();
                participants.Add(participant);
            }
            rdr.Close();
            return participants;
        }

        public List<PartialCourseGrade> GetGrades(Participant participant)
        {
            List<PartialCourseGrade> partialGrades = new List<PartialCourseGrade>();
            conn.Open();

            string sql = $"SELECT PG.GradeDate, PG.GradeValue, PG.Comment FROM ParticipantsGrades PGS " +
                $"JOIN PartialGrades PG ON PGS.partialGradeId = PG.partialGradeId " +
                $"WHERE PGS.participantID = {participant.ParticipantId} ORDER BY 1";

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

            string sql = $"SELECT PG.GradeDate, PG.GradeValue, PG.Comment FROM ParticipantsGrades PGS " +
                $"JOIN PartialGrades PG ON PGS.partialGradeId = PG.partialGradeId " +
                $"WHERE PGS.participantID = {participant.ParticipantId} " +
                $"AND PGS.courseId = {course.CourseId} ORDER BY 1";

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

        public List<Grade> GetGrades(Participant participant, Course course)
        {
            throw new NotImplementedException();
        }

        public void AddGrade(Participant participant, PartialCourseGrade grade, Course course)
        {
            throw new NotImplementedException();
        }

        public void EditGrade(Participant participant, PartialCourseGrade grade, Course course)
        {
            throw new NotImplementedException();
        }

        public List<PartialCourseGrade> GetParticipantsGrades(Participant participant)
        {
            throw new NotImplementedException();
        }
    }
}
