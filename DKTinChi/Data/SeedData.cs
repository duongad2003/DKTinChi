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
                    new Models.modelSinhVien { IdSinhVien = "sv2", HoTen = "Nguyen Van B", Lop = "15A2", MatKhau = "12345" },
                    new Models.modelSinhVien { IdSinhVien = "sv3", HoTen = "Nguyen Van C", Lop = "15A3", MatKhau = "12345" },
                    new Models.modelSinhVien { IdSinhVien = "sv4", HoTen = "Nguyen Van D", Lop = "15A4", MatKhau = "12345" },
                    new Models.modelSinhVien { IdSinhVien = "sv5", HoTen = "Nguyen Van E", Lop = "15A5", MatKhau = "12345" },
                    new Models.modelSinhVien { IdSinhVien = "sv6", HoTen = "Nguyen Van F", Lop = "15A6", MatKhau = "12345" },
                    new Models.modelSinhVien { IdSinhVien = "sv7", HoTen = "Nguyen Van G", Lop = "15A7", MatKhau = "12345" }
                );
                context.SaveChanges();
            }
            if (!context.TinChis.Any())
            {
                context.TinChis.AddRange(
                    new Models.modelTinChi { TenTinChi = "C#", SoTinChi = 4 },
                    new Models.modelTinChi { TenTinChi = "Hướng đối tượng", SoTinChi = 4 },
                    new Models.modelTinChi { TenTinChi = "Cơ sở dữ liệu", SoTinChi = 3},
                    new Models.modelTinChi { TenTinChi = "Lập trình nhúng", SoTinChi = 3 },
                    new Models.modelTinChi { TenTinChi = "Cấu trúc dữ liệu & giải thuật", SoTinChi = 3 },
                    new Models.modelTinChi { TenTinChi = "Java", SoTinChi = 4 },
                    new Models.modelTinChi { TenTinChi = "C++", SoTinChi = 4 }
                );
                context.SaveChanges();
            }
        }
    }
}
