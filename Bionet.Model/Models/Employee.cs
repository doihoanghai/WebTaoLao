using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("PSEmployee")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowID { get; set; }

        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string EmployeeCode { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public int Sex { get; set; }

        [MaxLength(50)]
        public string Mobile { get; set; }

        [MaxLength(50)]
        public string IDCard { get; set; }

        public string Address { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        public int PositionCode { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public int EmployeeGroupID { get; set; }

        [MaxLength(50)]
        public string ChucDanh { get; set; }

        [MaxLength(15)]
        public string MaDVCS { get; set; }

        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string MaTrungTam { get; set; }
    }
}
