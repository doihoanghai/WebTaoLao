using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSDanhMucGoiDichVuDVCS")]
    public class DanhMucGoiDichVuDVCS
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDGoiDichVuTrungTam { get; set; }

        [MaxLength(15)]
        public string IDGoiDichVuChung { get; set; }

        [MaxLength(50)]
        public string TenGoiDichVuChung { get; set; }


        public decimal? DonGia { get; set; }

        public double? ChietKhau { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        
    }
}
