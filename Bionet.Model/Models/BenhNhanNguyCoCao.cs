using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSBenhNhanNguyCoCao")]
    public class BenhNhanNguyCoCao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long rowIDBenhNhanCanTheoDoi { get; set; }

        [MaxLength(36)]
        public string MaBenhNhan { get; set; }

        [MaxLength(16)]
        [Column(TypeName = "varchar")]
        public string MaKhachHang { get; set; }

        [MaxLength(38)]
        public string MaTiepNhan { get; set; }

        public bool? isNguyCoCao { get; set; }

        [MaxLength(60)]
        public string TenBenhNhan { get; set; }

        [MaxLength(38)]
        public string MaThongTin { get; set; }

        [MaxLength(38)]
        public string MaTiepNhan2 { get; set; }

        public bool? isDaChanDoan { get; set; }

        public bool? isDieuTri { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }
    }
}
