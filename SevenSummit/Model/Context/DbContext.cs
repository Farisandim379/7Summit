using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace SevenSummit.Model.Context
{
    public class DbContext : IDisposable
    {

        public MySqlConnection cnn;
        public MySqlConnection ConnectionOpen()
        {
            string myConnectionString = "server=localhost;database=seven_summit;uid=root;pwd=faris";
            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            cnn.Open();

            return cnn;
        }

        public void Dispose()
        {
            if (cnn != null)
            {
                try
                {
                    if (cnn.State != ConnectionState.Closed) cnn.Close();
                }
                finally
                {
                    cnn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
