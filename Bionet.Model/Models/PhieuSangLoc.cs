using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSPhieuSangLoc")]
    public class PhieuSangLoc
    {
        
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowIDPhieu { get; set; }

        [Key]
        [MaxLength(15)]
        public string IDPhieu { get; set; }

        [MaxLength(38)]
        public string MaBenhNhan { get; set; }

        public DateTime? NgayTaoPhieu { get; set; }

        [MaxLength(128)]
        public string IDNhanVienTaoPhieu { get; set; }

        [MaxLength(15)]
        public string IDCoSo { get; set; }

        public DateTime? NgayGioLayMau { get; set; }

        public byte? IDViTriLayMau { get; set; }

        [MaxLength(15)]
        public string IDNhanVienLayMau { get; set; }

        public bool isLayMauLan2 { get; set; }

        [MaxLength(15)]
        public string IDPhieuLan1 { get; set; }

        public byte? TinhTrangLucLayMau { get; set; }

        [Column(TypeName = "smallint")]
        public Int16? SLTruyenMau { get; set; }

        public DateTime? NgayTruyenMau { get; set; }

        public byte? CheDoDinhDuong { get; set; }

        public bool TrangThaiPhieu { get; set; }

        public byte? TrangThaiMau { get; set; }

        public bool isKhongDat { get; set; }

        public DateTime? NgayNhanMau { get; set; }

        [MaxLength(15)]
        public string MaXetNghiem { get; set; }

        [MaxLength(4)]
        public string Para { get; set; }

        public bool? isTruoc24h { get; set; }

        public bool? isSinhNon { get; set; }

        public bool? isNheCan { get; set; }

        public bool? isGuiMauTre { get; set; }

        [MaxLength(10)]
        public string IDChuongTrinh { get; set; }

        [MaxLength(15)]
        public string MaGoiXN { get; set; }

        [MaxLength(50)]
        public string TenNhanVienLayMau { get; set; }

        [MaxLength(20)]
        public string SDTNhanVienLayMau { get; set; }

        [MaxLength(50)]
        public string NoiLayMau { get; set; }

        public bool? isHuyMau { get; set; }

        [MaxLength(200)]
        public string LyDoKhongDat { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        [MaxLength(200)]
        public string DiaChiLayMau { get; set; }

        public bool? isXNLan2 { get; set; }

        [MaxLength(15)]
        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }
    }
}
