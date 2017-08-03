using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSChiDinhDichVu")]
    public class ChiDinhDichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long RowIDChiDinh { get; set; }

        [MaxLength(15)]
        public string IDNhanVienChiDinh { get; set; }

        [MaxLength(40)]
        public string MaChiDinh { get; set; }

        public DateTime? NgayChiDinhLamViec { get; set; }

        public DateTime? NgayChiDinhHienTai { get; set; }

        [MaxLength(15)]
        public string IDGoiDichVu { get; set; }

        [MaxLength(15)]
        public string MaDonVi { get; set; }

        [MaxLength(15)]
        public string MaPhieu { get; set; }

        public decimal DonGia { get; set; }

        public byte? SoLuong { get; set; }

        public byte? TrangThai { get; set; }

        [MaxLength(15)]
        public string MaPhieuLan1 { get; set; }

        public bool isLayMauLai { get; set; }

        [MaxLength(15)]
        public string MaNVChiDinh { get; set; }

        [MaxLength(38)]
        public string MaTiepNhan { get; set; }

        public DateTime? NgayTiepNhan { get; set; }

        public bool isNhapLieu { get; set; }

        [MaxLength(3)]
        public string MaTrungTam { get; set; }

    }
}
