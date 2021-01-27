using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Data.SqlClient;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    public class DatabaseManager : IDao
    {
        private static readonly string CONNECTION_DATA_PATH = "db_conf.txt";
        private SqlConnection connection;

        public void ConnectToDatabase()
        {
            try
            {
                List<string> connectionData = ReadConnectionData();
                var name = connectionData[0];
                var username = connectionData[1];
                var password = connectionData[2];
                var server = connectionData[3];

                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = $"{server}.database.windows.net";
                connectionBuilder.UserID = $"{username}";
                connectionBuilder.Password = $"{password}";
                connectionBuilder.InitialCatalog = $"{name}";

                connection = new SqlConnection(connectionBuilder.ConnectionString);
            } catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
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

        public void AddGrade(PartialGrade grade)
        {
            throw new NotImplementedException();
        }

        public void EddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Review GetReview()
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviews(Lecturer lecturer)
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

        public Course GetCourse()
        {
            throw new NotImplementedException();
        }

        public Course GetCourses(Participant participant)
        {
            throw new NotImplementedException();
        }

        public List<Lecturer> GetLecturers()
        {
            throw new NotImplementedException();
        }

        public List<Participant> GetParticipants(Course course)
        {
            throw new NotImplementedException();
        }

        public void AddGrade(Grade grade)
        {
            throw new NotImplementedException();
        }

        public void EditGrade(Grade grade)
        {
            throw new NotImplementedException();
        }

        public List<Grade> GetGrades(Participant participant)
        {
            throw new NotImplementedException();
        }

        public List<Grade> GetGrades(Participant participant, Course course)
        {
            throw new NotImplementedException();
        }

        public void AddGrade(PartialGrade grade, Participant participant)
        {
            throw new NotImplementedException();
        }

        List<Course> IDao.GetCourses(Participant participant)
        {
            throw new NotImplementedException();
        }
    }
}
