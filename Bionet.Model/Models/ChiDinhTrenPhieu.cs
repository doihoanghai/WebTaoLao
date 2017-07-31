using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSChiDinhTrenPhieu")]
    public class ChiDinhTrenPhieu
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long RowID { get; set; }

        [MaxLength(15)]
        public string MaPhieu { get; set; }

        [MaxLength(15)]
        public string MaDichVu { get; set; }
    }
}
