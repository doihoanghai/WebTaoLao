using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PsPerson")]
    public class Person
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowPersonID { get; set; }

        [MaxLength(100)]
        public string HoTen { get; set; }

        public DateTime? NgayGioSinh { get; set; }

        [MaxLength(100)]
        public string NoiSinh { get; set; }

        [MaxLength(20)]
        public string IDCard { get; set; }

        public int QuocTichID { get; set; }

        public int DanTocID { get; set; }

        [MaxLength(200)]
        public string DiaChi { get; set; }

        [MaxLength(20)]
        public string SoDienThoai { get; set; }

        public byte SoTuanThaiLucSinh { get; set; }

        [Column(TypeName = "smallint")]
        public Int16? CanNangLucSinh { get; set; }

        public bool PhuongPhapSinh { get; set; }

        public bool GioiTinh { get; set; }

        [MaxLength(38)]
        public string MaThongTin { get; set; }
    }
}
