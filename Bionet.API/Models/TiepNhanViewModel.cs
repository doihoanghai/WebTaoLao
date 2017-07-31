using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class TiepNhanViewModel
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowIDTiepNhan { get; set; }

        public DateTime? NgayTiepNhan { get; set; }

        [MaxLength(15)]
        public string MaNVTiepNhan { get; set; }

        [MaxLength(15)]
        public string MaPhieu { get; set; }

        [MaxLength(15)]
        public string MaDonVi { get; set; }

        public bool isDaDanhGia { get; set; }

        [MaxLength(38)]
        public string MaTiepNhan { get; set; }

        [Column(TypeName = "bigint")]
        public long? RowIDPhieu { get; set; }

        public bool? isDaNhapLieu { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }

        public List<TiepNhanViewModel> lstTiepNhanVM { get; set; }
    }
}