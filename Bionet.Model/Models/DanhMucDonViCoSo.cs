using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucDonViCoSo")]
    public class DanhMucDonViCoSo
    {
        [Key]
        [Column(TypeName = "smallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 RowIDDVCS { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(50)]
        public string TenDVCS { get; set; }

        [MaxLength(100)]
        public string DiaChiDVCS { get; set; }

        [MaxLength(15)]
        public string SDTCS { get; set; }

        public bool? isLocked { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [Column(TypeName = "image")]
        public byte[] HeaderReport { get; set; }

        public int? Stt { get; set; }

        [MaxLength(15)]
        public string MaChiCuc { get; set; }

    }
}
