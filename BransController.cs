using Microsoft.AspNetCore.Mvc;
using Web_programlama_projesi.Data;   // Kendi proje adını yaz
using Web_programlama_projesi.Models; // Kendi proje adını yaz

namespace Web_programlama_projesi.Areas.Admin.Controllers
{
    [Area("Admin")] // BU ÇOK ÖNEMLİ! Buranın Admin panel olduğunu belirtir.
    // [Authorize(Roles = "Admin")] // Giriş sistemini yapınca bunu açacağız!
    public class BransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME
        public IActionResult Index()
        {
            var branslar = _context.Branslar.ToList();
            return View(branslar);
        }

        // 2. EKLEME (Sayfayı Göster)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 3. EKLEME (Kaydet)
        [HttpPost]
        public IActionResult Create(Brans brans)
        {
            if (ModelState.IsValid)
            {
                _context.Branslar.Add(brans);
                _context.SaveChanges(); // Veritabanına yazar
                return RedirectToAction("Index");
            }
            return View(brans);
        }

        // 4. SİLME
        public IActionResult Delete(int id)
        {
            var brans = _context.Branslar.Find(id);
            if (brans != null)
            {
                _context.Branslar.Remove(brans);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
