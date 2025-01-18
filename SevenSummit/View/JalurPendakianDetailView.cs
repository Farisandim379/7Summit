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
    public partial class JalurPendakianDetailView : Form
    {
        private JalurPendakianController _contrjalur;
        private List<JalurPendakianEntity> _listDataJalur;
        private string _idGunung;
        private string _idJalur;

        public JalurPendakianDetailView(string idGunung)
        {
            InitializeComponent();
            _contrjalur = new JalurPendakianController(new DbContext());
            _idGunung = idGunung;
            InisialisasiJalurPendakian();
            LoadDataJalurPendakian();
        }

        private void InisialisasiJalurPendakian()
        {
            lvwDataJalurPendakian.View = System.Windows.Forms.View.Details;
            lvwDataJalurPendakian.FullRowSelect = true;
            lvwDataJalurPendakian.GridLines = true;
            lvwDataJalurPendakian.Columns.Add("No", 40, HorizontalAlignment.Center);
            lvwDataJalurPendakian.Columns.Add("ID Jalur", 80, HorizontalAlignment.Center);
            lvwDataJalurPendakian.Columns.Add("ID Gunung", 80, HorizontalAlignment.Center);
            lvwDataJalurPendakian.Columns.Add("Nama Jalur", 80, HorizontalAlignment.Center);
            lvwDataJalurPendakian.Columns.Add("Panjang Jalur", 80, HorizontalAlignment.Center);
            lvwDataJalurPendakian.Columns.Add("Kesulitan", 80, HorizontalAlignment.Center);
            lvwDataJalurPendakian.Columns.Add("Deskripsi", 100, HorizontalAlignment.Center);
        }
        public void LoadDataJalurPendakian()
        {
            try
            {
                lvwDataJalurPendakian.Items.Clear();
                _listDataJalur = _contrjalur.GetJalurPendakianByIdGunung(_idGunung);

                if (_listDataJalur.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data Jalur Pendakian");
                }

                foreach (var jalur in _listDataJalur)
                {
                    var noUrut = lvwDataJalurPendakian.Items.Count + 1;
                    var item = new ListViewItem(noUrut.ToString());
                    item.SubItems.Add(jalur.idJalur);
                    item.SubItems.Add(jalur.idGunung);
                    item.SubItems.Add(jalur.NamaJalur);
                    item.SubItems.Add(jalur.PanjangJalur);
                    item.SubItems.Add(jalur.Kesulitan);
                    item.SubItems.Add(jalur.Deskripsi);
                    lvwDataJalurPendakian.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data Gunung: {ex.Message}");
            }
        }


        private void lvwDataJalurPendakian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDataJalurPendakian.SelectedItems.Count > 0)
            {
                var selectedItem = lvwDataJalurPendakian.SelectedItems[0];
                _idJalur = selectedItem.SubItems[1].Text;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            int result = _contrjalur.DeleteJalurById(_idJalur);
            if (result == 1)
            {
                MessageBox.Show("data berhasil diapusss");
                LoadDataJalurPendakian();
            }
            else
            {
                MessageBox.Show("Gagal hahahah");
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            JalurPendakian jalurPendakian = new JalurPendakian(_idGunung, this);
            jalurPendakian.ShowDialog();
        }
    }
}
