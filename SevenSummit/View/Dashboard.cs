using SevenSummit.Controller;
using SevenSummit.Model.Context;
using SevenSummit.Model.Entity;
using SevenSummit.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenSummit
{
    public partial class Dashboard : Form
    {
        private GunungController _contrlGng;
        private List<GunungEntity> _listDataGunung;
        private string _idGunung;
        private string _nameGunung;
        public Dashboard()
        {
            InitializeComponent();
            _contrlGng = new GunungController(new DbContext());
            InisialisasiDataGunung();
            LoadDataGunung();
        }

        private void InisialisasiDataGunung()
        {
            lvwDataGunung.View = System.Windows.Forms.View.Details;
            lvwDataGunung.FullRowSelect = true;
            lvwDataGunung.GridLines = true;
            lvwDataGunung.Columns.Add("No", 40, HorizontalAlignment.Center);
            lvwDataGunung.Columns.Add("ID gunung", 80, HorizontalAlignment.Center);
            lvwDataGunung.Columns.Add("Nama Gunung",110, HorizontalAlignment.Center);
            lvwDataGunung.Columns.Add("Ketinggian", 80, HorizontalAlignment.Center);
            lvwDataGunung.Columns.Add("Lokasi", 80, HorizontalAlignment.Center);
            lvwDataGunung.Columns.Add("Jumlah Jalur", 100, HorizontalAlignment.Center);
            lvwDataGunung.Columns.Add("Status Gunung", 100, HorizontalAlignment.Center);
            lvwDataGunung.Columns.Add("Biaya Simaksi", 80, HorizontalAlignment.Center);
        }
        public void LoadDataGunung()
        {
            try
            {
                lvwDataGunung.Items.Clear();
                _listDataGunung = _contrlGng.GetAllGunung();

                if (_listDataGunung.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data Gunung");
                }

                foreach (var gunung in _listDataGunung)
                {
                    var noUrut = lvwDataGunung.Items.Count + 1;
                    var item = new ListViewItem(noUrut.ToString());
                    item.SubItems.Add(gunung.id_Gunung);
                    item.SubItems.Add(gunung.Nama_Gunung);
                    item.SubItems.Add(gunung.Ketinggian);
                    item.SubItems.Add(gunung.Lokasi);
                    item.SubItems.Add(gunung.Jalur_Pendakian);
                    item.SubItems.Add(gunung.Status_Gunung);
                    item.SubItems.Add(gunung.Biaya_Simaksi.ToString());
                    lvwDataGunung.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data Gunung: {ex.Message}");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (lvwDataGunung.SelectedItems.Count > 0)
            {
                var selectedItem = lvwDataGunung.SelectedItems[0];
                _idGunung = selectedItem.SubItems[1].Text;
                _nameGunung = selectedItem.SubItems[2].Text;
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                lvwDataGunung.Items.Clear();
                _listDataGunung = _contrlGng.GetGunungByName(txtNamaGunung.Text);

                if (_listDataGunung.Count == 0)
                {
                    MessageBox.Show("Data Gunung Yang Kamu Cari Tidak Ditemukan! hahahaha");
                }

                foreach (var gunung in _listDataGunung)
                {
                    var noUrut = lvwDataGunung.Items.Count + 1;
                    var item = new ListViewItem(noUrut.ToString());
                    item.SubItems.Add(gunung.id_Gunung);
                    item.SubItems.Add(gunung.Nama_Gunung);
                    item.SubItems.Add(gunung.Ketinggian);
                    item.SubItems.Add(gunung.Lokasi);
                    item.SubItems.Add(gunung.Jalur_Pendakian);
                    item.SubItems.Add(gunung.Status_Gunung);
                    item.SubItems.Add(gunung.Biaya_Simaksi.ToString());
                    lvwDataGunung.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data Gunung: {ex.Message}");
            }
        }

       

        private void btnTambah_Click(object sender, EventArgs e)
        {
            TambahDataGunungView tambahDataGunungView = new TambahDataGunungView(this);
            tambahDataGunungView.ShowDialog();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult resultDialog = MessageBox.Show(
     "Apakah Anda yakin ingin menghapus data ini?", // Pesan konfirmasi
     "Konfirmasi Hapus",                           // Judul MessageBox
     MessageBoxButtons.YesNo,                     // Tombol Yes dan No
     MessageBoxIcon.Warning                       // Ikon peringatan
 );

            // Mengecek apakah pengguna memilih "Yes"
            if (resultDialog == DialogResult.Yes)
            {
                // Memanggil fungsi penghapusan data
                int result = _contrlGng.DeleteDataGunungById(_idGunung);

                if (result == 1)
                {
                    MessageBox.Show("Data berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGunung(); // Memuat ulang data setelah penghapusan
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Jika pengguna memilih "No"
                MessageBox.Show("Penghapusan dibatalkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateDataGunung updateDataGunung = new UpdateDataGunung(this, _idGunung);
            updateDataGunung.ShowDialog();

        }

        private void BtnHistoryBooking_Click(object sender, EventArgs e)
        {
            HistoryBooking booking = new HistoryBooking();
            booking.Show();
        }

        private void txtNamaGunung_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDataGunung_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHistoryGunung_Click(object sender, EventArgs e)
        {
            JalurPendakianDetailView jalurPendakianDetail = new JalurPendakianDetailView(_idGunung);
            jalurPendakianDetail.ShowDialog();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking(_idGunung, _nameGunung);
            booking.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
