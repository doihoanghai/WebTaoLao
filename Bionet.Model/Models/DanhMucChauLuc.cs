using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucChauLuc")]
    public class DanhMucChauLuc
    {
        [Key]
        public byte IDChauLuc { get; set; }

        [MaxLength(50)]
        public string TenChauLuc { get; set; }

        public byte? Stt { get; set; }
    }
}
