using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSXN_TraKQ_ChiTiet")]
    public class XN_TraKQ_ChiTiet
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long RowIDXN_TraKetQua_ChiTiet { get; set; }

        [MaxLength(10)]
        public string MaDichVu { get; set; }

        [MaxLength(15)]
        public string IDThongSoXN { get; set; }

        [MaxLength(50)]
        public string TenThongSo { get; set; }

        [MaxLength(50)]
        public string TenKyThuat { get; set; }

        [MaxLength(15)]
        public string IDKyThuat { get; set; }

        [MaxLength(50)]
        public string GiaTri1 { get; set; }

        public double? GiaTriMin { get; set; }

        public double? GiaTriMax { get; set; }

        [MaxLength(50)]
        public string DonViTinh { get; set; }

        public bool isNguyCo { get; set; }

        [MaxLength(50)]
        public string GiaTriTrungBinh { get; set; }

        [MaxLength(50)]
        public string GiaTri2 { get; set; }

        [MaxLength(50)]
        public string GiaTriCuoi { get; set; }

        public int? IDDonViTinh { get; set; }

        [MaxLength(50)]
        public string KetLuan { get; set; }

        [MaxLength(38)]
        public string MaTiepNhan { get; set; }

        [MaxLength(15)]
        public string MaPhieu { get; set; }

        public bool isDaDuyetKQ { get; set; }

        public bool isMauXNLai { get; set; }

        public byte? Stt { get; set; }

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
