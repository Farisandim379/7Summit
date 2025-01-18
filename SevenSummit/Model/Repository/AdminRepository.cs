using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SevenSummit.Model.Entity;
using SevenSummit.Model.Context;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SevenSummit.Model.Repository
{
    public class AdminRepository
    {
        private MySqlConnection _cnn;
        public AdminRepository(DbContext context)
        {
            _cnn = context.ConnectionOpen();
        }
        public string Login(Admin admin)
        {
            string result = "";

            string sql = "SELECT * FROM admin WHERE username = @username AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
            {
                cmd.Parameters.AddWithValue("@username", admin.username);
                cmd.Parameters.AddWithValue("@password", admin.password);

                MySqlDataReader dtr = cmd.ExecuteReader();
                    if (dtr.Read())
                    {
                        result = dtr["username"].ToString();
                    }
            }
            return result;
        }
    }
}
