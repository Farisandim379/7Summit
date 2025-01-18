using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenSummit.Model.Entity;
using SevenSummit.Model.Repository;
using SevenSummit.Model.Context;

namespace SevenSummit.Controller
{
    public class AdminController
    {
        // deklarasi objek repository untuk menjalankan operasi CRUD
        private AdminRepository _repository;

        public string Login(Admin admin)
        {
            string result = "";
            if (string.IsNullOrEmpty(admin.username) || string.IsNullOrEmpty(admin.password))
            {
                MessageBox.Show("Isi datanya yang bener !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            using (DbContext context = new DbContext())
            {
                _repository = new AdminRepository(context);
                result = _repository.Login(admin);
            }

            return result;


        }
    }
}
