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
            _connectionString = configuration.GetConnectionString("Server=localhost;Database=PersonelVeritabani;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public Personel EklePersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_i_personel",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter outputParameter = new SqlParameter("@sicilnumarasi", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParameter);

                    command.Parameters.AddWithValue("@ad", personel.Ad);
                    command.Parameters.AddWithValue("@soyad", personel.Soyad);
                    command.Parameters.AddWithValue("@departmankodu", personel.DepartmanKodu);
                    command.Parameters.AddWithValue("@departmanadi", personel.DepartmanAdi);
                    command.Parameters.AddWithValue("@isegiristarihi", personel.IseGirisTarihi);
                    command.Parameters.AddWithValue("@istencikistarihi", personel.IstenCikisTarihi);
                    command.Parameters.AddWithValue("@eposta", personel.Eposta);
                    command.Parameters.AddWithValue("@cinsiyet", personel.Cinsiyet);
                    command.Parameters.AddWithValue("@gsmtelefon", personel.GsmTelefon);
                    command.Parameters.AddWithValue("@telefonsabit", personel.TelefonSabit);

                    connection.Open();
                    command.ExecuteNonQuery();

                    personel.SicilNumarasi = Convert.ToInt32(outputParameter.Value);

                    connection.Close();

                    return personel;
                }
            }
        }

        public void GuncelleCalisan(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_u_personel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@sicilnumarasi", personel.SicilNumarasi);                                                       
                    command.Parameters.AddWithValue("@ad", personel.Ad);
                    command.Parameters.AddWithValue("@soyad", personel.Soyad);
                    command.Parameters.AddWithValue("@departmankodu", personel.DepartmanKodu);
                    command.Parameters.AddWithValue("@departmanadi", personel.DepartmanAdi);
                    command.Parameters.AddWithValue("@isegiristarihi", personel.IseGirisTarihi);
                    command.Parameters.AddWithValue("@istencikistarihi", personel.IstenCikisTarihi);
                    command.Parameters.AddWithValue("@eposta", personel.Eposta);
                    command.Parameters.AddWithValue("@cinsiyet", personel.Cinsiyet);
                    command.Parameters.AddWithValue("@gsmtelefon", personel.GsmTelefon);
                    command.Parameters.AddWithValue("@telefonsabit", personel.TelefonSabit);

                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public void SilPersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_s_personel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@sicilnumarasi", personel.SicilNumarasi);

                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public List<Personel> GetirPersonel(Personel personel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("prs_l_personel", connection))
                {
                    List<Personel> lstPersonel = new List<Personel>();

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@departmankodu", personel.DepartmanKodu);
                    command.Parameters.AddWithValue("@isegiristarihi", personel.IseGirisTarihi);

                    connection.Open();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());

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
                                IseGirisTarihi = Convert.ToDateTime(row["isegiristarihi"]),
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
