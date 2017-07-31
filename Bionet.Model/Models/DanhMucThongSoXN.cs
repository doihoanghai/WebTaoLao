using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucThongSoXN")]
    public class DanhMucThongSoXN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDThongSo { get; set; }

        [Required]
        [MaxLength(15)]
        public string IDThongSoXN { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenThongSo { get; set; }

        [Column(TypeName = "smallint")]
        public Int16? MaDonViTinh { get; set; }

        public double? GiaTriMinNu { get; set; }

        public double? GiaTriMaxNu { get; set; }

        [MaxLength(50)]
        public string GiaTriTrungBinhNu { get; set; }

        [MaxLength(50)]
        public string GiaTriMacDinh { get; set; }

        public double? GiaTriMinNam { get; set; }

        public double? GiaTriMaxNam { get; set; }

        [MaxLength(50)]
        public string GiaTriTrungBinhNam { get; set; }

        [Column(TypeName = "smallint")]
        public byte? MaNhom { get; set; }

        [Column(TypeName = "smallint")]
        public byte? Stt { get; set; }

        [MaxLength(15)]
        public string GiaTri { get; set; }

        public bool? isLocked { get; set; }

        [MaxLength(50)]
        public string DonViTinh { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }
    }
}
