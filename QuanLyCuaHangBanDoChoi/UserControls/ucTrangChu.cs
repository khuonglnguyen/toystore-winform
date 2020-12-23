using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogicLayer;
using DTO;

namespace QuanLyCuaHangBanDoChoi.UserControls
{
    public partial class ucTrangChu : UserControl
    {
        public ucTrangChu()
        {
            InitializeComponent();
        }
        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            cboDoanhThu.SelectedIndex = 0;
            cboTopSanPham1.SelectedIndex = 0;
            cboTopSanPham2.SelectedIndex = 0;
            btnRefresh.PerformClick();
        }
        private string Convert(double gia)
        {
            string giaban = gia.ToString();
            string result = "";
            int d = 0;
            for (int i = giaban.Length - 1; i >= 0; i--)
            {
                d++;
                result += giaban[i];
                if (d == 3 && i != 0)
                {
                    result += '.';
                    d = 0;
                }
            }
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void LoadData()
        {
            Cursor = Cursors.AppStarting;
            lbSanPhanDaBan.Text = TrangChuBL.GetInstance.GetTongSanPhamDaBan().ToString();
            lbTongDoanhThu.Text = Convert(TrangChuBL.GetInstance.GetTongDoanhThu()) + " ₫";
            lbTongKhachHang.Text = TrangChuBL.GetInstance.GetTongKhachHang().ToString();
            Cursor = Cursors.Default;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboDoanhThu_SelectedValueChanged(object sender, EventArgs e)
        {
            //lblDoanhThu.Text = "Biểu Đồ Doanh Thu " + cboDoanhThu.SelectedItem.ToString();
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Series.Add("Doanh Thu");
            chartDoanhThu.Series["Doanh Thu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            chartDoanhThu.Series["Doanh Thu"].Font = new Font("UTM Avo", 10, FontStyle.Bold);
            chartDoanhThu.Series["Doanh Thu"].BorderColor = Color.Orange;
            chartDoanhThu.Series["Doanh Thu"].BorderWidth = 2;

            List<DoanhThuDTO> lstdt=new List<DoanhThuDTO>();
            double doanhthu=0;
            DoanhThuDTO dtDTO;
            switch (cboDoanhThu.SelectedItem.ToString())
            {
                case "Hôm nay":
                    doanhthu = TrangChuBL.GetInstance.GetDoanhThuHomNay();
                    chartDoanhThu.Series["Doanh Thu"].Points.Add(doanhthu);
                    chartDoanhThu.Series["Doanh Thu"].Points[0].AxisLabel = DateTime.Now.ToShortDateString();
                    chartDoanhThu.Series["Doanh Thu"].Points[0].LegendText = DateTime.Now.ToShortDateString();
                    chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                    chartDoanhThu.Series["Doanh Thu"].Points[0].Label = Convert(doanhthu).ToString() + " ₫";
                    break;
                case "Hôm qua":
                    dtDTO = TrangChuBL.GetInstance.GetDoanhThuHomQua();
                    if (dtDTO != null)
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.doanhthu);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].AxisLabel = dtDTO.ngay.ToShortDateString();
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LegendText = DateTime.Now.ToShortDateString();
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = Convert(dtDTO.doanhthu).ToString() + " ₫";
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                case "7 ngày qua":
                    lstdt = TrangChuBL.GetInstance.GetDoanhThu7NgayQua();
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.doanhthu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.doanhthu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                case "Tháng này":
                    lstdt = TrangChuBL.GetInstance.GetDoanhThuThangNay();
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.doanhthu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.doanhthu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                case "Tháng trước":
                    lstdt = TrangChuBL.GetInstance.GetDoanhThuThangTruoc();
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.doanhthu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.doanhthu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                default:
                    break;
            }
        }

        private void cboTopSanPham1_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (cboTopSanPham2.SelectedItem != null)
            {
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if(cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuong7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThu7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void lblTopSP_Click(object sender, EventArgs e)
        {

        }

        private void cboTopSanPham2_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (cboTopSanPham2.SelectedItem != null)
            {
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuong7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.soluong);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = spDTO.soluong + "";
                        i++;
                    }
                }
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThu7NgayQua();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangNay();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<SanPhamDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangTruoc();
                    int i = 0;
                    foreach (SanPhamDTO spDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(spDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = spDTO.masp.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = spDTO.tensp;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(spDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
