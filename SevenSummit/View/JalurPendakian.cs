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
    public partial class JalurPendakian : Form
    {
        private JalurPendakianController _contrjalur;
        private string _idGunung;
        private JalurPendakianDetailView _jalurPendakianDetailView;
        public JalurPendakian(string idGunung, JalurPendakianDetailView jalurPendakianDetail)
        {
            InitializeComponent();
            _contrjalur = new JalurPendakianController(new DbContext());
            _jalurPendakianDetailView = jalurPendakianDetail;
            _idGunung = idGunung;
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            JalurPendakianEntity jalurPendakian = new JalurPendakianEntity() { 
                idGunung = _idGunung,
                idJalur = txtIdJalur.Text,
                Deskripsi = txtDeskripsi.Text,
                Kesulitan = txtKesulitan.Text,
                NamaJalur = txtNamaJalur.Text,
                PanjangJalur = txtPanjang.Text,
            };

            int result = _contrjalur.AddJalurPendakian(jalurPendakian);

            if (result == 1)
            {
                this.Close();
                MessageBox.Show("Yeayy, Data berhasil Ditambahkan");
                _jalurPendakianDetailView.LoadDataJalurPendakian();
            }
            else
            {
                MessageBox.Show("Data Gagal Ditambahka, hahahah");
            }
        }
    }
}
