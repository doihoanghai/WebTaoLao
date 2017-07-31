using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.API.Models
{
    public class GoiDichVuTrungTamViewModel
    {
        public string MaTT { get; set; }
        public List<DanhMucGoiDichVuChung> lstGoiDichVu { get; set; }
    }
}