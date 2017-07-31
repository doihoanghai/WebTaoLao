using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSNhanVien")]
    public class NhanVien
    {
        [Key]
        public int RowIDNV { get; set; }

        [MaxLength(15)]
        public string MaNV { get; set; }

        public DateTime? NgayTao { get; set; }

        public byte MaBoPhan { get; set; }

        [MaxLength(15)]
        public string MaDonVi { get; set; }

        [MaxLength(20)]
        public string MaThongTin { get; set; }

        public bool isLocked { get; set; }

        [Column(TypeName = "smallint")]
        public Int16? IDCoSo { get; set; }

        [Column(TypeName = "smallint")]
        public Int16? IDChiCuc { get; set; }

        public byte IDTrungTamSangLoc { get; set; }
    }
}
