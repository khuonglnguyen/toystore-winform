using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int makh { get; set; }
        public string tenkh { get; set; }
        public string diachi { get; set; }
        public bool gioitinh { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
        public DateTime ngaydangky { get; set; }
        public bool daxoa { get; set; }
        public decimal doanhso { get; set; }
    }
}
