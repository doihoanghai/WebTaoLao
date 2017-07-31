using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSXN_KetQua")]
    public class XN_KetQua
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowIDKetQua { get; set; }

        public DateTime? NgayTraKQ { get; set; }

        [MaxLength(50)]
        public string UserTraKQ { get; set; }

        public DateTime? NgayLamXetNghiem { get; set; }

        [MaxLength(50)]
        public string MaPhieu { get; set; }

        [MaxLength(40)]
        public string MaChiDinh { get; set; }

        [MaxLength(15)]
        public string MaDonVi { get; set; }

        [MaxLength(38)]
        public string MaKetQua { get; set; }

        [MaxLength(15)]
        public string MaXetNghiem { get; set; }

        [MaxLength(38)]
        public string MaTiepNhan { get; set; }

        public bool isCoKQ { get; set; }

        public DateTime? NgayChiDinh { get; set; }

        public DateTime? NgayTiepNhan { get; set; }

        [MaxLength(500)]
        public string GhiChu { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        [MaxLength(15)]
        public string MaGoiXN { get; set; }

        [MaxLength(15)]
        public string IDNhanVienXoa { get; set; }

        public DateTime NgayGioXoa { get; set; }

        public string LyDoXoa { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }

    }
}
