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
    public class SanPhamDL
    {
        private static SanPhamDL Instance;
        public static SanPhamDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SanPhamDL();
                }
                return Instance;
            }
        }
        private SanPhamDL() { }

        #region Lấy Tổng Sản Phẩm Đã Bán
        public int GetTongSanPhamDaBan()
        {
            string sql = "SELECT SUM(SOLUONG) FROM CTHD";
            DataTable dt = new DataTable();
            dt = DataProvider.GetTable(sql);
            int sl = int.Parse(dt.Rows[0][0].ToString());
            return sl;
        }
        #endregion

        #region Lấy Mã Sản Phẩm Max
        public int GetMaSPMax()
        {
            try
            {
                string sql = "SELECT MAX(MASP) FROM SANPHAM";
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

        #region Lấy Tên Sản Phẩm
        public string GetTenSP(int MASP)
        {
            try
            {
                string sql = "SELECT TENSP FROM SANPHAM WHERE MASP="+ MASP;
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

        #region Kiểm Tra Mã Sản Phẩm
        public bool CheckMaSP(string MASP)
        {
            try
            {
                string sql = "SELECT * FROM SANPHAM WHERE MASP='"+MASP+"'";
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

        #region Lấy Danh Sách Sản Phẩm
        public DataTable GetDanhSachSanPham()
        {
            try
            {
                string sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE NGUNGKINHDOANH = '0'";
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

        #region Lấy Danh Sách Sản Phẩm Theo NCC
        public DataTable GetDanhSachSanPhamTheoNCC(int MANCC)
        {
            try
            {
                string sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE NGUNGKINHDOANH = '0' AND MANCC ="+MANCC;
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

        #region Lấy Danh Sách Sản Phẩm Theo Bộ Lọc
        public DataTable GetDanhSachSanPhamTheoBoLoc(string TENSP,string MALOAISP,string MANCC)
        {
            try
            {
                DataTable dt=new DataTable();
                string sql = "";
                if (TENSP != "")
                {
                    if (MALOAISP=="-1" && MANCC=="-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE TENSP LIKE N'%" + TENSP + "%' AND NGUNGKINHDOANH='0'";//
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAISP != "-1" && MANCC == "-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE TENSP LIKE N'%" + TENSP + "%' AND MALOAISP LIKE '%" + MALOAISP + "%' AND NGUNGKINHDOANH='0'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAISP == "-1" && MANCC != "-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE TENSP LIKE N'%" + TENSP + "%' AND MANCC LIKE '%" + MANCC + "%' AND NGUNGKINHDOANH='0'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAISP != "-1" && MANCC != "-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE TENSP LIKE N'%" + TENSP + "%' AND MALOAISP LIKE '%" + MALOAISP + "%' AND MANCC LIKE '%" + MANCC + "%' AND NGUNGKINHDOANH='0'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                }
                else
                {
                    if (MALOAISP == "-1" && MANCC == "-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE NGUNGKINHDOANH='0'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAISP != "-1" && MANCC == "-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE MALOAISP LIKE '%" + MALOAISP + "%' AND NGUNGKINHDOANH='0'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAISP == "-1" && MANCC != "-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận', DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE MANCC LIKE '%" + MANCC + "%' AND NGUNGKINHDOANH='0'";
                        dt = new DataTable();
                        dt = DataProvider.GetTable(sql);
                    }
                    else if (MALOAISP != "-1" && MANCC != "-1")
                    {
                        sql = "SELECT MASP as N'Mã SP',TENSP as N'Tên SP',MALOAISP as N'Mã Loại SP',DVT as N'ĐVT',MANCC as N'Mã NCC',NGAYSX as N'Ngày SX',NGAYHETHAN as N'Ngày Hết Hạn',SOLUONG as N'Số Lượng', DONGIANHAP as N'Đơn Giá Nhập', LOINHUAN as N'Lợi Nhuận',DONGIABAN as N'Đơn Giá Bán',KHUYENMAI as N'Khuyến Mãi',HINHANH as N'Hình Ảnh' FROM SanPham WHERE MALOAISP LIKE '%" + MALOAISP + "%' AND MANCC LIKE '%" + MANCC + "%' AND NGUNGKINHDOANH='0'";
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

        #region Ngừng Kinh Doanh Sản Phẩm
        public bool NgungKinhDoanhSanPham(string MASP)
        {
            try
            {
                string sql = "UPDATE SANPHAM SET NGUNGKINHDOANH=1 WHERE MASP='" + MASP + "'";
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

        #region Thêm Sản Phẩm
        public bool ThemSanPham(SanPhamDTO spDTO)
        {
            try
            {
                string sql = "INSERT INTO SANPHAM VALUES(@TENSP,@MALOAISP,@DVT,@MANCC,@NGAYSX,@NGAYHETHAN,@SOLUONG,@GIANHAP,@LOINHUAN,@GIABAN,@KHUYENMAI,@HINHANH,@NGUNGKINHDOANH)";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@TENSP", spDTO.tensp);
                cmd.Parameters.AddWithValue("@MALOAISP", spDTO.maloaisp);
                cmd.Parameters.AddWithValue("@DVT", spDTO.dvt);
                cmd.Parameters.AddWithValue("@MANCC", spDTO.mancc);
                cmd.Parameters.AddWithValue("@NGAYSX", spDTO.ngaysx);
                cmd.Parameters.AddWithValue("@NGAYHETHAN", spDTO.ngayhethan);
                cmd.Parameters.AddWithValue("@SOLUONG", 0);
                cmd.Parameters.AddWithValue("@GIABAN", spDTO.giaban);
                cmd.Parameters.AddWithValue("@GIANHAP", spDTO.gianhap);
                cmd.Parameters.AddWithValue("@LOINHUAN", spDTO.loinhuan);
                cmd.Parameters.AddWithValue("@KHUYENMAI", spDTO.khuyenmai);
                cmd.Parameters.AddWithValue("@HINHANH", spDTO.hinhanh);
                cmd.Parameters.AddWithValue("@NGUNGKINHDOANH", 0);
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

        #region Sửa Sản Phẩm
        public bool SuaSanPham(SanPhamDTO spDTO)
        {
            try
            {
                string sql = "UPDATE SANPHAM SET TENSP = @TENSP,NGAYSX = @NGAYSX,NGAYHETHAN = @NGAYHETHAN,DONGIANHAP = @DONGIANHAP,LOINHUAN = @LOINHUAN,DONGIABAN = @DONGIABAN,KHUYENMAI = @KHUYENMAI,HINHANH = @HINHANH WHERE MASP = @MASP";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MASP", spDTO.masp);
                cmd.Parameters.AddWithValue("@TENSP", spDTO.tensp);
                cmd.Parameters.AddWithValue("@NGAYSX", spDTO.ngaysx);
                cmd.Parameters.AddWithValue("@NGAYHETHAN", spDTO.ngayhethan);
                cmd.Parameters.AddWithValue("@DONGIANHAP", spDTO.gianhap);
                cmd.Parameters.AddWithValue("@LOINHUAN", spDTO.loinhuan);
                cmd.Parameters.AddWithValue("@DONGIABAN", spDTO.giaban);
                cmd.Parameters.AddWithValue("@KHUYENMAI", spDTO.khuyenmai);
                cmd.Parameters.AddWithValue("@HINHANH", spDTO.hinhanh);
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

        #region Cập Nhật Số Lượng
        public bool CapNhatSoLuong(int MaSP, int SoLuong)
        {
            try
            {
                string sql = "UPDATE SANPHAM SET SoLuong = SoLuong+@SoLuong WHERE MASP = @MASP";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MASP", MaSP);
                cmd.Parameters.AddWithValue("@SOLUONG", SoLuong);
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

        #region Cập Nhật Số Lượng Khi Bán Hàng
        public bool CapNhatSoLuongKhiBanHang(int MaSP, int SoLuong)
        {
            try
            {
                string sql = "UPDATE SANPHAM SET SoLuong = SoLuong-@SoLuong WHERE MASP = @MASP";
                SqlConnection con = DataProvider.Openconnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MASP", MaSP);
                cmd.Parameters.AddWithValue("@SOLUONG", SoLuong);
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

        #region Lấy Tổng Doanh Thu
        public double GetTongDoanhThu()
        {
            string sql = "SELECT SUM(THANHTIEN) FROM HOADON";
            DataTable dt = new DataTable();
            dt = DataProvider.GetTable(sql);
            double doanhthu = double.Parse(dt.Rows[0][0].ToString());
            return doanhthu;
        }
        #endregion

        #region Lấy Tổng Khách Hàng
        public int GetTongKhachHang()
        {
            string sql = "SELECT COUNT(*) FROM KHACHHANG";
            DataTable dt = new DataTable();
            dt = DataProvider.GetTable(sql);
            int kh = int.Parse(dt.Rows[0][0].ToString());
            return kh;
        }
        #endregion

        #region Lấy Top 10 Sản Phẩm
        public List<SanPhamDTO> GetTop10SP(int top)
        {
            string sql = "SELECT TOP "+top+" cthd.MASP,sp.TENSP,SUM(cthd.SOLUONG) FROM CTHD cthd JOIN SANPHAM sp ON cthd.MASP=sp.MASP GROUP BY cthd.MASP, sp.TENSP ORDER BY SUM(cthd.SOLUONG)";
            DataTable dt = new DataTable();
            List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
            dt = DataProvider.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPhamDTO spDTO = new SanPhamDTO();
                spDTO.masp = int.Parse(dt.Rows[i][0].ToString());
                spDTO.tensp = dt.Rows[i][1].ToString();
                spDTO.soluong = int.Parse(dt.Rows[i][2].ToString());

                lstSP.Add(spDTO);
            }
            return lstSP;
        }
        #endregion

        #region Lấy Doanh Thu Hôm Nay
        public double GetDoanhThuHomNay()
        {
            try
            {
                string sql = "SELECT SUM(hd.THANHTIEN) FROM HOADON hd WHERE (YEAR(hd.NGAYLAP) = YEAR('" + DateTime.Now + "') AND MONTH(hd.NGAYLAP) = MONTH('" + DateTime.Now + "') AND DAY(hd.NGAYLAP) = DAY('" + DateTime.Now + "')) AND hd.DATHANHTOAN = '1'";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                double doanhthu = double.Parse(dt.Rows[0][0].ToString());
                return doanhthu;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        #endregion
    }
}
