using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.View.Widget;

namespace PillMate.View
{
    public partial class Pill : Form
    {
        private readonly PillApi _api;

        public Pill()
        {
            InitializeComponent();
            _api = new PillApi();
            this.Load += PillForm_Load;
        }

        // ✅ DataGridView 스타일 적용
        private void StyleDataGridView()
        {
            Pill_DataGreed.BorderStyle = BorderStyle.None;
            Pill_DataGreed.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            Pill_DataGreed.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Pill_DataGreed.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 255);
            Pill_DataGreed.DefaultCellStyle.SelectionForeColor = Color.Black;
            Pill_DataGreed.EnableHeadersVisualStyles = false;
            Pill_DataGreed.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Pill_DataGreed.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(79, 70, 229);
            Pill_DataGreed.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Pill_DataGreed.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
            Pill_DataGreed.DefaultCellStyle.Font = new Font("맑은 고딕", 9);
            Pill_DataGreed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ✅ DataGridView 컬럼 구성 (No 제거 + Id 표시)
        private void ConfigureGridColumns()
        {
            Pill_DataGreed.Columns.Clear();
            Pill_DataGreed.AutoGenerateColumns = false;

            // ✅ 등록번호 (DB Id)
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "등록번호",
                Width = 70
            });

            // ✅ 약품명
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Yank_Name",
                HeaderText = "품명",
                Width = 160
            });

            // ✅ 수량
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Yank_Cnt",
                HeaderText = "수량",
                Width = 70
            });

            // ✅ 분류
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "분류",
                Width = 100
            });

            // ✅ 제조사
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Manufacturer",
                HeaderText = "제조사",
                Width = 120
            });

            // ✅ 유통기한
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExpirationDate",
                HeaderText = "유통기한",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            // ✅ 보관 위치
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StorageLocation",
                HeaderText = "보관 위치",
                Width = 120
            });

            // ✅ 약품 번호
            Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Yank_Num",
                HeaderText = "약품 번호",
                Width = 120
            });
        }

        // ✅ 약품 데이터 로드
        private async Task LoadPillsAsync()
        {
            try
            {
                var pills = await _api.GetAllAsync();

                Pill_DataGreed.DataSource = pills;
                pillcnt.Text = $"{pills.Count}";

                ApplyRowHighlight();
            }
            catch (Exception ex)
            {
                var dialog = new Dialog_Widget("오류", $"약품 목록 로드 중 오류: {ex.Message}");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        // ✅ 남은 일수 계산 헬퍼
        private double? DaysUntil(DateTime? target)
        {
            if (!target.HasValue) return null;
            return (target.Value.Date - DateTime.Today).TotalDays;
        }

        // ✅ 강조 색상 적용 (유통기한 임박 / 재고 부족)
        private void ApplyRowHighlight()
        {
            bool showCaution = false;

            foreach (DataGridViewRow row in Pill_DataGreed.Rows)
            {
                if (row.DataBoundItem is PillDto p)
                {
                    var daysLeft = DaysUntil(p.ExpirationDate);

                    row.DefaultCellStyle.ForeColor = Color.Black;

                    // 유통기한 임박 (7일 이하)
                    if (daysLeft.HasValue && daysLeft.Value <= 7)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        showCaution = true;
                    }
                    // 재고 부족
                    else if (p.Yank_Cnt < 10)
                    {
                        row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                        showCaution = true;
                    }
                }
            }

            cautionlbl.Visible = showCaution;
            cautionimg.Visible = showCaution;
        }

        // ✅ 폼 로드
        private async void PillForm_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            ConfigureGridColumns();
            await LoadPillsAsync();
        }

        // ✅ 등록 버튼
        private void Createbtn_Click_1(object sender, EventArgs e)
        {
            var form = new PillResister(LoadPillsAsync);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        // ✅ 수정 버튼
        private void Edit_Pill_Btn(object sender, EventArgs e)
        {
            if (Pill_DataGreed.SelectedRows.Count == 0)
            {
                var dialog = new Dialog_Widget("약품 수정", "수정할 약품을 선택해주세요.");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                return;
            }

            var selected = Pill_DataGreed.SelectedRows[0].DataBoundItem as PillDto;
            if (selected != null)
            {
                var form = new PillEdit(selected, LoadPillsAsync);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }

        // ✅ 삭제 버튼
        private void Deletebtn_Click_1(object sender, EventArgs e)
        {
            if (Pill_DataGreed.SelectedRows.Count == 0)
            {
                var dialog = new Dialog_Widget("약품 삭제", "삭제할 약품을 선택해주세요.");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                return;
            }

            var selected = Pill_DataGreed.SelectedRows[0].DataBoundItem as PillDto;
            if (selected != null)
            {
                var dialog = new Dialog_Delete_Pill(selected, LoadPillsAsync, LoadPillsAsync);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        // ✅ 출고 버튼 클릭 이벤트
        private void Releasebtn_Click(object sender, EventArgs e)
        {
            if (Pill_DataGreed.SelectedRows.Count == 0)
            {
                var dialog = new Dialog_Widget("출고", "출고할 약품을 선택해주세요.");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                return;
            }

            var selected = Pill_DataGreed.SelectedRows[0].DataBoundItem as PillDto;
            if (selected != null)
            {
                var dialog = new Dialog_Release_Pill(selected, LoadPillsAsync);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }
    }
}
