using BusinessLogicLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace QuanLyCuaHangBanDoChoi.Forms
{
    public partial class frmDangNhap : Form
    {


        public frmDangNhap()
        {
            InitializeComponent();
        }

        public static int Quyen;
        public static int TenDangNhap;

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '●';

            txtTenDangNhap.Visible = false;
            txtMatKhau.Visible = false;
            btnShowPass.Visible = false;

            timer1.Start();
            timer2.Start();

            lbDangNhap.ForeColor = Color.FromArgb(240, 240, 240);
            lbMatKhau.ForeColor = Color.FromArgb(240, 240, 240);
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            XuLyDangNhap();
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        private void XuLyDangNhap()
        {
            Cursor = Cursors.AppStarting;
            if (TaiKhoanBL.GetInstance.CheckLogin(txtTenDangNhap.Text, txtMatKhau.Text) == true)
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 100, 0);
                TenDangNhap = int.Parse(txtTenDangNhap.Text);
                Quyen = TaiKhoanBL.GetInstance.GetMaQuyen(int.Parse(txtTenDangNhap.Text));
                txtMatKhau.Text = "";
                txtTenDangNhap.Text = "";
                Cursor = Cursors.Default;
                this.Alert("Đăng nhập thành công...", frmPopupNotification.enmType.Success);
                frmChinh frm = new frmChinh();
                frm.Show();
                this.Hide();
            }
            else
            {
                Cursor = Cursors.Default;
                frmThongBao frm = new frmThongBao();
                frm.lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng!\nVui lòng nhập lại...";
                frm.Show();
            }
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Top <= 345)
            {
                txtTenDangNhap.Top += 1;
                pnlTenDangNhap.Top += 1;
                btnShowPass.Top += 1;

                txtMatKhau.Top += 1;
                pnlMatKhau.Top += 1;
            }
            else
                timer1.Stop();
        }
        int R1 = 26;
        int G1 = 25;
        int B1 = 29;

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbDangNhapLOGO.ForeColor = Color.FromArgb(R1, G1, B1);
            lbDangNhap.ForeColor = Color.FromArgb(R1, G1, B1);
            lbMatKhau.ForeColor = Color.FromArgb(R1, G1, B1);
            if (R1 > 17)
                R1 -= 1;
            if (G1 < 145)
                G1 += 5;
            if (B1 < 249)
                B1 += 10;
            if (R1 == 17 && G1 == 145 && B1 == 249)
            {
                txtTenDangNhap.Visible = true;
                txtMatKhau.Visible = true;
                btnShowPass.Visible = true;
                txtTenDangNhap.Focus();
                timer2.Stop();
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (btnShowPass.ImageIndex == 0)
            {
                btnShowPass.ImageIndex = 1;
                txtMatKhau.Focus();
            }
            else
            {
                btnShowPass.ImageIndex = 0;
                txtMatKhau.Focus();
            }
            if (txtMatKhau.PasswordChar == '●')
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '●';
            }
        }

        private void btnShowPass_MouseHover(object sender, EventArgs e)
        {
            if (btnShowPass.ImageIndex == 0)
                toolTip1.Show("Hiện mật khẩu", btnShowPass);
            else
                toolTip1.Show("Ẩn mật khẩu", btnShowPass);
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                btnDangNhap.BackColor = Color.DimGray;
            }
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                btnDangNhap.BackColor = Color.DimGray;
            }
        }
    }
}

