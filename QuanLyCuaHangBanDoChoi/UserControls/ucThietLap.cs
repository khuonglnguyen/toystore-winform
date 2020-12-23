using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using QuanLyCuaHangBanDoChoi.Forms;

namespace QuanLyCuaHangBanDoChoi.UserControls
{
    public partial class ucThietLap : UserControl
    {
        public ucThietLap()
        {
            InitializeComponent();
        }
        bool b = false;
        private void txtNhapLai_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                lblNhapLai.Visible = true;
            }
            if (txtMatKhauMoi.Text == txtNhapLai.Text)
            {
                lblNhapLai.Visible = false;
                b = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (b)
            {
                if (txtMatKhauMoi.Text.Length >= 8 && txtMatKhauMoi.Text.Length <= 20)
                {
                    if (TaiKhoanBL.GetInstance.CheckLogin(frmDangNhap.TenDangNhap.ToString(), txtMatKhauHienTai.Text))
                    {
                        TaiKhoanBL.GetInstance.DoiMatKhau(frmDangNhap.TenDangNhap.ToString(), txtMatKhauMoi.Text);
                        this.Alert("Đã đổi mật khẩu thành công!", frmPopupNotification.enmType.Success);
                        txtNhapLai.Clear();
                        txtMatKhauMoi.Clear();
                        txtMatKhauHienTai.Clear();
                        lblNhapLai.Visible = false;
                    }
                    else
                    {
                        lblMatKhauHienTai.Visible = true;
                        txtNhapLai.Clear();
                        txtMatKhauMoi.Clear();
                        b = false;
                        lblNhapLai.Visible = false;
                    }
                }
                else
                {
                    frmThongBao frm = new frmThongBao();
                    frm.lblThongBao.Text = "Mật khẩu phải từ 8 đến 20 ký tự!";
                    frm.ShowDialog();
                }
            }
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

        private void txtMatKhauHienTai_TextChanged(object sender, EventArgs e)
        {
            lblMatKhauHienTai.Visible = false;
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                lblNhapLai.Visible = true;
            }
            if (txtMatKhauMoi.Text == txtNhapLai.Text)
            {
                lblNhapLai.Visible = false;
                b = true;
            }
        }
    }
}
