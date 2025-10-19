using DKTinChi.Data;

namespace DKTinChi.Data
{
    public class SeedData
    {
        public static void SeedingData(DataContext context)
        {
            if (!context.SinhViens.Any())
            {
                context.SinhViens.AddRange(
                    new Models.modelSinhVien { IdSinhVien = "sv1", HoTen = "Nguyen Van A",Lop = "15A1", MatKhau = "12345" },
                    new Models.modelSinhVien { IdSinhVien = "sv2", HoTen = "Nguyen Van B", Lop = "15A2", MatKhau = "12345" }
                );
                context.SaveChanges();
            }
            if (!context.TinChis.Any())
            {
                context.TinChis.AddRange(
                    new Models.modelTinChi { TenTinChi = "C#", SoTinChi = 4 },
                    new Models.modelTinChi { TenTinChi = "C++", SoTinChi = 4 }
                );
                context.SaveChanges();
            }
        }
    }
}
