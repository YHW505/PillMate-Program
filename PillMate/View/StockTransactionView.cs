using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;

namespace PillMate.View
{
    public partial class StockTransactionView : Form
    {
        private readonly StockTransactionApi _api;

        public StockTransactionView()
        {
            InitializeComponent();
            _api = new StockTransactionApi();
            this.Load += StockTransactionView_Load;
        }

        private async void StockTransactionView_Load(object sender, EventArgs e)
        {
            StyleGrid();
            await LoadTransactionsAsync();
        }

        // ✅ DataGridView 스타일 설정
        private void StyleGrid()
        {
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(79, 70, 229);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ✅ 출고 내역 불러오기
        private async Task LoadTransactionsAsync()
        {
            try
            {
                var transactions = await _api.GetAllAsync();

                dgvTransactions.Columns.Clear();
                dgvTransactions.AutoGenerateColumns = false;

                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 50 });
                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReleasedAt", HeaderText = "출고 일시", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" } });
                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PillName", HeaderText = "약품명", Width = 150 });
                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "수량", Width = 80 });
                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PharmacistName", HeaderText = "약사명", Width = 100 });
                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Note", HeaderText = "비고", Width = 200 });

                dgvTransactions.DataSource = transactions.OrderByDescending(t => t.ReleasedAt).ToList();
                lblCount.Text = $"총 {transactions.Count}건";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"출고 내역을 불러오는 중 오류 발생: {ex.Message}");
            }
        }
        // ✅ 기간 필터 버튼
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            var start = dtpStart.Value.Date;
            var end = dtpEnd.Value.Date.AddDays(1);

            var transactions = await _api.GetAllAsync();
            var filtered = transactions
                .Where(t => t.ReleasedAt >= start && t.ReleasedAt < end)
                .OrderByDescending(t => t.ReleasedAt)
                .ToList();

            dgvTransactions.DataSource = filtered;
            lblCount.Text = $"총 {filtered.Count}건";
        }


    }
}
