using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDotChuanDoan")]
    public class DotChuanDoan
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long rowIDDotChanDoan { get; set; }

        [MaxLength(36)]
        public string MaBenhNhan { get; set; }

        [MaxLength(16)]
        public string MaKhachHang { get; set; }


        public DateTime? NgayChanDoan { get; set; }

        [MaxLength(200)]
        public string ChanDoan { get; set; }

        [MaxLength(200)]
        public string KetQua { get; set; }

        [MaxLength(200)]
        public string GhiChu { get; set; }

        [Column(TypeName = "bigint")]
        public long RowIDBNCanTheoDoi { get; set; }

        [MaxLength(36)]
        public string MaDotChuanDoan { get; set; }

        [MaxLength(3)]
        public string MaTrungTam { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }
    }
}
