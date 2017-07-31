using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucDichVu")]
    public class DanhMucDichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDDichVu { get; set; }

        [MaxLength(15)]
        public string IDDichVu { get; set; }

        [MaxLength(50)]
        public string TenDichVu { get; set; }

        [Column(TypeName = "decimal")]
        public decimal? GiaDichVu { get; set; }

        public int MaNhom { get; set; }

        public bool isLocked { get; set; }

        public bool isGoiXn { get; set; }

        [MaxLength(100)]
        public string TenHienThiDichVu { get; set; }


    }
}
