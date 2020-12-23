using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class PhieuNhapDL
    {
        private static PhieuNhapDL Instance;
        public static PhieuNhapDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new PhieuNhapDL();
                }
                return Instance;
            }
        }
        private PhieuNhapDL() { }

        #region Thêm Phiếu Nhập
        public bool ThemPhieuNhap(PhieuNhapDTO pnDTO)
        {
            try
            {
                string sql = "INSERT INTO PHIEUNHAP VALUES('" + pnDTO.NgayLap + "','" + pnDTO.MaNCC + "','" + pnDTO.MaNV + "',0)";
                int rows = DataProvider.JustExcuteNoParameter(sql);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Lấy Danh Sách Phiếu Nhập
        public DataTable GetDanhSachPhieuNhap()
        {
            try
            {
                string sql = "SELECT MAPHIEU AS N'Mã Phiếu', NGAYLAP AS N'Ngày Lập', MANCC AS N'Mã NCC', MANV AS N'Mã Nhân Viên', DANHAP AS N'Đã Nhập' FROM PHIEUNHAP pn WHERE DANHAP=0 AND pn.MAPHIEU IN (SELECT MAPHIEU FROM CHITIETPHIEUNHAP)";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi database: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region Xác Nhận Phiếu Nhập
        public bool XacNhan(int MaPhieu)
        {
            try
            {
                string sql = "UPDATE PHIEUNHAP SET DANHAP=1 WHERE MAPHIEU=" + MaPhieu;
                int rows = DataProvider.JustExcuteNoParameter(sql);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Cập Nhật Số Lượng Khi Đã Nhập
        public bool CapNhatSoLuong(int MaPhieu)
        {
            try
            {
                DataTable dt = CTPNDL.GetInstance.GetDanhSachPhieuNhap(MaPhieu);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SanPhamDL.GetInstance.CapNhatSoLuong(int.Parse(dt.Rows[i][0].ToString()), int.Parse(dt.Rows[i][1].ToString()));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Xóa Phiếu Nhập
        public bool XoaPN(int MAPN)
        {
            try
            {
                string sql = "DELETE PHIEUNHAP WHERE MAPHIEU=" + MAPN;
                int rows = DataProvider.JustExcuteNoParameter(sql);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Lấy Mã Phiếu Nhập Max
        public int GetMAPNMax()
        {
            try
            {
                string sql = "SELECT MAX(MAPHIEU) FROM PHIEUNHAP";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch (Exception)
            {
                return 1;
            }
        }
        #endregion
    }
}
