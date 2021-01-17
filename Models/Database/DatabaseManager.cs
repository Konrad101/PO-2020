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

        public void AddStudent()
        {

            throw new NotImplementedException();
        }
    }
}
