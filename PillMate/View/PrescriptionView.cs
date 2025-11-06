using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PillMate.DTO;
using PillMate.ApiClients;
using PillMate.View.Widget;

namespace PillMate.View
{
    public partial class PrescriptionView : Form
    {
        private readonly PatientApi _patientApi;
        private readonly PrescriptionApi _prescriptionApi;

        public PrescriptionView()
        {
            InitializeComponent();
            _patientApi = new PatientApi();
            _prescriptionApi = new PrescriptionApi();

            Load += async (_, __) => await LoadPatientsAsync();

            gridPatients.SelectionChanged += gridPatients_SelectionChanged;
            gridHistory.SelectionChanged += gridHistory_SelectionChanged;
            btnReorder.Click += btnReorder_Click;
        }

        // ✅ 환자 목록 로드
        private async Task LoadPatientsAsync()
        {
            var patients = await _patientApi.GetAllAsync();
            gridPatients.DataSource = patients;
            ConfigurePatientGrid();  // ✅ 환자리스트 구성
            StyleGrid(gridPatients); // ✅ 스타일 적용

            gridPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ✅ 환자 선택 시 복약이력 표시
        private async void gridPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPatients.SelectedRows.Count == 0) return;
            var selected = gridPatients.SelectedRows[0].DataBoundItem as PatientDto;
            if (selected == null || selected.Id == null) return;

            lblPatientName.Text = $"{selected.Hwanja_Name} 님의 복약이력";

            var history = await _prescriptionApi.GetPrescriptionsAsync(selected.Id.Value);
            gridHistory.DataSource = history;
            gridItems.DataSource = null;

            ConfigureHistoryGrid();
        }

        // ✅ 복약이력 선택 시 세부 약품 표시
        private void gridHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (gridHistory.SelectedRows.Count == 0) return;
            var selected = gridHistory.SelectedRows[0].DataBoundItem as PrescriptionRecordDto;
            if (selected == null) return;

            gridItems.DataSource = selected.Items;
            ConfigureItemsGrid();
        }

        // ✅ 출고 버튼 클릭
        private async void btnReorder_Click(object sender, EventArgs e)
        {
            if (gridHistory.SelectedRows.Count == 0)
            {
                new Dialog_Widget("출고", "재출고할 복약이력을 선택해주세요.").ShowDialog();
                return;
            }

            var record = gridHistory.SelectedRows[0].DataBoundItem as PrescriptionRecordDto;
            if (record == null) return;

            var confirm = MessageBox.Show("이 이력을 기준으로 다시 출고하시겠습니까?", "이전 이력 재출고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var success = await _prescriptionApi.ReorderAsync(record.Id);
                var dialog = success
                    ? new Dialog_Widget("출고 완료", "이전 복약이력대로 출고가 완료되었습니다.")
                    : new Dialog_Widget("출고 실패", "출고 중 오류가 발생했습니다.");

                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        // ✅ 환자 이름만 표시 (헤더 없음)
        private void ConfigurePatientGrid()
        {
            gridPatients.AutoGenerateColumns = false;
            gridPatients.Columns.Clear();

            gridPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Hwanja_Name",
                HeaderText = "", // ✅ 헤더 제거
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            gridPatients.ColumnHeadersVisible = false;  // ✅ 헤더 숨김
            gridPatients.RowHeadersVisible = false;     // ✅ 왼쪽 행 번호 숨김
            gridPatients.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridPatients.RowTemplate.Height = 40;
            gridPatients.DefaultCellStyle.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
        }

        // ✅ 복약 이력 그리드 설정
        private void ConfigureHistoryGrid()
        {
            gridHistory.AutoGenerateColumns = false;
            gridHistory.Columns.Clear();
            gridPatients.DefaultCellStyle.Font = new Font("맑은 고딕", 13, FontStyle.Bold);
            gridPatients.RowTemplate.Height = 45;

            gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CreatedAt",
                HeaderText = "등록일시",
                DefaultCellStyle = { Format = "yyyy-MM-dd HH:mm" }
            });
            gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PharmacistName",
                HeaderText = "약사"
            });
            gridHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "메모"
            });

            StyleGrid(gridHistory);
        }

        // ✅ 세부내역 표 (아래쪽)
        private void ConfigureItemsGrid()
        {
            gridItems.AutoGenerateColumns = false;
            gridItems.Columns.Clear();
            gridItems.RowTemplate.Height = 36;

            gridItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PillName",
                HeaderText = "약품명"
            });
            gridItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "수량"
            });

            StyleGrid(gridItems);
        }

        // ✅ 공통 DataGridView 스타일
        private void StyleGrid(Guna2DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.DefaultCellStyle.Font = new Font("맑은 고딕", 9);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.RowTemplate.Height = 36;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnAddPrescription_Click(object sender, EventArgs e)
        {
            if (gridPatients.SelectedRows.Count == 0)
            {
                new Dialog_Widget("알림", "환자를 선택해주세요.").ShowDialog();
                return;
            }

            var selected = gridPatients.SelectedRows[0].DataBoundItem as PatientDto;
            if (selected == null || selected.Id == null)
            {
                new Dialog_Widget("오류", "선택된 환자 정보를 불러올 수 없습니다.").ShowDialog();
                return;
            }

        }
    }

}
