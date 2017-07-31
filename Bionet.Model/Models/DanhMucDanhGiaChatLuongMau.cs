using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucDanhGiaChatLuongMau")]
    public class DanhMucDanhGiaChatLuongMau
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDChatLuongMau { get; set; }

        [MaxLength(100)]
        public string ChatLuongMau { get; set; }

        public bool? isLocked { get; set; }

        [MaxLength(5)]
        public string IDDanhGiaChatLuongMau { get; set; }
    }
}
