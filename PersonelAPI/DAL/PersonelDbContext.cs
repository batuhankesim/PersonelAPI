using PersonelAPI.Model;
using System.Data;
using System.Data.SqlClient;


namespace PersonelAPI.DAL
{
    public class PersonelDbContext
    {
        private readonly string _connectionString;

        public PersonelDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Personel> EklePersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.prs_i_personel",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter outputParameter = new SqlParameter("@sicilnumarasi", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParameter);

                    command.Parameters.AddWithValue("@ad", string.IsNullOrEmpty(personel.Ad) ? DBNull.Value : personel.Ad);
                    command.Parameters.AddWithValue("@soyad", string.IsNullOrEmpty(personel.Soyad) ? DBNull.Value : personel.Soyad);
                    command.Parameters.AddWithValue("@departmankodu", personel.DepartmanKodu);
                    command.Parameters.AddWithValue("@departmanadi", string.IsNullOrEmpty(personel.DepartmanAdi) ? DBNull.Value : personel.DepartmanAdi);
                    command.Parameters.AddWithValue("@isegiristarihi", personel.IseGirisTarihi == DateTime.MinValue ? DBNull.Value : personel.IseGirisTarihi);
                    command.Parameters.AddWithValue("@istencikistarihi", personel.IstenCikisTarihi == DateTime.MinValue ? DBNull.Value: personel.IstenCikisTarihi);
                    command.Parameters.AddWithValue("@eposta", string.IsNullOrEmpty(personel.Eposta) ? DBNull.Value : personel.Eposta);
                    command.Parameters.AddWithValue("@cinsiyet", string.IsNullOrEmpty(personel.Cinsiyet) ? DBNull.Value : personel.Cinsiyet);
                    command.Parameters.AddWithValue("@gsmtelefon", string.IsNullOrEmpty(personel.GsmTelefon) ? DBNull.Value : personel.GsmTelefon);
                    command.Parameters.AddWithValue("@telefonsabit", string.IsNullOrEmpty(personel.TelefonSabit) ? DBNull.Value : personel.TelefonSabit);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    personel.SicilNumarasi = Convert.ToInt32(outputParameter.Value);

                    await connection.CloseAsync();

                    return personel;
                }
            }
        }

        public async Task GuncellePersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_u_personel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@sicilnumarasi", personel.SicilNumarasi);                                                       
                    command.Parameters.AddWithValue("@ad", string.IsNullOrEmpty(personel.Ad) ? DBNull.Value : personel.Ad);
                    command.Parameters.AddWithValue("@soyad", string.IsNullOrEmpty(personel.Soyad) ? DBNull.Value : personel.Soyad);
                    command.Parameters.AddWithValue("@departmankodu", personel.DepartmanKodu);
                    command.Parameters.AddWithValue("@departmanadi", string.IsNullOrEmpty(personel.DepartmanAdi) ? DBNull.Value : personel.DepartmanAdi);
                    command.Parameters.AddWithValue("@isegiristarihi", personel.IseGirisTarihi == DateTime.MinValue ? DBNull.Value : personel.IseGirisTarihi);
                    command.Parameters.AddWithValue("@istencikistarihi", personel.IstenCikisTarihi == DateTime.MinValue ? DBNull.Value : personel.IstenCikisTarihi);
                    command.Parameters.AddWithValue("@eposta", string.IsNullOrEmpty(personel.Eposta) ? DBNull.Value : personel.Eposta);
                    command.Parameters.AddWithValue("@cinsiyet", string.IsNullOrEmpty(personel.Cinsiyet) ? DBNull.Value : personel.Cinsiyet);
                    command.Parameters.AddWithValue("@gsmtelefon", string.IsNullOrEmpty(personel.GsmTelefon) ? DBNull.Value : personel.GsmTelefon);
                    command.Parameters.AddWithValue("@telefonsabit", string.IsNullOrEmpty(personel.TelefonSabit) ? DBNull.Value : personel.TelefonSabit);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    await connection.CloseAsync();
                }
            }
        }

        public async Task SilPersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_s_personel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@sicilnumarasi", personel.SicilNumarasi);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    await connection.CloseAsync();
                }
            }
        }

        public async Task<Personel> OkuPersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_s_personel", connection))
                {                  
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sicilnumarasi", personel.SicilNumarasi);
 

                    await connection.OpenAsync();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(await command.ExecuteReaderAsync());

                    if (dataTable.Rows.Count > 0)
                    {
                        personel = new Personel
                        {
                            SicilNumarasi = Convert.ToInt32(dataTable.Rows[0]["sicilnumarasi"]),
                            Ad = dataTable.Rows[0]["ad"].ToString(),
                            Soyad = dataTable.Rows[0]["soyad"].ToString(),
                            DepartmanKodu = Convert.ToInt32(dataTable.Rows[0]["departmankodu"]),
                            DepartmanAdi = dataTable.Rows[0]["departmanadi"].ToString(),
                            IseGirisTarihi = dataTable.Rows[0]["isegiristarihi"] != DBNull.Value ? Convert.ToDateTime(dataTable.Rows[0]["isegiristarihi"]) : DateTime.MinValue,
                            IstenCikisTarihi = dataTable.Rows[0]["istencikistarihi"] != DBNull.Value ? Convert.ToDateTime(dataTable.Rows[0]["istencikistarihi"]) : DateTime.MinValue,
                            Eposta = dataTable.Rows[0]["eposta"].ToString(),
                            Cinsiyet = dataTable.Rows[0]["cinsiyet"].ToString(),
                            GsmTelefon = dataTable.Rows[0]["gsmtelefon"].ToString(),
                            TelefonSabit = dataTable.Rows[0]["telefonsabit"].ToString()
                        };
                    }
                    return personel;
                }
            }
        }

        public async Task<List<Personel>> GetirPersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_l_personel", connection))
                {
                    List<Personel> lstPersonel = new List<Personel>();

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@departmankodu", personel.DepartmanKodu);
                    command.Parameters.AddWithValue("@isegiristarihi", personel.IseGirisTarihi);

                    await connection.OpenAsync();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(await command.ExecuteReaderAsync());

                    if (dataTable.Rows.Count > 0)
                    {
                        
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Personel dbPersonel = new Personel
                            {
                                SicilNumarasi = Convert.ToInt32(row["sicilnumarasi"]),
                                Ad = row["ad"].ToString(),
                                Soyad = row["soyad"].ToString(),
                                DepartmanKodu = Convert.ToInt32(row["departmankodu"]),
                                DepartmanAdi = row["departmanadi"].ToString(),
                                IseGirisTarihi = row["isegiristarihi"] != DBNull.Value ? Convert.ToDateTime(row["isegiristarihi"]) : DateTime.MinValue,
                                IstenCikisTarihi = row["istencikistarihi"] != DBNull.Value ? Convert.ToDateTime(row["istencikistarihi"]) : DateTime.MinValue,
                                Eposta = row["eposta"].ToString(),
                                Cinsiyet = row["cinsiyet"].ToString(),
                                GsmTelefon = row["gsmtelefon"].ToString(),
                                TelefonSabit = row["telefonsabit"].ToString()
                            };

                            lstPersonel.Add(dbPersonel);
                        }
                        
                    }
                    return lstPersonel;
                }
            }
        }

        public async Task<List<Personel>> GetirPersonelTum()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_l_personeltum", connection))
                {
                    List<Personel> lstPersonel = new List<Personel>();

                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(await command.ExecuteReaderAsync());

                    if (dataTable.Rows.Count > 0)
                    {

                        foreach (DataRow row in dataTable.Rows)
                        {
                            Personel dbPersonel = new Personel
                            {
                                SicilNumarasi = Convert.ToInt32(row["sicilnumarasi"]),
                                Ad = row["ad"].ToString(),
                                Soyad = row["soyad"].ToString(),
                                DepartmanKodu = Convert.ToInt32(row["departmankodu"]),
                                DepartmanAdi = row["departmanadi"].ToString(),
                                IseGirisTarihi = row["isegiristarihi"] != DBNull.Value ? Convert.ToDateTime(row["isegiristarihi"]) : DateTime.MinValue,
                                IstenCikisTarihi = row["istencikistarihi"] != DBNull.Value ? Convert.ToDateTime(row["istencikistarihi"]) : DateTime.MinValue,
                                Eposta = row["eposta"].ToString(),
                                Cinsiyet = row["cinsiyet"].ToString(),
                                GsmTelefon = row["gsmtelefon"].ToString(),
                                TelefonSabit = row["telefonsabit"].ToString()
                            };

                            lstPersonel.Add(dbPersonel);
                        }

                    }
                    return lstPersonel;
                }
            }
        }
    }
}
