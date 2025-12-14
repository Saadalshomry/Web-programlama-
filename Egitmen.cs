namespace Web_programlama_projesi.Models
{
    public class Egitmen
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Hakkinda { get; set; } // Kısa biyografi
        public string FotoUrl { get; set; } // Resim yolu: "/img/egitmenler/ahmet.jpg"

        // İlişki: Hangi branşın hocası?
        public int BransId { get; set; }
        public Brans Brans { get; set; }

        // İlişki: Eğitmenin randevuları
        public List<Randevu> Randevular { get; set; }
    }
}
