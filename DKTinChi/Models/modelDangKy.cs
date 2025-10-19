using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKTinChi.Models
{
    public class modelDangKy
    {

        [Key]
        public int IdDangKy { get; set; }
        public string IdSinhVien { get; set; }
        public int IdTinChi { get; set; }
        public int SoTinDaDangKy { get; set; }
        public bool TrangThai { get; set; }

        [ForeignKey("IdSinhVien")]
        public modelSinhVien SinhVien { get; set; }
        [ForeignKey("IdTinChi")]
        public modelTinChi TinChi { get; set; }
    }
}
