using Bionet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Model.Models
{
    public class MapsDichVu_KyThuatViewModel
    {
        public string idDichVu { get; set; }
        public List<KyThuatXNMapViewModel> mapdvkt { get; set; }
    }
}
