using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class LoaiNhanVienDL
    {
        private static LoaiNhanVienDL Instance;
        public static LoaiNhanVienDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new LoaiNhanVienDL();
                }
                return Instance;
            }
        }
        private LoaiNhanVienDL() { }

        #region Lấy Danh Sách Loại Nhân Viên
        public DataTable GetDanhSachLoaiNhanVien()
        {
            try
            {
                string sql = "SELECT MALOAI AS N'Mã Loại NV', TENLOAI AS N'Tên Loại NV' FROM LOAINHANVIEN";
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
    }
}
