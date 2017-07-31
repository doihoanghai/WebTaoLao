using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucDanToc")]
    public class DanhMucDanToc
    {
        [Key]
        public int IDDanToc { get; set; }

        [MaxLength(50)]
        public string TenDanToc { get; set; }

        [Column(TypeName = "nchar")]
        [MaxLength(10)]
        public string STT { get; set; }

        [Column(TypeName = "smallint")]
        public Int16? IDQuocGia { get; set; }
    }
}
