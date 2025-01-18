using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using SevenSummit.Model.Context;
using SevenSummit.Model.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SevenSummit.Model.Repository
{
    public class GunungRepository
    {
        private MySqlConnection _cnn;
        private GunungEntity _gunungEntity;
        public GunungRepository(DbContext context)
        {
            _cnn = context.ConnectionOpen();
        }
        public List<GunungEntity> getAllGunung()
        {
            List<GunungEntity> result = new List<GunungEntity>();

            try
            {
                string sql = "SELECT * FROM `data_gunung`";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _gunungEntity = new GunungEntity
                            {
                                id_Gunung = reader["id_Gunung"].ToString(),
                                Nama_Gunung = reader["Nama_Gunung"].ToString(),
                                Ketinggian = reader["Ketinggian"].ToString(),
                                Lokasi = reader["Lokasi"].ToString(),
                                Jalur_Pendakian = reader["Jalur_Pendakian"].ToString(),
                                Status_Gunung = reader["Status_Gunung"].ToString(),
                                Biaya_Simaksi = int.Parse(reader["Biaya_Simaksi"].ToString())
                            };
                            result.Add(_gunungEntity);
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

        public List<GunungEntity> getGunungByName(string namaGunung)
            {
                List<GunungEntity> result = new List<GunungEntity>();

                try
                {
                    string sql = @"SELECT * FROM `data_gunung` WHERE Nama_Gunung LIKE CONCAT('%', @namaGunung, '%')";

                    using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                    {
                    cmd.Parameters.AddWithValue("@namaGunung", namaGunung);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _gunungEntity = new GunungEntity
                            {
                                id_Gunung = reader["id_Gunung"].ToString(),
                                Nama_Gunung = reader["Nama_Gunung"].ToString(),
                                Ketinggian = reader["Ketinggian"].ToString(),
                                Lokasi = reader["Lokasi"].ToString(),
                                Jalur_Pendakian = reader["Jalur_Pendakian"].ToString(),
                                Status_Gunung = reader["Status_Gunung"].ToString(),
                                Biaya_Simaksi = int.Parse(reader["Biaya_Simaksi"].ToString())
                            };
                            result.Add(_gunungEntity);
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

        public GunungEntity getDataGunungById(string idGunung)
            {
                GunungEntity result = new GunungEntity();

                try
                {
                    string sql = @"SELECT * FROM `data_gunung` WHERE id_Gunung = @idGunung";

                    using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                    {
                    cmd.Parameters.AddWithValue("@idGunung", idGunung);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new GunungEntity
                            {
                                id_Gunung = reader["id_Gunung"].ToString(),
                                Nama_Gunung = reader["Nama_Gunung"].ToString(),
                                Ketinggian = reader["Ketinggian"].ToString(),
                                Lokasi = reader["Lokasi"].ToString(),
                                Jalur_Pendakian = reader["Jalur_Pendakian"].ToString(),
                                Status_Gunung = reader["Status_Gunung"].ToString(),
                                Biaya_Simaksi = int.Parse(reader["Biaya_Simaksi"].ToString())
                            };
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

        public int deleteDataGunungByName(string idGunung)
        {
            int result = 0;
            try
            {
                string sql = @"DELETE FROM `data_gunung` WHERE id_Gunung = @idGunung";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@idGunung", idGunung);

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
        
        public int AddDataGunung(GunungEntity Gunung)
        {
            int result = 0;
            try
            {
                string sql = @"INSERT INTO `data_gunung` VALUES (@idGunung,@NamaGunung,@Ketinggian,@Lokasi,@JalurPendakian,@StatusGunung,@BiayaSimaksi)";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@idGunung", Gunung.id_Gunung);
                    cmd.Parameters.AddWithValue("@NamaGunung", Gunung.Nama_Gunung);
                    cmd.Parameters.AddWithValue("@Ketinggian", Gunung.Ketinggian);
                    cmd.Parameters.AddWithValue("@Lokasi", Gunung.Lokasi);
                    cmd.Parameters.AddWithValue("@JalurPendakian", Gunung.Jalur_Pendakian);
                    cmd.Parameters.AddWithValue("@StatusGunung", Gunung.Status_Gunung);
                    cmd.Parameters.AddWithValue("@BiayaSimaksi", Gunung.Biaya_Simaksi);

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
 
        public int UpdateDataGunung(GunungEntity Gunung, string idGunung)
        {
            int result = 0;
            try
            {
                string sql = @"UPDATE `data_gunung` SET `id_Gunung`=@SelectedIdGunung, `Nama_Gunung`=@NamaGunung, `Ketinggian`=@Ketinggian, `Lokasi`=@Lokasi, `Jalur_Pendakian`=@JalurPendakian, `Status_Gunung`=@StatusGunung, `Biaya_Simaksi`=@BiayaSimaksi WHERE id_Gunung = @selectedIdGunung";

                using (MySqlCommand cmd = new MySqlCommand(sql, _cnn))
                {
                    cmd.Parameters.AddWithValue("@NamaGunung", Gunung.Nama_Gunung);
                    cmd.Parameters.AddWithValue("@Ketinggian", Gunung.Ketinggian);
                    cmd.Parameters.AddWithValue("@Lokasi", Gunung.Lokasi);
                    cmd.Parameters.AddWithValue("@JalurPendakian", Gunung.Jalur_Pendakian);
                    cmd.Parameters.AddWithValue("@StatusGunung", Gunung.Status_Gunung);
                    cmd.Parameters.AddWithValue("@BiayaSimaksi", Gunung.Biaya_Simaksi);
                    cmd.Parameters.AddWithValue("@SelectedIdGunung", idGunung);

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
