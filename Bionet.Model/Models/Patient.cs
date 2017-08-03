using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSPatient")]
    public class Patient
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowIDBenhNhan { get; set; }

        [Key]
        [MaxLength(38)]
        public string MaBenhNhan { get; set; }

        [MaxLength(50)]
        public string FatherName { get; set; }

        [MaxLength(50)]
        public string MotherName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FatherBirthday { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MotherBirthday { get; set; }

        [MaxLength(20)]
        public string FatherPhoneNumber { get; set; }

        [MaxLength(20)]
        public string MotherPhoneNumber { get; set; }

        [MaxLength(16)]
        [Column(TypeName = "nchar")]
        public string MaKhachHang { get; set; }

        [MaxLength(200)]
        public string DiaChi { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "nchar")]
        public string Para { get; set; }

        [MaxLength(50)]
        public string TenBenhNhan { get; set; }

        public DateTime? NgayGioSinh { get; set; }

        public int CanNang { get; set; }

        public int TuanTuoiKhiSinh { get; set; }

        [MaxLength(100)]
        public string NoiSinh { get; set; }

        public int QuocTichID { get; set; }

        public int DanTocID { get; set; }

        public int PhuongPhapSinh { get; set; }

        public int GioiTinh { get; set; }

        public bool? isDongBo { get; set; }

        public bool? isXoa { get; set; }

        [MaxLength(50)]
        public string IDThaiPhuTienSoSinh { get; set; }

        [MaxLength(15)]
        public string IDNhanVienXoa { get; set; }

        public DateTime? NgayGioXoa { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }
    }
}
