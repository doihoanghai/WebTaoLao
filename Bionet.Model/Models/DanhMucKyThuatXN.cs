using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucKyThuatXN")]
    public class DanhMucKyThuatXN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDKyThuatXn { get; set; }

        [Required]
        [MaxLength(15)]
        public string IDKyThuatXN { get; set; }

        public byte? STT { get; set; }

        [Required]
        public bool? isLocked { get; set; }

        [MaxLength(50)]
        public string TenKyThuat { get; set; }

        [MaxLength(100)]
        public string TenHienThiKyThuat { get; set; }
    }
}
