using DKTinChi.Data;
using Microsoft.AspNetCore.Mvc;

namespace DKTinChi.Controllers
{
    public class DKController : Controller
    {
        private readonly DataContext _context;
        public DKController(DataContext context)
        {
            _context = context;
        }
        public IActionResult ThongTin()
        {
            var sinhVienId = HttpContext.Session.GetString("IdSinhVien");
            if (sinhVienId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var sinhVien = _context.SinhViens.FirstOrDefault(s => s.IdSinhVien == sinhVienId);
            if (sinhVien == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(sinhVien);
        }
    }
}
