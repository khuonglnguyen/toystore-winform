using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class HoaDonBL
    {
        private static HoaDonBL Instance;
        public static HoaDonBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new HoaDonBL();
                }
                return Instance;
            }
        }
        private HoaDonBL() { }
        public bool ThemHoaDon(HoaDonDTO hdDTO)
        {
            return HoaDonDL.GetInstance.ThemHoaDon(hdDTO);
        }
        public int GetSOHDMAX()
        {
            return HoaDonDL.GetInstance.GetSOHDMax();
        }
        public bool XoaHD(int SOHD)
        {
            return HoaDonDL.GetInstance.XoaHD(SOHD);
        }
        public DataSet InHoaDon(int SOHD)
        {
            return HoaDonDL.GetInstance.InHoaDon(SOHD);
        }
        public bool CapNhatSoLuongTienKhachHang(int SOHD, decimal TienKhachHangTra, decimal TienThua)
        {
            return HoaDonDL.GetInstance.CapNhatSoLuongTienKhachHang(SOHD, TienKhachHangTra, TienThua);
        }
    }
}
