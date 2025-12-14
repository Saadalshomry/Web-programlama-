namespace Web_programlama_projesi.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime TarihSaat { get; set; } // Randevu başlangıcı
        public DateTime BitisSaati { get; set; } // Hesaplanan bitiş saati

        // Durum yönetimi (Bekliyor, Onaylandı, İptal)
        public bool OnaylandiMi { get; set; } = false;

        // İlişkiler: Kim (Üye), Kimden (Eğitmen), Ne (Hizmet) alıyor?
        public string AppUserId { get; set; } // Identity kullandığımız için Id string'dir
        public AppUser AppUser { get; set; }

        public int EgitmenId { get; set; }
        public Egitmen Egitmen { get; set; }

        public int HizmetId { get; set; }
        public Hizmet Hizmet { get; set; }
    }
}
