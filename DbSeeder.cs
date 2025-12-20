using Microsoft.AspNetCore.Identity;
using Web_programlama_projesi.Models; // Kendi proje adını yaz

namespace Web_programlama_projesi.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // Kullanıcı Yönetimi ve Rol Yönetimi servislerini çağırıyoruz
            var userManager = service.GetService<UserManager<AppUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            // 1. ROLLERİ OLUŞTUR (Admin ve Uye)
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Uye"));

            // 2. ADMİN KULLANCISINI OLUŞTUR
            // Kendi öğrenci numaranı buraya yaz
            var adminEmail = "g211210001@sakarya.edu.tr";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newAdmin = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Ad = "Admin",
                    Soyad = "User",
                    EmailConfirmed = true,
                    DogumTarihi = DateTime.Now.AddYears(-20), // Rastgele bir yaş
                    Cinsiyet = "Belirtilmemiş"
                };

                // Kullanıcıyı oluştur ve şifresini "sau" yap
                var result = await userManager.CreateAsync(newAdmin, "sau");

                if (result.Succeeded)
                {
                    // Kullanıcıya "Admin" rolünü ata
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}
