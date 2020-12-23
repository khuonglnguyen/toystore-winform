using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDoChoi.Forms
{
    public partial class frmChonNCC : Form
    {
        public frmChonNCC()
        {
            InitializeComponent();
        }
        public int MANCC;
        private void frmChonNCC_Load(object sender, EventArgs e)
        {
            cboNCC.DataSource = NCCBL.GetInstance.GetDanhSachNCC();
            cboNCC.DisplayMember = "Tên NCC";
            cboNCC.ValueMember = "Mã NCC";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemNCC frm = new frmThemNCC();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                cboNCC.DataSource = NCCBL.GetInstance.GetDanhSachNCC();
                cboNCC.SelectedIndex = cboNCC.Items.Count - 1;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            MANCC = (int)cboNCC.SelectedValue;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
