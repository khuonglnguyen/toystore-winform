using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class LoaiNhanVienBL
    {
        private static LoaiNhanVienBL Instance;
        public static LoaiNhanVienBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new LoaiNhanVienBL();
                }
                return Instance;
            }
        }
        private LoaiNhanVienBL() { }
        public DataTable GetDanhSachLoaiNhanVien()
        {
            return LoaiNhanVienDL.GetInstance.GetDanhSachLoaiNhanVien();
        }
    }
}
