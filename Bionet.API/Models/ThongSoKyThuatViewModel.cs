using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class ThongSoKyThuatViewModel
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowIDMaps { get; set; }

        public string IDKyThuatXN { get; set; }

        public string IDThongSo { get; set; }

        public string TenThongSo { get; set; }

    }
}