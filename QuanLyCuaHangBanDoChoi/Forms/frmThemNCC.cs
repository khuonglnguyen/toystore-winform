
using BusinessLogicLayer;
using DTO;
using System;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDoChoi.Forms
{
    public partial class frmThemNCC : Form
    {
        public frmThemNCC()
        {
            InitializeComponent();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text == "")
            {
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập tên nhà cung cấp!";
                frm.ShowDialog();
                return;
            }
            NhaCungCapDTO nccDTO = new NhaCungCapDTO();
            nccDTO.TenNCC = txtTenNCC.Text;
            if (NCCBL.GetInstance.ThemNCC(nccDTO))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
