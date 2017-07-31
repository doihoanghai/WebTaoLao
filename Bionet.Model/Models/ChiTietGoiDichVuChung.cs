using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSChiTietGoiDichVuChung")]
    public class ChiTietGoiDichVuChung
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long RowIDChiTietGoiDichVuChung { get; set; }

        [MaxLength(15)]
        public string IDGoiDichVuChung { get; set; }

        [MaxLength(15)]
        public string IDDichVu { get; set; }
    }
}
