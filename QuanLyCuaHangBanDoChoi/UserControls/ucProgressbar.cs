using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDoChoi.UserControls
{
    public partial class ucProgressbar : UserControl
    {
        public ColorProgressBar.ColorProgressBar ProgressBar
        {
            get
            {
                return progressLoading;
            }
            set
            {
                progressLoading = value;
            }
        }
        public Label PhanTram
        {
            get
            {
                return lblPhanTram;
            }
            set
            {
                lblPhanTram = value;
            }
        }
        public ucProgressbar()
        {
            InitializeComponent();
        }
    }
}
