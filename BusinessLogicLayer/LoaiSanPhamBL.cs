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
    public class LoaiSanPhamBL
    {
        private static LoaiSanPhamBL Instance;
        public static LoaiSanPhamBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new LoaiSanPhamBL();
                }
                return Instance;
            }
        }
        private LoaiSanPhamBL() { }
        public DataTable GetDanhSachLoaiSanPham()
        {
            return LoaiSanPhamDL.GetInstance.GetDanhSachLoaiSanPham();
        }
        public bool ThemLoaiSanPham(LoaiSanPhamDTO lspDTO)
        {
            return LoaiSanPhamDL.GetInstance.ThemLoaiSanPham(lspDTO);
        }
        public bool NgungKinhDoanh(string MALOAISP)
        {
            return LoaiSanPhamDL.GetInstance.NgungKinhDoanh(MALOAISP);
        }
        public bool CapNhatLoaiSanPham(LoaiSanPhamDTO lspDTO)
        {
            return LoaiSanPhamDL.GetInstance.CapNhatLoaiSanPham(lspDTO);
        }
        public bool CheckMaLoaiSP(string MALOAISP)
        {
            return LoaiSanPhamDL.GetInstance.CheckMaLoaiSP(MALOAISP);
        }
    }
}
