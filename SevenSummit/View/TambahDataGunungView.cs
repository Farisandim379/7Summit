using SevenSummit.Controller;
using SevenSummit.Model.Context;
using SevenSummit.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenSummit.View
{
    public partial class TambahDataGunungView : Form
    {
        private GunungController _contrlGng;
        private Dashboard _dashboard;
        public TambahDataGunungView(Dashboard dashboard)
        {
            InitializeComponent();
            _contrlGng = new GunungController(new DbContext());
            _dashboard = dashboard;
        }

        private void txtIdGunung_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            GunungEntity checkedDataGunung = _contrlGng.GetGunungById(txtIdGunung.Text);

            if (checkedDataGunung.id_Gunung == txtIdGunung.Text)
            {
                MessageBox.Show("Data Gunung yang kamu tambahkan sudah ada, ubah id gunung atau tambahkan id gunung yang berbeda");
            } else {
                GunungEntity gunungEntity = new GunungEntity()
                {
                    id_Gunung = txtIdGunung.Text,
                    Nama_Gunung = txtNamaGunung.Text,
                    Ketinggian = txtKetinggian.Text,
                    Lokasi = txtLokasi.Text,
                    Jalur_Pendakian = txtJalurPendakian.Text,
                    Status_Gunung = txtStatusGunung.Text,
                    Biaya_Simaksi = int.Parse(txtBiayaSimaksi.Text)
                };

                int result = _contrlGng.AddDataGunung(gunungEntity);
                if (result == 1)
                {
                    this.Close();
                    MessageBox.Show("Yeayy, Data berhasil Ditambahkan");
                    _dashboard.LoadDataGunung();
                }
                else
                {
                    MessageBox.Show("Data Gagal Ditambahka, hahahah");
                }

            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNamaGunung_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtKetinggian_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txtLokasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void txtJalurPendakian_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void txtStatusGunung_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void txtBiayaSimaksi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
