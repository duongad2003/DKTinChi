using System.ComponentModel.DataAnnotations;

namespace DKTinChi.Models
{
    public class modelSinhVien
    {
        [Key]
        public string IdSinhVien { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; } 
        public string MatKhau { get; set; }
    }
}
