using Microsoft.EntityFrameworkCore;
using DKTinChi.Models;

namespace DKTinChi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<modelSinhVien> SinhViens { get; set; }
        public DbSet<modelTinChi> TinChis { get; set; }
        public DbSet<modelDangKy> DangKys { get; set; }


    }
}
