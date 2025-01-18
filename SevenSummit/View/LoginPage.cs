using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenSummit.Controller;
using SevenSummit.Model.Entity;

namespace SevenSummit.View
{
    public partial class login_page : Form
    {
        private AdminController _controller;
        private Admin _admin;

        public login_page()
        {
            InitializeComponent();
            _controller = new AdminController();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            {
                Admin admin = new Admin()
                {
                    username = txtUsername.Text,
                    password = txtpwd.Text,
                };

                string result = _controller.Login(admin);

                if (result != "")
                {
                    
                    splash_screen splashScreen = new splash_screen();
                    splashScreen.Show();

                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();

                    // Menutup form login setelah berhasil login
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Login Gagal");
                    txtUsername.Text = "";
                    txtpwd.Text = "";
                    txtUsername.Focus();

                }

            }

        }

        private void login_page_Load(object sender, EventArgs e)
        {
          
        }


        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
