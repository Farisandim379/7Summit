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
    public partial class UpdateDataGunung : Form
    {
        private GunungController _contrlGng;
        private Dashboard _dashboard;
        private string _selectedIdGunung;
        public UpdateDataGunung(Dashboard dashboard, string selectedIdGunung)
        {
            InitializeComponent();
            _contrlGng = new GunungController(new DbContext());
            _dashboard = dashboard;
            _selectedIdGunung = selectedIdGunung;
            loadSelectedDataGunung();
        }


        private void loadSelectedDataGunung()
        {
            GunungEntity selectedGunung =  _contrlGng.GetGunungById(_selectedIdGunung);
            txtNamaGunung.Text = selectedGunung.Nama_Gunung;
            txtKetinggian.Text = selectedGunung.Ketinggian;
            txtLokasi.Text = selectedGunung.Lokasi;
            txtJalurPendakian.Text = selectedGunung.Jalur_Pendakian;
            txtStatusGunung.Text = selectedGunung.Status_Gunung;
            txtBiayaSimaksi.Text = selectedGunung.Biaya_Simaksi.ToString();
            nameGunungLabel.Text = selectedGunung.Nama_Gunung;
        }

        private void txtIdGunung_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
                GunungEntity gunungEntity = new GunungEntity()
                {
                    Nama_Gunung = txtNamaGunung.Text,
                    Ketinggian = txtKetinggian.Text,
                    Lokasi = txtLokasi.Text,
                    Jalur_Pendakian = txtJalurPendakian.Text,
                    Status_Gunung = txtStatusGunung.Text,
                    Biaya_Simaksi = int.Parse(txtBiayaSimaksi.Text)
                };

                int result = _contrlGng.UpdateDataGunung(gunungEntity, _selectedIdGunung);
                if (result == 1)
                {
                    this.Close();
                    MessageBox.Show("Yeayy, Data berhasil Di Update");
                    _dashboard.LoadDataGunung();
                }
                else
                {
                    MessageBox.Show("Data Gagal Di Update, hahahah");
                }
        }

        private void UpdateDataGunung_Load(object sender, EventArgs e)
        {

        }
    }
}
