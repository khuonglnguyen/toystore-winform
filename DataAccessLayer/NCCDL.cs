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
    public class NCCDL
    {
        private static NCCDL Instance;
        public static NCCDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new NCCDL();
                }
                return Instance;
            }
        }
        private NCCDL() { }

        #region Lấy Danh Sách NCC
        public DataTable GetDanhSachNCC()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT MANCC AS N'Mã NCC',TENNCC AS N'Tên NCC',DIACHI AS N'Địa Chỉ NCC',SDT AS N'SĐT',Email AS 'Email' FROM NCC WHERE NGUNGHOPTAC=0";
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

        #region Thêm NCC
        public bool ThemNCC(NhaCungCapDTO nccDTO)
        {
            try
            {
                string sql = "INSERT INTO NCC(TENNCC,NGUNGHOPTAC) VALUES(N'" + nccDTO.TenNCC + "',0)";
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

        #region Thêm NCC Full
        public bool ThemNCCFull(NhaCungCapDTO nccDTO)
        {
            try
            {
                string sql = "INSERT INTO NCC(TENNCC,DIACHI,SDT,Email,NgungHopTac) VALUES(N'" + nccDTO.TenNCC + "',N'" + nccDTO.DiaChi + "','" + nccDTO.SDT + "',N'" + nccDTO.Email + "',0)";
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

        #region Ngừng Hợp Tác NCC
        public bool NgungHopTacNCC(string MANCC)
        {
            try
            {
                string sql = "UPDATE NCC SET NGUNGHOPTAC=1 WHERE MANCC='" + MANCC + "'";
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

        #region Cập Nhật NCC
        public bool CapNhatNCC(NhaCungCapDTO nccDTO)
        {
            try
            {
                string sql = "UPDATE NCC SET TENNCC=N'" + nccDTO.TenNCC + "',DIACHI=N'" + nccDTO.DiaChi + "',SDT='" + nccDTO.SDT + "',Email=N'" + nccDTO.Email + "' WHERE MANCC='" + nccDTO.MaNCC + "'";
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

        #region Kiểm Tra Mã NCC
        public bool CheckMaNCC(string MANCC)
        {
            try
            {
                string sql = "SELECT * FROM NCC WHERE MANCC='" + MANCC + "'";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return false;
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

        #region Lấy Tên NCC
        public string GetTenNCC(int MANCC)
        {
            try
            {
                string sql = "SELECT TENNCC FROM NCC WHERE MANCC=" + MANCC;
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                return dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
    }
}

