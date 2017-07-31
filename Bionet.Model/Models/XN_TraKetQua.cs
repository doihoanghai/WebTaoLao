using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSXN_TraKetQua")]
    public class XN_TraKetQua
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowIDXN_TraKetQua { get; set; }

        public DateTime? NgayTraKQ { get; set; }

        [MaxLength(50)]
        public string UserTraKQ { get; set; }

        [Column(TypeName = "nchar")]
        [MaxLength(10)]
        public string MaPhieu { get; set; }

        [MaxLength(500)]
        public string KetLuanTongQuat { get; set; }

        [MaxLength(500)]
        public string GhiChu { get; set; }

        [MaxLength(15)]
        public string IDCoSo { get; set; }

        [MaxLength(38)]
        public string MaTiepNhan { get; set; }

        public bool isDaDuyetKQ { get; set; }

        public DateTime? NgayCoKQ { get; set; }

        public DateTime? NgayTiepNhan { get; set; }

        public DateTime? NgayChiDinh { get; set; }

        public DateTime? NgayLamXetNghiem { get; set; }

        [MaxLength(15)]
        public string MaXetNghiem { get; set; }

        public bool? isTraKQ { get; set; }

        public string MaPhieuCu { get; set; }

        public string GhiChuPhongXetNghiem { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        public string LyDoXoa { get; set; }

        public string MaGoiXN { get; set; }

        public bool? isNguyCoCao { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }

    }
}
