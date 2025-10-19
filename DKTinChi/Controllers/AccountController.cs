using DKTinChi.Data;
using Microsoft.AspNetCore.Mvc;

namespace DKTinChi.Controllers
{
    public class AccountController : Controller
    {
        public readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string masv, string password)
        {
            var sinhvien = _context.SinhViens
                .FirstOrDefault(sv => sv.IdSinhVien.ToString() == masv && sv.MatKhau == password);

            if (sinhvien != null)
            {
                HttpContext.Session.SetString("IdSinhVien", sinhvien.IdSinhVien.ToString());
                return RedirectToAction("ThongTin", "DK");
            }

            ViewBag.Error = "Mã sinh viên hoặc mật khẩu không đúng.";
            ViewData["masv"] = masv;
            ViewData["password"] = password;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
