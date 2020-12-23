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
    public class NhanVienDL
    {
        private static NhanVienDL Instance;
        public static NhanVienDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new NhanVienDL();
                }
                return Instance;
            }
        }
        private NhanVienDL() { }

        #region Thêm Nhân Viên
        public bool ThemNhanVien(NhanVienDTO nvDTO)
        {
            try
            {
                string sql = "INSERT INTO NHANVIEN VALUES(@HOTEN,@SDT,@NGAYSINH,@EMAIL,@GIOITINH,@HINHANH,@DATHOIVIEC,@MALOAI)";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@HOTEN", nvDTO.tennv);
                cmd.Parameters.AddWithValue("@SDT", nvDTO.sdt);
                cmd.Parameters.AddWithValue("@NGAYSINH", nvDTO.ngaysinh);
                cmd.Parameters.AddWithValue("@EMAIL", nvDTO.email);
                cmd.Parameters.AddWithValue("@GIOITINH", nvDTO.gioitinh);
                cmd.Parameters.AddWithValue("@HINHANH", nvDTO.hinhanh);
                cmd.Parameters.AddWithValue("@DATHOIVIEC", 0);
                cmd.Parameters.AddWithValue("@MALOAI", nvDTO.maloainv);
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

        #region Lấy Danh Sách Nhân Viên Theo Bộ Lọc
        public DataTable GetDanhSachNhanVienTheoBoLoc(string TENNV, string MALOAI)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "";
                if (TENNV != "")
                {
                    if (MALOAI == "-1")
                    {
                        sql = "SELECT MANV as N'Mã NV',HOTEN as N'Tên NV',MALOAI as N'Mã Loại NV',SDT as N'SĐT',NGAYSINH as N'Ngày Sinh',Email as N'Email',HINHANH as N'Hình Ảnh' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM NHANVIEN WHERE DATHOIVIEC=0";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAI != "-1")
                    {
                        sql = "SELECT MANV as N'Mã NV',HOTEN as N'Tên NV',MALOAI as N'Mã Loại NV',SDT as N'SĐT',NGAYSINH as N'Ngày Sinh',Email as N'Email',HINHANH as N'Hình Ảnh' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM NHANVIEN WHERE DATHOIVIEC=0 AND MALOAI LIKE '%" + MALOAI + "%'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                }
                else
                {
                    if (MALOAI == "-1")
                    {
                        sql = "SELECT MANV as N'Mã NV',HOTEN as N'Tên NV',MALOAI as N'Mã Loại NV',SDT as N'SĐT',NGAYSINH as N'Ngày Sinh',Email as N'Email',HINHANH as N'Hình Ảnh' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM NHANVIEN WHERE DATHOIVIEC=0 AND HOTEN LIKE '%" + TENNV + "%'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAI != "-1")
                    {
                        sql = "SELECT MANV as N'Mã NV',HOTEN as N'Tên NV',MALOAI as N'Mã Loại NV',SDT as N'SĐT',NGAYSINH as N'Ngày Sinh',Email as N'Email',HINHANH as N'Hình Ảnh' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM NHANVIEN WHERE DATHOIVIEC=0 AND MALOAI LIKE '%" + MALOAI + "%' AND HOTEN LIKE '%" + TENNV + "%'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi database: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region Lấy Danh Sách Nhân Viên Theo Mã
        public DataTable GetDanhSachNhanVienTheoMa(int MaNV)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT MANV as N'Mã NV',HOTEN as N'Tên NV',MALOAI as N'Mã Loại NV',SDT as N'SĐT',NGAYSINH as N'Ngày Sinh',Email as N'Email',HINHANH as N'Hình Ảnh' , CASE GIOITINH WHEN 0 THEN N'Nữ' WHEN 1 THEN N'Nam' END AS N'Giới Tính' FROM NHANVIEN WHERE MaNV="+MaNV;
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

        #region Lấy Hình Ảnh Nhân Viên
        public byte[] GetHinhNhanVien(int manv)
        {
            try
            {
                string sql = "SELECT HinhAnh FROM NHANVIEN WHERE MANV = '" + manv + "'";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                byte[] img = (byte[])dt.Rows[0][0];
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Lấy Mã Nhân Viên Max
        public int GetMaNVMax()
        {
            try
            {
                string sql = "SELECT MAX(MANV) FROM NHANVIEN";
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

        #region Kiểm Tra Mã Nhân Viên
        public bool CheckMaNV(string MANV)
        {
            try
            {
                string sql = "SELECT * FROM NHANVIEN WHERE MANV='" + MANV + "'";
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

        #region Thôi Việc Nhân Viên
        public bool ThoiViecNhanVien(string MANV)
        {
            try
            {
                string sql = "UPDATE NHANVIEN SET DATHOIVIEC=1 WHERE MANV='" + MANV + "'";
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

        #region Sửa Thông Tin Nhân Viên
        public bool SuaThongTinNhanVien(NhanVienDTO nvDTO)
        {
            try
            {
                string sql = "UPDATE NHANVIEN SET HOTEN = @HOTEN,SDT = @SDT,NGAYSINH = @NGAYSINH,EMAIL = @EMAIL,GIOITINH = @GIOITINH,HINHANH = @HINHANH,MALOAI = @MALOAI WHERE MANV = @MANV";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MANV", nvDTO.manv);
                cmd.Parameters.AddWithValue("@HOTEN", nvDTO.tennv);
                cmd.Parameters.AddWithValue("@SDT", nvDTO.sdt);
                cmd.Parameters.AddWithValue("@NGAYSINH", nvDTO.ngaysinh);
                cmd.Parameters.AddWithValue("@EMAIL", nvDTO.email);
                cmd.Parameters.AddWithValue("@GIOITINH", nvDTO.gioitinh);
                cmd.Parameters.AddWithValue("@HINHANH", nvDTO.hinhanh);
                cmd.Parameters.AddWithValue("@MALOAI", nvDTO.maloainv);
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

        #region Lấy Tên Nhân Viên
        public string GetTenNhanVien(int manv)
        {
            string sql = "SELECT * FROM NHANVIEN WHERE MANV = '" + manv + "'";
            DataTable dt = new DataTable();
            dt = DataProvider.GetTable(sql);
            string ten = dt.Rows[0][1].ToString();
            return ten;
        }
        #endregion
    }
}
