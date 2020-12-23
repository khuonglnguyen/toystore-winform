
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
    public class NCCBL
    {
        private static NCCBL Instance;
        public static NCCBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new NCCBL();
                }
                return Instance;
            }
        }
        private NCCBL() { }
        public DataTable GetDanhSachNCC()
        {
            return NCCDL.GetInstance.GetDanhSachNCC();
        }
        public bool ThemNCC(NhaCungCapDTO nccDTO)
        {
            return NCCDL.GetInstance.ThemNCC(nccDTO);
        }
        public bool ThemNCCFull(NhaCungCapDTO nccDTO)
        {
            return NCCDL.GetInstance.ThemNCCFull(nccDTO);
        }
        public string GetTenNCC(int MANCC)
        {
            return NCCDL.GetInstance.GetTenNCC(MANCC);
        }
        public bool XoaNCC(string MANCC)
        {
            return NCCDL.GetInstance.NgungHopTacNCC(MANCC);
        }
        public bool CapNhatNCC(NhaCungCapDTO nccDTO)
        {
            return NCCDL.GetInstance.CapNhatNCC(nccDTO);
        }
        public bool CheckMaNCC(string MANCC)
        {
            return NCCDL.GetInstance.CheckMaNCC(MANCC);
        }
    }
}
