using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Web.Models
{
    [Table("ApplicationUserRole")]
    public class ApplicationUserRole
    {
        [StringLength(128)]
        [Key]
        [Column(Order = 1)]
        public string  UserId { get; set; }

        [StringLength(128)]
        [Key]
        [Column(Order = 2)]
        public string RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("RoleId")]
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
