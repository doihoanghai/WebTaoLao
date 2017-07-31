using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSMapsXN_ThongSo")]
    public class MapsXN_ThongSo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long RowIDMaps { get; set; }

        [Required]
        [MaxLength(15)]
        public string IDKyThuatXN { get; set; }

        [Required]
        [MaxLength(15)]
        public string IDThongSoXN { get; set; }

        [MaxLength(50)]
        public string TenThongSo { get; set; }
    }
}
