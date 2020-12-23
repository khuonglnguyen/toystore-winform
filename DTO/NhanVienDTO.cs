using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int manv { get; set; }
        public string tennv { get; set; }
        public int maloainv { get; set; }
        public bool gioitinh { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
        public DateTime ngaysinh { get; set; }
        public bool dathoiviec { get; set; }
        public byte[] hinhanh { get; set; }
    }
}
