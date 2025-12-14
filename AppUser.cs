using Microsoft.AspNetCore.Identity;

namespace Web_programlama_projesi.Models
{
    public class AppUser : IdentityUser
    {
        // IdentityUser zaten Email, PhoneNumber, UserName, PasswordHash içeriyor.
        // Biz ekstra alanları ekliyoruz:
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; } // "Kadın", "Erkek"

        // Yapay Zeka (AI) önerileri için fiziksel bilgiler
        public double? Kilo { get; set; } // Boş geçilebilir (nullable)
        public double? Boy { get; set; }  // Boş geçilebilir
    }
}
