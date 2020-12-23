using DTO; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class KhachHangDL
    {
        private static KhachHangDL Instance;
        public static KhachHangDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new KhachHangDL();
                }
                return Instance;
            }
        }
        private KhachHangDL() { }

        #region Lấy Mã Khách Hàng MAX
        public int GetMaKHMax()
        {
            try
            {
                string sql = "SELECT MAX(MAKH) FROM KHACHHANG";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Lấy Tên Khách Hàng
        public string GetTenKhachHang(string SDT)
        {
            try
            {
                string sql = "SELECT HOTEN FROM KHACHHANG WHERE SDT = '" + SDT + "' AND DAXOA=0";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                string ten = dt.Rows[0][0].ToString();
                return ten;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Tên Khách Hàng
        public string GetTenMaKH(string SDT)
        {
            try
            {
                string sql = "SELECT MAKH FROM KHACHHANG WHERE SDT = '" + SDT + "' AND DAXOA=0";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                string ten = dt.Rows[0][0].ToString();
                return ten;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Kiểm Tra Mã Khách Hàng
        public bool CheckMaKH(string MAKH)
        {
            try
            {
                string sql = "SELECT * FROM KHACHHANG WHERE MAKH='" + MAKH + "'";
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

        #region Lấy Danh Sách Khách Hàng
        public DataTable GetDanhSachKhachHang()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT MAKH as N'Mã KH',HOTEN as N'Tên KH',DIACHI as N'Địa Chỉ',SDT as N'SĐT',NGAYDANGKY as N'Ngày Đăng Ký',Email as N'Email',DOANHSO as N'Doanh Số' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM KHACHHANG WHERE DAXOA=0 AND MAKH != 1";
                dt = new DataTable();
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

        #region Lấy Danh Sách Khách Hàng Tìm Kiếm
        public DataTable GetDanhSachKhachHangTimKiem(string tenkh)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT MAKH as N'Mã KH',HOTEN as N'Tên KH',DIACHI as N'Địa Chỉ',SDT as N'SĐT',NGAYDANGKY as N'Ngày Đăng Ký',Email as N'Email',DOANHSO as N'Doanh Số' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM KHACHHANG WHERE DAXOA=0 AND MAKH != 1 AND HOTEN LIKE N'%"+tenkh+"%'";
                dt = new DataTable();
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

        #region Thêm Khách Hàng
        public bool ThemKhachHang(DTO.KhachHangDTO khDTO)
        {
            try
            {
                string sql = "INSERT INTO KHACHHANG VALUES(@HOTEN,@DIACHI,@SDT,@GIOITINH,@NGAYDANGKY,@EMAIL,@DOANHSO,@DAXOA)";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@HOTEN", khDTO.tenkh);
                cmd.Parameters.AddWithValue("@DIACHI", khDTO.diachi);
                cmd.Parameters.AddWithValue("@SDT", khDTO.sdt);
                cmd.Parameters.AddWithValue("@GIOITINH", khDTO.gioitinh);
                cmd.Parameters.AddWithValue("@NGAYDANGKY", khDTO.ngaydangky);
                cmd.Parameters.AddWithValue("@EMAIL", khDTO.email);
                cmd.Parameters.AddWithValue("@DOANHSO", khDTO.doanhso);
                cmd.Parameters.AddWithValue("@DAXOA", 0);
                cmd.Connection = con;
                int rows = cmd.ExecuteNonQuery();
                DataProvider.Disconnect(con);
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

        #region Xóa Khách Hàng
        public bool XoaKhachHang(string MAKH)
        {
            try
            {
                string sql = "UPDATE KHACHHANG SET DAXOA=1 WHERE MAKH='" + MAKH + "'";
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

        #region Sửa Thông Tin Khách Hàng
        public bool SuaThongTinKhachHang(DTO.KhachHangDTO khDTO)
        {
            try
            {
                string sql = "UPDATE KHACHHANG SET HOTEN = @HOTEN,DIACHI = @DIACHI,SDT = @SDT,GIOITINH = @GIOITINH,NGAYDANGKY = @NGAYDANGKY,EMAIL = @EMAIL WHERE MAKH = @MAKH";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MAKH", khDTO.makh);
                cmd.Parameters.AddWithValue("@HOTEN", khDTO.tenkh);
                cmd.Parameters.AddWithValue("@DIACHI", khDTO.diachi);
                cmd.Parameters.AddWithValue("@SDT", khDTO.sdt);
                cmd.Parameters.AddWithValue("@GIOITINH", khDTO.gioitinh);
                cmd.Parameters.AddWithValue("@NGAYDANGKY", khDTO.ngaydangky);
                cmd.Parameters.AddWithValue("@EMAIL", khDTO.email);
                cmd.Connection = con;
                int rows = cmd.ExecuteNonQuery();
                DataProvider.Disconnect(con);
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

        #region Cập Nhật Doanh Số Khách Hàng
        public bool CapNhatDoanhSoKhachHang(int MAKH,decimal DOANHSO)
        {
            try
            {
                string sql = "UPDATE KHACHHANG SET DOANHSO=DOANHSO+@DOANHSO WHERE MAKH = @MAKH";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MAKH", MAKH);
                cmd.Parameters.AddWithValue("@DOANHSO", DOANHSO);
                cmd.Connection = con;
                int rows = cmd.ExecuteNonQuery();
                DataProvider.Disconnect(con);
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
    }
}
