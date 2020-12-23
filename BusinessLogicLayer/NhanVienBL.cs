
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
    public class NhanVienBL
    {
        private static NhanVienBL Instance;
        public static NhanVienBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new NhanVienBL();
                }
                return Instance;
            }
        }
        private NhanVienBL() { }
        public bool ThemNhanVien(NhanVienDTO nvDTO)
        {
            return NhanVienDL.GetInstance.ThemNhanVien(nvDTO);
        }
        public DataTable GetDanhSachNhanVienTheoBoLoc(string TENNV, string MALOAI)
        {
            return NhanVienDL.GetInstance.GetDanhSachNhanVienTheoBoLoc(TENNV, MALOAI);
        }
        public DataTable GetDanhSachNhanVienTheoMa(int MaNV)
        {
            return NhanVienDL.GetInstance.GetDanhSachNhanVienTheoMa(MaNV);
        }
        public string GetTenNhanVien(int manv)
        {
            return NhanVienDL.GetInstance.GetTenNhanVien(manv);
        }
        public int GetMaNVMoi()
        {
            return NhanVienDL.GetInstance.GetMaNVMax() + 1;
        }
        public bool CheckMaNV(string MANV)
        {
            return NhanVienDL.GetInstance.CheckMaNV(MANV);
        }
        public byte[] GetHinhNhanVien(int manv)
        {
            return NhanVienDL.GetInstance.GetHinhNhanVien(manv);
        }
        public bool ThoiViecNhanVien(string MANV)
        {
            return NhanVienDL.GetInstance.ThoiViecNhanVien(MANV);
        }
        public bool SuaThongTinNhanVien(NhanVienDTO nvDTO)
        {
            return NhanVienDL.GetInstance.SuaThongTinNhanVien(nvDTO);
        }
    }
}
