namespace Web_programlama_projesi.Models
{
    public class Brans
    {
        public int Id { get; set; }
        public string Ad { get; set; } // Örn: "Yoga"

        // İlişki: Bir branşta birden çok eğitmen olabilir
        public List<Egitmen> Egitmenler { get; set; }
    }
}
