using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSMauXetNghiem")]
    public class MauXetNghiem
    {
        [Key]
        [Column(TypeName = "bigint")]
        public int RowIDMau { get; set; }

        [Column(TypeName = "bigint")]
        public int RowIDPhieu { get; set; }

        [MaxLength(15)]
        public string MaXetNghiem { get; set; }
    }
}
