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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SevenSummit.View
{
    public partial class Booking : Form
    {
        private BookingController _contrBooking;
        private JalurPendakianController _contrJalurPendakian;
        private string _idGunung;
        public Booking(string idGunung, string namaGunung)
        {
            InitializeComponent();
            _contrBooking = new BookingController(new DbContext());
            _contrJalurPendakian = new JalurPendakianController(new DbContext());
            _idGunung = idGunung;
            namaGunungLabel.Text = namaGunung;
            InitializeJalurPendakianSelectItem();
        }

        private void txtCatatan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void InitializeJalurPendakianSelectItem()
        {
            List<JalurPendakianEntity> listJalurPendakian = _contrJalurPendakian.GetJalurPendakianByIdGunung(_idGunung); 

            foreach (var jalur in listJalurPendakian)
            {
                jalurPendakianCmb.Items.Add(jalur.NamaJalur);
            }

        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
          
                BookingEntity bookingEntity = new BookingEntity()
                {
                   idGunung = _idGunung,
                   Nik = txtNik.Text,
                   Email = txtEmail.Text,
                   JumlahPendaki = txtJumlahPendaki.Text,
                   NomorHp = txtNomorHp.Text,
                   TanggalPelaksanaan = txtTanggal.Text,
                   Catatan = txtCatatan.Text,
                   JalurPendakian = jalurPendakianCmb.Text
                };

                int result = _contrBooking.AddDataBooking(bookingEntity);
                if (result == 1)
                {
                    this.Close();
                    MessageBox.Show("Yeayy, Data berhasil Ditambahkan");
                }
                else
                {
                    MessageBox.Show("Data Gagal Ditambahka, hahahah");
                }

            }
        }
    }