using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;

namespace learnADO.Pool
{
    public class ConnectionPool:ILearn
    {
        #region ILearn Members

        public void Learn()
        {
            Connection();
            //ConnectioCounter();
        }

        #endregion

        private void Connection()
        {
            Console.WriteLine("Create connection.");
            var con=new SqlConnection
                        {
                            ConnectionString = "Data Source=localhost;Initial Catalog=ETL20;Integrated Security=true;Min Pool Size=2;Max Pool Size=6;"
                        };
            con.Open();

            Console.WriteLine("open connection.");

            Thread.Sleep(10000);

            con.Close();

            Console.WriteLine("Close connection.");
        }

        private void ConnectioCounter()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread thread=new Thread(new ThreadStart(Connection));
                thread.Start();
            }

            for (int i = 0; i < 20; i++)
            {
                Thread thread = new Thread(new ThreadStart(AnotherConnection));
                thread.Start();
            }
        }

        private void AnotherConnection()
        {
            Console.WriteLine("Another Create connection.");
            var con = new SqlConnection
            {
                ConnectionString = "Initial Catalog=ETL20;Data Source=localhost;Integrated Security=true;Min Pool Size=2;Max Pool Size=6;"
            };
            con.Open();

            Console.WriteLine("Another open connection.");

            Thread.Sleep(10000);

            con.Close();

            Console.WriteLine("Another Close connection.");
        }
    }
}
