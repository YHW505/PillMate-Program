using System;
using System.Collections.Generic;
using System.Drawing;                        
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;                   
using System.Windows.Forms.DataVisualization.Charting; 
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;


namespace PillMate.View
{
    public partial class DashboardView : Form
    {
        private readonly PillApi _pillApi;
        private readonly StockTransactionApi _stockApi;

        public DashboardView()
        {
            InitializeComponent();
            _pillApi = new PillApi();
            _stockApi = new StockTransactionApi();
            this.Load += DashboardView_Load;
        }

        private async void DashboardView_Load(object sender, EventArgs e)
        {
            await LoadDashboardAsync();
        }

        private async Task LoadDashboardAsync()
        {
            try
            {
                // ✅ 1. 데이터 불러오기
                var pills = await _pillApi.GetAllAsync();
                var transactions = await _stockApi.GetAllAsync();

                // ✅ 2. 기본 통계
                lblTotalPills.Text = $"{pills.Count:N0} 종";

                var today = DateTime.Today;
                lblTodayReleased.Text = $"{transactions.Count(t => t.ReleasedAt.Date == today):N0} 명";

                lblPending.Text = "0개"; // 현재 하드코딩

                lblLastUpdated.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                // ✅ 3. 최근 7일 출고량 차트
                LoadWeeklyChart(transactions);

                // ✅ 4. 목표 달성률 (테스트용 랜덤)
                LoadReleaseRatioChart(transactions);

                // ✅ 5. 최근 출고 내역
                LoadRecentList(transactions);

                // ✅ 6. 재고 부족 알림
                LoadLowStockAlerts(pills);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"대시보드 로드 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ 3. 최근 7일 출고량 차트
        private void LoadWeeklyChart(List<StockTransactionDto> transactions)
        {
            chartWeekly.Series.Clear();

            var last7Days = Enumerable.Range(0, 7)
                .Select(i => DateTime.Today.AddDays(-i))
                .OrderBy(d => d)
                .ToList();

            var groupedData = last7Days
                .Select(d => new
                {
                    Date = d,
                    TotalQuantity = transactions
                        .Where(t => t.ReleasedAt.Date == d.Date)
                        .Sum(t => t.Quantity)
                })
                .ToList();

            var series = new Series("출고량")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.MediumSeaGreen
            };

            foreach (var data in groupedData)
            {
                series.Points.AddXY(data.Date.ToString("MM/dd"), data.TotalQuantity);
            }

            chartWeekly.Series.Add(series);
            chartWeekly.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartWeekly.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartWeekly.ChartAreas[0].AxisY.Title = "출고 수량";
        }

        // ✅ 4. 목표 달성률 (테스트용)
        private void LoadReleaseRatioChart(List<StockTransactionDto> transactions)
        {
            chartReleaseRatio.Series.Clear();

            // 최근 7일간 데이터만 필터링
            var last7Days = DateTime.Today.AddDays(-7);
            var recentTransactions = transactions
                .Where(t => t.ReleasedAt >= last7Days)
                .ToList();

            // 약품별 출고량 합산
            var grouped = recentTransactions
                .GroupBy(t => t.PillName)
                .Select(g => new
                {
                    PillName = g.Key ?? "이름 없음",
                    Total = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.Total)
                .Take(6) // 상위 6개 약품만 표시
                .ToList();

            var series = new Series("출고 비율")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
            };

            foreach (var item in grouped)
            {
                series.Points.AddXY(item.PillName, item.Total);
            }

            chartReleaseRatio.Series.Add(series);
            chartReleaseRatio.Titles.Clear();
        }


        // ✅ 5. 최근 출고 내역
        private void LoadRecentList(List<StockTransactionDto> transactions)
        {
            listRecent.Clear();

            // 컬럼 헤더 설정
            listRecent.View = System.Windows.Forms.View.Details;
            listRecent.FullRowSelect = true;
            listRecent.GridLines = true;
            listRecent.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            listRecent.Columns.Add("출고일시", 140, HorizontalAlignment.Center);
            listRecent.Columns.Add("약품명", 190, HorizontalAlignment.Left);
            listRecent.Columns.Add("수량", 80, HorizontalAlignment.Center);
            listRecent.Columns.Add("담당 약사", 80, HorizontalAlignment.Center);

            // 데이터 추가
            var recent5 = transactions
                .OrderByDescending(t => t.ReleasedAt)
                .Take(5)
                .ToList();

            foreach (var t in recent5)
            {
                string pillName = string.IsNullOrEmpty(t.PillName) ? "알 수 없음" : t.PillName;
                var item = new ListViewItem(new[]
                {
            t.ReleasedAt.ToString("yyyy/MM/dd HH:mm"),
            pillName,
            $"{t.Quantity}개",
            t.PharmacistName ?? "-"
        });
                listRecent.Items.Add(item);
            }

            // 컬러 및 폰트 스타일
            listRecent.BackColor = Color.WhiteSmoke;
            listRecent.ForeColor = Color.FromArgb(40, 40, 40);
            listRecent.Font = new Font("맑은 고딕", 9, FontStyle.Regular);
        }


        // ✅ 6. 재고 부족 알림
        private void LoadLowStockAlerts(List<PillDto> pills)
        {
            listAlerts.Items.Clear();

            var lowStock = pills.Where(p => p.Yank_Cnt < 10).ToList();

            if (lowStock.Any())
            {
                foreach (var p in lowStock)
                    listAlerts.Items.Add($"{p.Yank_Name}의 재고가 부족합니다. (남은 수량: {p.Yank_Cnt})");
            }
            else
            {
                listAlerts.Items.Add("모든 약품의 재고가 충분합니다.");
            }
        }
    }
}
