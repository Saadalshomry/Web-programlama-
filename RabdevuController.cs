using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_programlama_projesi.Data; // Kendi proje adını kontrol et
using Web_programlama_projesi.Models;

namespace Web_programlama_projesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Sadece Admin girebilir!
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Tüm randevuları getiriyoruz
            // Include ile ilişkili tabloları (Üye, Hoca, Hizmet) bağlıyoruz ki isimlerini görebilelim.
            var randevular = _context.Randevular
                                     .Include(r => r.AppUser) // Randevuyu alan üye
                                     .Include(r => r.Egitmen) // Hoca
                                     .Include(r => r.Hizmet)  // Ders
                                     .OrderByDescending(r => r.TarihSaat) // En yeni tarih en üstte olsun
                                     .ToList();

            return View(randevular);
        }

        // Randevu İptal Etme (Silme)
        public IActionResult Delete(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
