using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Data.SqlClient;

namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    public class DatabaseManager : IDao
    {
        private static readonly string SCIEZKA_DO_DANYCH_POLACZENIA = "db_conf.txt";
        private SqlConnection polaczenie;

        public void PolaczZBazaDanych()
        {
            try
            {
                List<string> danePolaczenia = CzytajDanePolaczenia();
                var name = danePolaczenia[0];
                var username = danePolaczenia[1];
                var password = danePolaczenia[2];
                var serwer = danePolaczenia[3];

                SqlConnectionStringBuilder budowniczyPolaczenia = new SqlConnectionStringBuilder();
                budowniczyPolaczenia.DataSource = $"{serwer}.database.windows.net";
                budowniczyPolaczenia.UserID = $"{username}";
                budowniczyPolaczenia.Password = $"{password}";
                budowniczyPolaczenia.InitialCatalog = $"{name}";

                polaczenie = new SqlConnection(budowniczyPolaczenia.ConnectionString);
            } catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private List<string> CzytajDanePolaczenia()
        {
            List<string> dane = new List<string>();
            if (SCIEZKA_DO_DANYCH_POLACZENIA.Trim().Length > 0)
            {
                if (File.Exists(SCIEZKA_DO_DANYCH_POLACZENIA))
                {
                    using (StreamReader czytnik = File.OpenText(SCIEZKA_DO_DANYCH_POLACZENIA))
                    {
                        while (!czytnik.EndOfStream)
                        {
                            dane.Add(czytnik.ReadLine());
                        }
                    }
                }
            }

            return dane;
        }

        public void DodajUczestnika()
        {

            throw new NotImplementedException();
        }
    }
}
