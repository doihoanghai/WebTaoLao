using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucDichVuTheoDonVi")]
    public class DanhMucDichVuTheoDonVi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long RowIDDichVuTheoDonVi { get; set; }

        [MaxLength(15)]
        public string MaDonVi { get; set; }

        [MaxLength(15)]
        public string IDDichVu { get; set; }

        [MaxLength(50)]
        public string TenDichVu { get; set; }

        [MaxLength(100)]
        public string TenHienThi { get; set; }

        [Column(TypeName = "decimal")]
        public decimal? DonGia { get; set; }

        [MaxLength(15)]
        public string MaNhom { get; set; }

        public bool? isLocked { get; set; }

        public double? ChietKhau { get; set; }

        public bool? isDongBo { get; set; }

        [MaxLength(3)]
        public string MaTrungTam { get; set; }
    }
}
