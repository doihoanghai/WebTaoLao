using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucTrungTamSangLoc")]
    public class DanhMucTrungTamSangLoc
    {
        [Key]
        [Column(TypeName = "smallint")]
        public Int16 RowIDTTSL { get; set; }

        [MaxLength(15)]
        public string MaTTSL { get; set; }

        [MaxLength(100)]
        public string TenTTSL { get; set; }

        [MaxLength(200)]
        public string DiaChiTTSL { get; set; }

        [MaxLength(15)]
        public string SDTTTSL { get; set; }

        public bool? isLocked { get; set; }

        public byte[] Logo { get; set; }

        public byte[] HeaderReport { get; set; }

        public byte? Stt { get; set; }

        public byte? MaTongCuc { get; set; }
    }
}
