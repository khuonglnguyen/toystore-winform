using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class KhachHangBL
    {
        private static KhachHangBL Instance;
        public static KhachHangBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new KhachHangBL();
                }
                return Instance;
            }
        }
        private KhachHangBL() { }
        public string GetTenKhachHang(string SDT)
        {
            return KhachHangDL.GetInstance.GetTenKhachHang(SDT);
        }
        public string GetTenMaKH(string SDT)
        {
            return KhachHangDL.GetInstance.GetTenMaKH(SDT);
        }
        public int GetMaKHMax()
        {
            return KhachHangDL.GetInstance.GetMaKHMax()+1;
        }
        public bool CheckMaKH(string MAKH)
        {
            return KhachHangDL.GetInstance.CheckMaKH(MAKH);
        }
        public DataTable GetDanhSachKhachHang()
        {
            return KhachHangDL.GetInstance.GetDanhSachKhachHang();

        }
        public bool ThemKhachHang(DTO.KhachHangDTO khDTO)
        {
            return KhachHangDL.GetInstance.ThemKhachHang(khDTO);
        }
        public bool XoaKhachHang(string MAKH)
        {
            return KhachHangDL.GetInstance.XoaKhachHang(MAKH);
        }
        public bool SuaThongTinKhachHang(DTO.KhachHangDTO khDTO)
        {
            return KhachHangDL.GetInstance.SuaThongTinKhachHang(khDTO);
        }
        public DataTable GetDanhSachKhachHangTimKiem(string tenkh)
        {
            return KhachHangDL.GetInstance.GetDanhSachKhachHangTimKiem(tenkh);
        }
        public bool CapNhatDoanhSoKhachHang(int MAKH, decimal DOANHSO)
        {
            return KhachHangDL.GetInstance.CapNhatDoanhSoKhachHang(MAKH, DOANHSO);
        }
    }
}
