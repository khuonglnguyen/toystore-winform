namespace QuanLyCuaHangBanDoChoi.UserControls
{
    partial class ucThietLap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlThongTinKhachHang = new System.Windows.Forms.Panel();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtMatKhauHienTai = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMatKhauHienTai = new System.Windows.Forms.Label();
            this.lblNhapLai = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlThongTinKhachHang.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.pnlThongTinKhachHang, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.389776F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.61022F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1232, 626);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // pnlThongTinKhachHang
            // 
            this.pnlThongTinKhachHang.BackColor = System.Drawing.Color.White;
            this.pnlThongTinKhachHang.Controls.Add(this.btnXacNhan);
            this.pnlThongTinKhachHang.Controls.Add(this.txtNhapLai);
            this.pnlThongTinKhachHang.Controls.Add(this.label5);
            this.pnlThongTinKhachHang.Controls.Add(this.txtMatKhauMoi);
            this.pnlThongTinKhachHang.Controls.Add(this.txtMatKhauHienTai);
            this.pnlThongTinKhachHang.Controls.Add(this.label12);
            this.pnlThongTinKhachHang.Controls.Add(this.lblMatKhauHienTai);
            this.pnlThongTinKhachHang.Controls.Add(this.lblNhapLai);
            this.pnlThongTinKhachHang.Controls.Add(this.label10);
            this.pnlThongTinKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThongTinKhachHang.ForeColor = System.Drawing.Color.Black;
            this.pnlThongTinKhachHang.Location = new System.Drawing.Point(3, 42);
            this.pnlThongTinKhachHang.Name = "pnlThongTinKhachHang";
            this.pnlThongTinKhachHang.Size = new System.Drawing.Size(1226, 581);
            this.pnlThongTinKhachHang.TabIndex = 55;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(145)))), ((int)(((byte)(249)))));
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Image = global::QuanLyCuaHangBanDoChoi.Properties.Resources.icons8_ok_32px;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(441, 227);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(122, 37);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.BackColor = System.Drawing.Color.White;
            this.txtNhapLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapLai.ForeColor = System.Drawing.Color.Black;
            this.txtNhapLai.Location = new System.Drawing.Point(441, 192);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.PasswordChar = '●';
            this.txtNhapLai.Size = new System.Drawing.Size(339, 29);
            this.txtNhapLai.TabIndex = 2;
            this.txtNhapLai.TextChanged += new System.EventHandler(this.txtNhapLai_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(275, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 20);
            this.label5.TabIndex = 76;
            this.label5.Text = "Nhập lại mật khẩu mới";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.BackColor = System.Drawing.Color.White;
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauMoi.ForeColor = System.Drawing.Color.Black;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(441, 156);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '●';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(339, 29);
            this.txtMatKhauMoi.TabIndex = 1;
            this.txtMatKhauMoi.TextChanged += new System.EventHandler(this.txtMatKhauMoi_TextChanged);
            // 
            // txtMatKhauHienTai
            // 
            this.txtMatKhauHienTai.BackColor = System.Drawing.Color.White;
            this.txtMatKhauHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauHienTai.ForeColor = System.Drawing.Color.Black;
            this.txtMatKhauHienTai.Location = new System.Drawing.Point(441, 120);
            this.txtMatKhauHienTai.Name = "txtMatKhauHienTai";
            this.txtMatKhauHienTai.PasswordChar = '●';
            this.txtMatKhauHienTai.Size = new System.Drawing.Size(339, 29);
            this.txtMatKhauHienTai.TabIndex = 0;
            this.txtMatKhauHienTai.TextChanged += new System.EventHandler(this.txtMatKhauHienTai_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(275, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 20);
            this.label12.TabIndex = 74;
            this.label12.Text = "Mật khẩu mới";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMatKhauHienTai
            // 
            this.lblMatKhauHienTai.AutoSize = true;
            this.lblMatKhauHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhauHienTai.ForeColor = System.Drawing.Color.Red;
            this.lblMatKhauHienTai.Location = new System.Drawing.Point(786, 126);
            this.lblMatKhauHienTai.Name = "lblMatKhauHienTai";
            this.lblMatKhauHienTai.Size = new System.Drawing.Size(180, 16);
            this.lblMatKhauHienTai.TabIndex = 77;
            this.lblMatKhauHienTai.Text = "Mật khẩu hiện tại không đúng";
            this.lblMatKhauHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMatKhauHienTai.Visible = false;
            // 
            // lblNhapLai
            // 
            this.lblNhapLai.AutoSize = true;
            this.lblNhapLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapLai.ForeColor = System.Drawing.Color.Red;
            this.lblNhapLai.Location = new System.Drawing.Point(786, 198);
            this.lblNhapLai.Name = "lblNhapLai";
            this.lblNhapLai.Size = new System.Drawing.Size(192, 16);
            this.lblNhapLai.TabIndex = 77;
            this.lblNhapLai.Text = "Nhập lại mật khẩu không giống";
            this.lblNhapLai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNhapLai.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(275, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 77;
            this.label10.Text = "Mật khẩu hiện tại";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1226, 33);
            this.panel8.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(133)))), ((int)(((byte)(204)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1226, 33);
            this.label3.TabIndex = 56;
            this.label3.Text = "Thiết Lập";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucThietLap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "ucThietLap";
            this.Size = new System.Drawing.Size(1232, 626);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.pnlThongTinKhachHang.ResumeLayout(false);
            this.pnlThongTinKhachHang.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pnlThongTinKhachHang;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauHienTai;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNhapLai;
        private System.Windows.Forms.Label lblMatKhauHienTai;
    }
}
