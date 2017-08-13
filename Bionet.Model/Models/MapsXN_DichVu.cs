using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSMapsXN_DichVu")]
    public class MapsXN_DichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long RowIDDichVuMaps { get; set; }

        [MaxLength(15)]
        public string IDDichVu { get; set; }

        [MaxLength(15)]
        public string IDKyThuatXN { get; set; }

        [MaxLength(50)]
        public string TenKyThuat { get; set; }

    }
}
