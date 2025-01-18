using MySql.Data.MySqlClient;
using SevenSummit.Model.Context;
using SevenSummit.Model.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSummit.Model.Repository
{
    public class BookingRepository
    {
        private MySqlConnection _cnn;
        private BookingEntity _bookingEntity;
        public BookingRepository(DbContext context)
        {
            _cnn = context.ConnectionOpen();
        }
        public List<BookingEntity> getAllBooking()
        {
            List<BookingEntity> result = new List<BookingEntity>();

            try
            {
                string sql = "SELECT * FROM `booking`";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _bookingEntity = new BookingEntity
                            {
                                Nik = reader["NIK"].ToString(),
                                idGunung = reader["id_Gunung"].ToString(),
                                TanggalPelaksanaan = reader["Tanggal_Pelaksanaan"].ToString(),
                                NomorHp = reader["Nomor_HP"].ToString(),
                                Email= reader["Email"].ToString(),
                                JumlahPendaki= reader["Jumlah_Pendaki"].ToString(),
                                Catatan= reader["Catatan"].ToString(),
                                JalurPendakian= reader["jalur_pendakian"].ToString()
                            };
                            result.Add(_bookingEntity);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"readDataGunung error: {ex.Message}");
                // Log the exception or handle it accordingly
                throw; // Consider handling the exception based on your application's requirements
            }
            return result;
        }
        public int AddDataBooking(BookingEntity Booking)
        {
            int result = 0;
            try
            {
                string sql = @"INSERT INTO `booking` VALUES (@Nik,@idGunung,@TanggalPelaksanaan,@NomorHp,@Email,@JumlahPendaki,@Catatan, @JalurPendakian)";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@Nik", Booking.Nik);
                    cmd.Parameters.AddWithValue("@idGunung", Booking.idGunung);
                    cmd.Parameters.AddWithValue("@TanggalPelaksanaan", Booking.TanggalPelaksanaan);
                    cmd.Parameters.AddWithValue("@NomorHp", Booking.NomorHp);
                    cmd.Parameters.AddWithValue("@Email", Booking.Email);
                    cmd.Parameters.AddWithValue("@JumlahPendaki", Booking.JumlahPendaki);
                    cmd.Parameters.AddWithValue("@Catatan", Booking.Catatan);
                    cmd.Parameters.AddWithValue("@JalurPendakian", Booking.JalurPendakian);


                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"readDataGunung error: {ex.Message}");
                // Log the exception or handle it accordingly
                throw; // Consider handling the exception based on your application's requirements
            }
            return result;
        }
        public int deleteBookingByNik(string Nik)
        {
            int result = 0;
            try
            {
                string sql = @"DELETE FROM `booking` WHERE NIK = @NIK";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@NIK", Nik);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"readDataGunung error: {ex.Message}");
                // Log the exception or handle it accordingly
                throw; // Consider handling the exception based on your application's requirements
            }
            return result;
        }
    }
}
