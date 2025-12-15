using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjeAdi.Data;
using Web_programlama_projesi.Data;
using Web_programlama_projesi.Models;

var builder = WebApplication.CreateBuilder(args);
// --- VERİTABANI BAĞLANTISI ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- IDENTITY (KULLANICI SİSTEMİ) AYARLARI ---
// Şifre kurallarını geliştirme aşamasında gevşetebiliriz (Sadece rakam zorunluluğu kalksın vb.)
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3; // Şifre en az 3 karakter olsun (Test için kolaylık)
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- SEEDING (VERİ TOHUMLAMA) BAŞLANGIÇ ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    // DbSeeder sınıfındaki metodu çağırıyoruz
    await DbSeeder.SeedRolesAndAdminAsync(services);
}
// --- SEEDING BİTİŞ ---

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
