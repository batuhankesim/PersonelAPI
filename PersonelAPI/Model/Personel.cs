namespace PersonelAPI.Model
{
    public class Personel
    {
        public int SicilNumarasi { get; set; }

        public string? Ad {  get; set; }

        public string? Soyad { get; set; }

        public int DepartmanKodu { get; set; }

        public string? DepartmanAdi { get; set; }

        public DateTime IseGirisTarihi { get; set; }

        public DateTime IstenCikisTarihi { get; set; }

        public string? Eposta { get; set; }

        public string? Cinsiyet {  get; set; }

        public string? GsmTelefon { get; set;}

        public string? TelefonSabit {  get; set; }
    }
}
