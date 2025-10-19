using DKTinChi.Data;
using DKTinChi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DKTinChi.Controllers
{
    public class TinChiController : Controller
    {
        private readonly DataContext _context;
        public TinChiController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Dangki()
        {
            var idSinhVien = HttpContext.Session.GetString("IdSinhVien");
            if (string.IsNullOrEmpty(idSinhVien))
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy danh sách tín chỉ mà sinh viên đã hoàn thành
            var tinChiDaHoanThanh = _context.DangKys
                .Where(d => d.IdSinhVien == idSinhVien)
                .Select(d => d.IdTinChi)
                .ToList();

            // Lấy danh sách tín chỉ chưa hoàn thành
            var tinChiConLai = _context.TinChis
                .Where(tc => !tinChiDaHoanThanh.Contains(tc.IdTinChi))
                .ToList();

            return View(tinChiConLai);
        }

        [HttpPost]
        public IActionResult Dangki(List<int> selectedTinChi)
        {
            var idSinhVien = HttpContext.Session.GetString("IdSinhVien");
            if (string.IsNullOrEmpty(idSinhVien))
            {
                return RedirectToAction("Login", "Account");
            }

            if (selectedTinChi != null && selectedTinChi.Any())
            {
                foreach (var idTinChi in selectedTinChi)
                {
                    
                    bool daDangKy = _context.DangKys.Any(d =>
                        d.IdSinhVien == idSinhVien && d.IdTinChi == idTinChi);

                    if (!daDangKy)
                    {
                        var tinChi = _context.TinChis.FirstOrDefault(tc => tc.IdTinChi == idTinChi);
                        if (tinChi != null)
                        {
                            var dangKy = new modelDangKy
                            {
                                IdSinhVien = idSinhVien,
                                IdTinChi = idTinChi,
                                SoTinDaDangKy = tinChi.SoTinChi,
                                TrangThai = false 
                            };
                            _context.DangKys.Add(dangKy);
                        }
                    }
                }
                _context.SaveChanges();
                Console.WriteLine("Đã lưu vào database");
            }
            return RedirectToAction("DanhSach");
        }


        public IActionResult DanhSach()
        {
            var idSinhVien = HttpContext.Session.GetString("IdSinhVien");
            if (string.IsNullOrEmpty(idSinhVien))
            {
                return RedirectToAction("Login", "Account");
            }

            var danhSach = _context.DangKys
                .Include(d => d.TinChi)
                .Where(d => d.IdSinhVien == idSinhVien)
                .ToList();

            return View(danhSach);
        }

    }
}
