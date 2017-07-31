using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSXN_KetQua_ChiTiet")]
    public class XN_KetQua_ChiTiet
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowIDKetQuaChiTiet { get; set; }

        [MaxLength(38)]
        public string MaKQ { get; set; }

        [MaxLength(15)]
        public string MaDichVu { get; set; }

        [MaxLength(15)]
        public string MaThongSoXN { get; set; }

        [MaxLength(50)]
        public string TenThongSo { get; set; }

        [MaxLength(50)]
        public string TenKyThuat { get; set; }

        [MaxLength(15)]
        public string MaKyThuat { get; set; }

        [MaxLength(50)]
        public string GiaTri { get; set; }

        public double? GiaTriMinNu { get; set; }

        public double? GiaTriMaxNu { get; set; }

        [MaxLength(50)]
        public string GiaTriTrungBinhNu { get; set; }

        public double? GiaTriMinNam { get; set; }

        public double? GiaTriMaxNam { get; set; }

        [MaxLength(50)]
        public string GiaTriTrungBinhNam { get; set; }

        [Column(TypeName = "nchar")]
        [MaxLength(10)]
        public string DonViTinh { get; set; }

        public int? MaDonViTinh { get; set; }

        public bool isNguyCo { get; set; }

        [MaxLength(15)]
        public string MaXetNghiem { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }
    }
}
