using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSThongTinTrungTam")]
    public class ThongTinTrungTam
    {
        [Key]
        [MaxLength(15)]
        public string MaTrungTam { get; set; }

        [MaxLength(100)]
        public string TenTrungTam { get; set; }

        [MaxLength(200)]
        public string Diachi { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [Column(TypeName = "nchar")]
        [MaxLength(2)]
        public string MaVietTat { get; set; }

        [MaxLength(50)]
        public string DienThoai { get; set; }

        public bool isDongBo { get; set; }

        public bool isXoa { get; set; }

        public bool isChoXNLan2 { get; set; }

        public bool isChoThuLaiMauLan2 { get; set; }

        public bool isCapMaXNTheoMaPhieu { get; set; }

        [MaxLength(39)]
        public string ID { get; set; }

        public string LicenseKey { get; set; }
        
    }
}
