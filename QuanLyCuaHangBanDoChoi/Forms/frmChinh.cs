using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using QuanLyCuaHangBanDoChoi.UserControls;

namespace QuanLyCuaHangBanDoChoi.Forms
{
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
        }
        
        ColorProgressBar.ColorProgressBar ProgressBar;
        Label lblPhanTram;
        string ucName;
        Task taskLoadProgressBar;
        Task taskLoadUserControl;

        public void AddControl(string ucname)
        {
            ucName = ucname;
            //Xóa các uc trước khi thêm uc mới vào
            foreach (UserControl uc in panelControls.Controls.OfType<UserControl>())
            {
                panelControls.Controls.Remove(uc);
            }
            //Add vào ProgressBar từ ucProgressBar
            ucProgressbar ucprogress = new ucProgressbar();
            ucprogress.Dock = DockStyle.Fill;
            panelControls.Controls.Add(ucprogress);
            panelControls.Controls["ucProgressBar"].BringToFront();
            //Ánh xạ lên biến toàn cục
            ProgressBar = ucprogress.progressLoading;
            lblPhanTram = ucprogress.lblPhanTram;

            taskLoadProgressBar = new Task(LoadProgressBar);
            taskLoadUserControl = new Task(LoadUserControl);
            taskLoadProgressBar.Start();
            taskLoadUserControl.Start();
        }

        public void LoadProgressBar()
        {
            for (int i = 0; i <= 100; i++)
            {
                //Tách ra khỏi Thread chính
                ProgressBar.Invoke(new MethodInvoker(delegate
                {
                    ProgressBar.Value = i;
                }));

                //Tách ra khỏi Thread chính
                lblPhanTram.Invoke(new MethodInvoker(delegate
                {
                    lblPhanTram.Text = i.ToString() + "%";
                }));
            }
        }

        public void LoadUserControl()
        {
            taskLoadProgressBar.Wait();
            panelControls.Invoke(new MethodInvoker(delegate ()
            {
                switch (ucName)
                {
                    case "ucTrangChu":
                        {
                            ucTrangChu ucTC = new ucTrangChu();
                            ucTC.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucTC);
                        }
                        break;
                    case "ucSanPham":
                        {
                            ucQuanLySanPham ucSP = new ucQuanLySanPham();
                            ucSP.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucSP);
                        }
                        break;
                    case "ucNhapSanPham":
                        {
                            ucNhapSanPham ucNSP = new ucNhapSanPham();
                            ucNSP.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucNSP);
                        }
                        break;
                    case "ucBanSanPham":
                        {
                            ucBanSanPham ucBH = new ucBanSanPham();
                            ucBH.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucBH);
                        }
                        break;
                    case "ucNhanVien":
                        {
                            ucNhanVien ucNV = new ucNhanVien();
                            ucNV.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucNV);
                        }
                        break;
                    case "ucKhachHang":
                        {
                            ucKhachHang ucKH = new ucKhachHang();
                            ucKH.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucKH);
                        }
                        break;
                    case "ucThietLap":
                        {
                            ucThietLap ucTL = new ucThietLap();
                            ucTL.Dock = DockStyle.Fill;
                            AddControlsIntoPanel(ucTL);
                        }
                        break;
                }
            }));

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnTrangChu);
            if (btnTrangChu.ForeColor == Color.White)
            {
                btnTrangChu.ForeColor = Color.FromArgb(255,255,254);
                btnTrangChu.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnTrangChu);
                AddControl("ucTrangChu");
            }
            else
            {
                btnTrangChu.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            if (btnTrangChu.ForeColor == Color.White)
            {
                btnTrangChu.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnTrangChu.FlatAppearance.MouseDownBackColor = Color.White;
            }
            

            Cursor = Cursors.Default;

        }
        

        private void AddControlsIntoPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }

        private void check_reset(Button button)
        {
            foreach (Control control in panelLeft.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button btn = (Button)control;
                    if (btn.Text != button.Text)
                    {
                        if (btn.BackColor != Color.White)
                        {
                            btn.BackColor = Color.FromArgb(17,145,249);
                            btn.ForeColor = Color.White;
                            //btn.Image = (Image)Properties.Resources.ResourceManager.GetObject(btn.AccessibleName + "_blue");
                        }
                        btn.FlatAppearance.MouseDownBackColor = Color.White;
                    }
                }
            }
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnBanSanPham);
            if (btnBanSanPham.ForeColor == Color.White)
            {
                btnBanSanPham.ForeColor = Color.FromArgb(255, 255, 254);
                btnBanSanPham.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnBanSanPham);
                AddControl("ucBanSanPham");
            }
            if (btnBanSanPham.ForeColor == Color.White)
            {
                btnBanSanPham.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnBanSanPham.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            timerPanel.Start();
            Cursor = Cursors.Default;
        }

        int PanelWidth;
        bool isCollapsed;

        private void timerPanel_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 8;
                if (panelLeft.Width >= PanelWidth)
                {
                    timerPanel.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 8;
                if (panelLeft.Width <= 64)
                {
                    timerPanel.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnSanPham);
            if (btnSanPham.ForeColor == Color.White)
            {
                btnSanPham.ForeColor = Color.FromArgb(255, 255, 254);
                btnSanPham.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnSanPham);
                AddControl("ucSanPham");
            }
            if (btnSanPham.ForeColor == Color.White)
            {
                btnSanPham.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnSanPham.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnNhanVien);
            if (btnNhanVien.ForeColor == Color.White)
            {
                btnNhanVien.ForeColor = Color.FromArgb(255, 255, 254);
                btnNhanVien.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnNhanVien);
                AddControl("ucNhanVien");
            }
            if (btnNhanVien.ForeColor == Color.White)
            {
                btnNhanVien.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnNhanVien.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnKhachHang);
            if (btnKhachHang.ForeColor == Color.White)
            {
                btnKhachHang.ForeColor = Color.FromArgb(255, 255, 254);
                btnKhachHang.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnKhachHang);
                AddControl("ucKhachHang");
            }
            if (btnKhachHang.ForeColor == Color.White)
            {
                btnKhachHang.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnKhachHang.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }

        private void btnThietLap_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnThietLap);
            if (btnThietLap.ForeColor == Color.White)
            {
                btnThietLap.ForeColor = Color.FromArgb(255, 255, 254);
                btnThietLap.BackColor = Color.FromArgb(8, 133, 204);
                //btnThietLap.Image = Properties.Resources.thietlap_black;

                check_reset(btnThietLap);
                AddControl("ucThietLap");
            }
            if (btnThietLap.ForeColor == Color.White)
            {
                btnThietLap.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnThietLap.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }
        
        private void frmChinh_Load(object sender, EventArgs e)
        {
            //byte[] img = NhanVienBL.GetInstance.GetHinhNhanVien(1)‌;
            //MemoryStream ms = new MemoryStream(img);
            //picNhanVien.Image = Image.FromStream(ms);

            if (TaiKhoanBL.GetInstance.GetTenQuyen(frmDangNhap.Quyen) != "Admin")
            {
                lbQuyen.Text = TaiKhoanBL.GetInstance.GetTenQuyen(frmDangNhap.Quyen);
                lbTenNV.Text = NhanVienBL.GetInstance.GetTenNhanVien(frmDangNhap.TenDangNhap);
                btnSanPham.Enabled = false;
                btnTrangChu.Enabled = false;
                btnNhapSanPham.Enabled = false;
                btnBanSanPham.PerformClick();
            }
            else
            {
                lbQuyen.Text = TaiKhoanBL.GetInstance.GetTenQuyen(frmDangNhap.Quyen);
                lbTenNV.Text = NhanVienBL.GetInstance.GetTenNhanVien(frmDangNhap.TenDangNhap);
                btnTrangChu.PerformClick();
            }
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void btnNhapSanPham_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            moveSidePanel(btnNhapSanPham);
            if (btnNhapSanPham.ForeColor == Color.White)
            {
                btnNhapSanPham.ForeColor = Color.FromArgb(255, 255, 254);
                btnNhapSanPham.BackColor = Color.FromArgb(8, 133, 204);

                check_reset(btnNhapSanPham);
                AddControl("ucNhapSanPham");
            }
            if (btnNhapSanPham.ForeColor == Color.White)
            {
                btnNhapSanPham.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 133, 204);
            }
            else
            {
                btnNhapSanPham.FlatAppearance.MouseDownBackColor = Color.White;
            }
            Cursor = Cursors.Default;
        }
    }
}
