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
    public class TrangChuBL
    {
        private static TrangChuBL Instance;
        public static TrangChuBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new TrangChuBL();
                }
                return Instance;
            }
        }
        private TrangChuBL() { }
        public int GetTongSanPhamDaBan()
        {
            return TrangChuDL.GetInstance.GetTongSanPhamDaBan();
        }
        public double GetTongDoanhThu()
        {
            return TrangChuDL.GetInstance.GetTongDoanhThu();
        }
        public int GetTongKhachHang()
        {
            return TrangChuDL.GetInstance.GetTongKhachHang();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongHomNay()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoSoLuongHomNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongHomQua()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoSoLuongHomQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuong7NgayQua()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoSoLuong7NgayQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongThangNay()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoSoLuongThangNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoSoLuongThangTruoc()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoSoLuongThangTruoc();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuHomNay()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoDoanhThuHomNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuHomQua()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoDoanhThuHomQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThu7NgayQua()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoDoanhThu7NgayQua();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuThangNay()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoDoanhThuThangNay();
        }
        public List<SanPhamDTO> GetTop10SPTheoDoanhThuThangTruoc()
        {
            return TrangChuDL.GetInstance.GetTop10SPTheoDoanhThuThangTruoc();
        }
        public double GetDoanhThuHomNay()
        {
            return TrangChuDL.GetInstance.GetDoanhThuHomNay();
        }
        public DoanhThuDTO GetDoanhThuHomQua()
        {
            return TrangChuDL.GetInstance.GetDoanhThuHomQua();
        }
        public List<DoanhThuDTO> GetDoanhThu(int songay)
        {
            return TrangChuDL.GetInstance.GetDoanhThu(songay);
        }
        public List<DoanhThuDTO> GetDoanhThu7NgayQua()
        {
            return TrangChuDL.GetInstance.GetDoanhThu7NgayQua();
        }
        public List<DoanhThuDTO> GetDoanhThuThangNay()
        {
            return TrangChuDL.GetInstance.GetDoanhThuThangNay();
        }
        public List<DoanhThuDTO> GetDoanhThuThangTruoc()
        {
            return TrangChuDL.GetInstance.GetDoanhThuThangTruoc();
        }
    }
}
