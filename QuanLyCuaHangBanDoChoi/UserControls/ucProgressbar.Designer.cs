namespace QuanLyCuaHangBanDoChoi.UserControls
{
    partial class ucProgressbar
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressLoading = new ColorProgressBar.ColorProgressBar();
            this.lblPhanTram = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.836065F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.50819F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.77283F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(985, 580);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.progressLoading);
            this.panel1.Controls.Add(this.lblPhanTram);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(99, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 187);
            this.panel1.TabIndex = 0;
            // 
            // progressLoading
            // 
            this.progressLoading.BackColor = System.Drawing.Color.Blue;
            this.progressLoading.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(145)))), ((int)(((byte)(249)))));
            this.progressLoading.BorderColor = System.Drawing.Color.Black;
            this.progressLoading.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progressLoading.Location = new System.Drawing.Point(24, 71);
            this.progressLoading.Maximum = 100;
            this.progressLoading.Minimum = 0;
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.Size = new System.Drawing.Size(1000, 33);
            this.progressLoading.Step = 10;
            this.progressLoading.TabIndex = 4;
            this.progressLoading.Value = 0;
            // 
            // lblPhanTram
            // 
            this.lblPhanTram.AutoSize = true;
            this.lblPhanTram.Font = new System.Drawing.Font("UTM Avo", 20F);
            this.lblPhanTram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(145)))), ((int)(((byte)(249)))));
            this.lblPhanTram.Location = new System.Drawing.Point(19, 31);
            this.lblPhanTram.Name = "lblPhanTram";
            this.lblPhanTram.Size = new System.Drawing.Size(53, 37);
            this.lblPhanTram.TabIndex = 3;
            this.lblPhanTram.Text = "0%";
            // 
            // ucProgressbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucProgressbar";
            this.Size = new System.Drawing.Size(985, 580);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public ColorProgressBar.ColorProgressBar progressLoading;
        public System.Windows.Forms.Label lblPhanTram;
    }
}
