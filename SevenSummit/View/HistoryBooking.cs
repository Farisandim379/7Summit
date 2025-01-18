using SevenSummit.Controller;
using SevenSummit.Model.Entity;
using SevenSummit.Model.Context;
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
    public partial class HistoryBooking : Form
    {
        private BookingController _contrBooking;
        private List<BookingEntity> _listDataBooking;
        private string _Nik;
        public HistoryBooking()
        {
            InitializeComponent();
            _contrBooking = new BookingController(new DbContext());
            InisialisasiDataBooking();
            LoadDataBooking();
        }
        private void InisialisasiDataBooking()
        {
            lvwBooking.View = System.Windows.Forms.View.Details;
            lvwBooking.FullRowSelect = true;
            lvwBooking.GridLines = true;
            lvwBooking.Columns.Add("No", 40, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("Nik", 80, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("ID Gunung", 80, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("Tanggal", 80, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("Nomor Hp", 80, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("Email", 100, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("Jumlah Pendaki", 100, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("Catatan", 100, HorizontalAlignment.Center);
            lvwBooking.Columns.Add("Jalur Dipilih", 100, HorizontalAlignment.Center);
        }
        public void LoadDataBooking()
        {
            try
            {
                lvwBooking.Items.Clear();
                _listDataBooking = _contrBooking.GetAllBooking();

                if (_listDataBooking.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data Gunung");
                }

                foreach (var booking in _listDataBooking)
                {
                   
                    var noUrut = lvwBooking.Items.Count + 1;
                    var item = new ListViewItem(noUrut.ToString());
                    item.SubItems.Add(booking.Nik);
                    item.SubItems.Add(booking.idGunung);
                    item.SubItems.Add(booking.TanggalPelaksanaan);
                    item.SubItems.Add(booking.NomorHp);
                    item.SubItems.Add(booking.Email);
                    item.SubItems.Add(booking.JumlahPendaki);
                    item.SubItems.Add(booking.Catatan);
                    item.SubItems.Add(booking.JalurPendakian);
                    
                    lvwBooking.Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data Gunung: {ex.Message}");
            }
        }

        private void lvwBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwBooking.SelectedItems.Count > 0)
            {
                var selectedItem = lvwBooking.SelectedItems[0];
                _Nik = selectedItem.SubItems[1].Text;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            int result = _contrBooking.DeleteDataBookingByNIK(_Nik);
            if (result == 1)
            {
                MessageBox.Show("data berhasil diapusss");
                LoadDataBooking();
            }
            else
            {
                MessageBox.Show("Gagal hahahah");
            }
        }
    }
}
