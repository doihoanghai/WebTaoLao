using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSChiDinhDichVuChiTiet")]
    public class ChiDinhDichVuChiTiet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long RowIDDichVuChiTiet { get; set; }

        [MaxLength(40)]
        public string MaChiDinh { get; set; }

        [MaxLength(15)]
        public string MaPhieu { get; set; }

        [MaxLength(15)]
        public string MaDonVi { get; set; }

        [MaxLength(15)]
        public string MaGoiDichVu { get; set; }

        [MaxLength(15)]
        public string MaDichVu { get; set; }

        [Column(TypeName = "decimal")]
        public decimal? GiaTien { get; set; }

        public byte? SoLuong { get; set; }

        public bool isXetNghiemLan2 { get; set; }
    }
}
