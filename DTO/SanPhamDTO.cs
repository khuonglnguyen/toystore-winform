using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public int masp { get; set; }
        public string tensp { get; set; }
        public string maloaisp { get; set; }
        public string dvt { get; set; }
        public int mansx { get; set; }
        public int mancc { get; set; }
        public DateTime ngaysx { get; set; }
        public DateTime ngayhethan { get; set; }
        public int soluong { get; set; }
        public decimal gianhap { get; set; }
        public int loinhuan { get; set; }
        public decimal giaban { get; set; }
        public int khuyenmai { get; set; }
        public byte[] hinhanh { get; set; }
        public double tongdoanhthu { get; set; }
    }
}
