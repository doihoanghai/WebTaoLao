using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSChiTietDanhGiaChatLuong")]
    public class ChiTietDanhGiaChatLuong
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long IDMapsLyDoKhongDat { get; set; }

        [MaxLength(15)]
        public string IDPhieu { get; set; }

        [MaxLength(5)]
        public string IDDanhGiaChatLuongMau { get; set; }
    }
}
