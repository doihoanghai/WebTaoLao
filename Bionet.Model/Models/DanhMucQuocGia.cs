using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucQuocGia")]
    public class DanhMucQuocGia
    {
        [Key]
        [Column(TypeName = "smallint")]
        public Int16 IDQuocGia { get; set; }

        [MaxLength(50)]
        public string TenQuocGia { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "nchar")]
        public string Stt { get; set; }

        public byte IDChauLuc { get; set; }
    }
}
