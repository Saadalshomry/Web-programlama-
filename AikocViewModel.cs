namespace Web_programlama_projesi.Models.ViewModels
{
    public class AiKocViewModel
    {
        // Kullanıcıdan alacağımız bilgiler
        public int Yas { get; set; }
        public int Boy { get; set; }
        public int Kilo { get; set; }
        public string Cinsiyet { get; set; } // "Kadın" veya "Erkek"
        public string Hedef { get; set; }    // "Kilo Vermek", "Kas Yapmak" vb.

        // Yapay Zekadan gelen cevabı buraya kaydedeceğiz
        public string Cevap { get; set; }
    }
}
