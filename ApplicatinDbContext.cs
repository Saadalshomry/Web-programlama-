using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_programlama_projesi.Models; // Kendi proje adını yazmayı unutma

namespace Web_programlama_projesi.Data
{
    // Identity tabloları için IdentityDbContext'ten miras alıyoruz
    // <AppUser> diyerek kendi özel kullanıcı sınıfımızı kullanacağımızı belirtiyoruz
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tablolarımız
        public DbSet<Brans> Branslar { get; set; }
        public DbSet<Egitmen> Egitmenler { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }

        // İlişki Ayarları (Fluent API)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Hizmet - Ücret Ayarı (Bunu zaten yapmıştık)
            builder.Entity<Hizmet>()
                .Property(h => h.Ucret)
                .HasColumnType("decimal(18,2)");

            // --- YENİ EKLENEN KISIM: CASCADE SORUNUNU ÇÖZME ---

            // 1. Randevu - Eğitmen İlişkisi (Eğitmen silinirse randevuları silme, hata ver)
            builder.Entity<Randevu>()
                .HasOne(r => r.Egitmen)
                .WithMany(e => e.Randevular)
                .HasForeignKey(r => r.EgitmenId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. Randevu - Hizmet İlişkisi (Hizmet silinirse randevuları silme, hata ver)
            builder.Entity<Randevu>()
                .HasOne(r => r.Hizmet)
                .WithMany()
                .HasForeignKey(r => r.HizmetId)
                .OnDelete(DeleteBehavior.Restrict);

            // Not: AppUser (Üye) silindiğinde randevuların silinmesi (Cascade) genelde sorun olmaz,
            // o yüzden onu değiştirmemize gerek yok. Ama SQL yine hata verirse onu da Restrict yaparız.
        }
    }
}
