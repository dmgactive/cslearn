using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace learnCLR.LearnRegex
{
    class FileRegex:ILearn
    {
        public void Learn()
        {
            string searchPattern = @"^*(\d{4})\-(\d{2})\-(\d{2})$";

            string fileLocation = "\\\\192.168.8.45\\commonLoginLogs";

            //File.Copy("\\\\192.168.8.45\\commonLoginLogs\\rsi_commonLoginModule.log.2012-08-06", "d:\\a.txt");


            if(!Directory.Exists(fileLocation))
            {
                Console.WriteLine("File doesn't exist.");
                return;
            }

            string[] files = Directory.GetFiles(fileLocation);

            Dictionary<string, string> dateFile = new Dictionary<string, string>();

            foreach (string file in files)
            {  
                if (Regex.IsMatch(file,searchPattern)) {
                    string date = file.Substring(file.Length - 10, 10);
                    dateFile.Add(date, file);
                    Console.WriteLine(file);
                }
                
            }

            List<string> dbDates = new List<string>();

            string connectionStr = "Data Source=localhost;Database=USAGEDB;Integrated Security=SSPI;";

            using (SqlConnection connection = new SqlConnection(connectionStr)) 
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select distinct LOGIN_DATE from COMMON_LOGIN_LOG",connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string dbDate = string.Format("{0:yyyy-MM-dd}", (DateTime)reader[0]);
                        dbDates.Add(dbDate);
                    }
                }
                catch(Exception ex)
                { 
                }
                
            }

            List<string> loadedFiles = new List<string>();

            foreach (string date in dateFile.Keys)
            {
                foreach (string dbDate in dbDates)
                {
                    if (!date.Equals(dbDate))
                    {
                        loadedFiles.Add(dateFile[date]);
                    }
                }
            }

            foreach (string availableFile in loadedFiles)
            {
                Console.WriteLine(availableFile);
            }
            
        }
    }
}
