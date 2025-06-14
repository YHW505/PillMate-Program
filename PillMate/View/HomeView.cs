using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using PillMate.ApiClients;
using PillMate.DTO;

namespace PillMate.View
{
    public partial class HomeView : Form
    {
        private readonly DashboardApi _dashboardApi = new DashboardApi();

        public HomeView()
        {
            InitializeComponent();
        }

        private async void HomeView_Load(object sender, EventArgs e)
        {
            await LoadDashboardAsync();       // 카드 숫자 + 파이차트
            await LoadMedicationGridAsync();  // 그리드뷰
            guna2DataGridView1.CellPainting += guna2DataGridView1_CellPainting;
        }

        private async Task LoadDashboardAsync()
        {
            var summary = await _dashboardApi.GetSummaryAsync();
            if (summary == null) return;

            int total = summary.Completed + summary.Pending;
            double takenPercent = total == 0 ? 0 : (double)summary.Completed / total * 100;
            double missedPercent = total == 0 ? 0 : (double)summary.Pending / total * 100;

            // 카드 숫자
            cnt_card1.Text = summary.TotalPatients.ToString();
            cnt_card2.Text = summary.Completed.ToString();
            cnt_card3.Text = summary.Pending.ToString();

            // ✅ 퍼센트 텍스트 설정
            takenlabel.Text = $"{takenPercent:0.#} %";
            missedlabel.Text = $"{missedPercent:0.#} %";

            // 파이차트
            pieChart2.DisableAnimations = true;
            pieChart2.InnerRadius = 50; // 내부 반지름 설정
            pieChart2.Series.Clear();
            pieChart2.Series.Add(new PieSeries
            {
                Title = "복용 완료",
                Values = new ChartValues<int> { summary.Completed },
                DataLabels = false
            });
            pieChart2.Series.Add(new PieSeries
            {
                Title = "미복용",
                Values = new ChartValues<int> { summary.Pending },
                DataLabels = false
            });

            pieChart2.LegendLocation = LegendLocation.Right;
        }

        private async Task LoadMedicationGridAsync()
        {
            var data = await _dashboardApi.GetMedicationsAsync();
            if (data == null) return;

            guna2DataGridView1.Rows.Clear();

            guna2DataGridView1.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            guna2DataGridView1.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (var item in data)
            {
                string patient = item.PatientName ?? "-";
                string pill = item.PillName ?? "-";
                string status = item.IsTaken ? "복용 완료" : "미복용";

                guna2DataGridView1.Rows.Add(patient, pill, status);
            }
            guna2DataGridView1.ClearSelection();
            guna2DataGridView1.CurrentCell = null;
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            guna2DataGridView1.Enabled = true;
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.DefaultCellStyle.BackColor;
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.DefaultCellStyle.ForeColor;
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.AllowUserToResizeRows = false;
            guna2DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }
        private void guna2DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Status" && e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                string text = e.FormattedValue?.ToString() ?? "";
                Color fillColor;
                Color textColor;

                if (text == "복용 완료")
                {
                    fillColor = Color.FromArgb(204, 255, 204);  // 연두색
                    textColor = Color.DarkGreen;
                }
                else
                {
                    fillColor = Color.FromArgb(255, 204, 204);  // 연빨강
                    textColor = Color.DarkRed;
                }

                using (var brush = new SolidBrush(fillColor))
                using (var textBrush = new SolidBrush(textColor))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    // 텍스트 크기 측정
                    SizeF textSize = e.Graphics.MeasureString(text, e.CellStyle.Font);
                    int padding = 8;

                    var rect = new RectangleF(
                        e.CellBounds.X + (e.CellBounds.Width - textSize.Width) / 2 - padding / 2,
                        e.CellBounds.Y + (e.CellBounds.Height - textSize.Height) / 2 - 1,
                        textSize.Width + padding,
                        textSize.Height + 4
                    );

                    e.Graphics.FillRoundedRectangle(brush, Rectangle.Round(rect), 10);
                    e.Graphics.DrawString(text, e.CellStyle.Font, textBrush, e.CellBounds, sf);
                }
            }
        }
    }
}
public static class GraphicsExtensions
{
    public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
    {
        using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
        {
            graphics.FillPath(brush, path);
        }
    }

    private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        var path = new GraphicsPath();

        path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);                     // 왼쪽 위
        path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);         // 오른쪽 위
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // 오른쪽 아래
        path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);        // 왼쪽 아래
        path.CloseFigure();

        return path;
    }
}
