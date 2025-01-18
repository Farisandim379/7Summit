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
    public class JalurPendakianRepository
    {
        private MySqlConnection _cnn;
        private JalurPendakianEntity _bookingEntity;
        public JalurPendakianRepository(DbContext context)
        {
            _cnn = context.ConnectionOpen();
        }
        public List<JalurPendakianEntity> getDataJalurPendakianByIdGunung(string idGunung)
        {
            List<JalurPendakianEntity> result = new List<JalurPendakianEntity>();

            try
            {
                string sql = @"SELECT * FROM `jalur_pendakian` WHERE id_Gunung = @idGunung";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@idGunung", idGunung);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JalurPendakianEntity jalurPendakian = new JalurPendakianEntity
                            {
                                idJalur = reader["id_Jalur"].ToString(),
                                idGunung = reader["id_Gunung"].ToString(),
                                NamaJalur = reader["Nama_Jalur"].ToString(),
                                PanjangJalur = reader["Panjang_Jalur"].ToString(),
                                Kesulitan = reader["Kesulitan"].ToString(),
                                Deskripsi = reader["Deskripsi"].ToString()
                            };
                            result.Add(jalurPendakian);
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

        public int AddJalurPendakian(JalurPendakianEntity Jalur)
        {
            int result = 0;
            try
            {
                string sql = @"INSERT INTO `jalur_pendakian`(`id_Jalur`, `id_Gunung`, `Nama_Jalur`, `Panjang_Jalur`, `Kesulitan`, `Deskripsi`) VALUES (@idJalur, @idGunung, @NamaJalur, @PanjangJalur, @Kesulitan, @Deskripsi)";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@idJalur", Jalur.idJalur);
                    cmd.Parameters.AddWithValue("@idGunung", Jalur.idGunung);
                    cmd.Parameters.AddWithValue("@NamaJalur", Jalur.NamaJalur);
                    cmd.Parameters.AddWithValue("@PanjangJalur", Jalur.PanjangJalur);
                    cmd.Parameters.AddWithValue("@Kesulitan", Jalur.Kesulitan);
                    cmd.Parameters.AddWithValue("@Deskripsi", Jalur.Deskripsi);

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


        public int deleteJalurById(string idJalur)
        {
            int result = 0;
            try
            {
                string sql = @"DELETE FROM `jalur_pendakian` WHERE id_Jalur = @idJalur";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@idJalur", idJalur);

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
