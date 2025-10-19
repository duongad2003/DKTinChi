using System.ComponentModel.DataAnnotations;

namespace DKTinChi.Models
{
    public class modelTinChi
    {
        [Key]
        public int IdTinChi { get; set; }
        public string TenTinChi { get; set; }
        public int SoTinChi { get; set; }
    }
}
