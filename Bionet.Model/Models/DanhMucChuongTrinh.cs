using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucChuongTrinh")]
    public class DanhMucChuongTrinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long RowIDChuongTrinh { get; set; }

        [MaxLength(10)]
        public string IDChuongTrinh { get; set; }
        
        [MaxLength(100)]
        public string TenChuongTrinh { get; set; }

        public DateTime? Ngaytao { get; set; }

        public DateTime? NgayHetHieuLuc { get; set; }

        public  bool? isLocked { get; set; }
    }
}
