using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucNhom")]
    public class DanhMucNhom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDNhom { get; set; }

        [MaxLength(15)]
        public string IDNhom { get; set; }

        [MaxLength(50)]
        public string TenNhom { get; set; }
    }
}
