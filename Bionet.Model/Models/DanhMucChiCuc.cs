using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucChiCuc")]
    public class DanhMucChiCuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDChiCuc { get; set; }

        [MaxLength(15)]
        public string MaChiCuc { get; set; }

        [Column(TypeName = "nchar")]
        [MaxLength(10)]
        public string TenChiCuc { get; set; }

        [MaxLength(200)]
        public string DiaChiChiCuc { get; set; }

        [Required]
        [MaxLength(20)]
        public string SdtChiCuc { get; set; }

        public bool? isLocked { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [Column(TypeName = "image")]
        public byte[] HeaderReport { get; set; }

        [Column(TypeName = "smallint")]
        public Int16? Stt { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(3)]
        public string MaTrungTam { get; set; }

    }
}
