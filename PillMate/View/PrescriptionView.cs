using Guna.UI2.WinForms;
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.View.Widget;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillMate.View
{
    public partial class PrescriptionView : Form
    {
        private readonly PatientApi _patientApi;
        private readonly PillApi _pillApi;
        private readonly PrescriptionApi _prescriptionApi;

        public PrescriptionView()
        {
            InitializeComponent();
            _patientApi = new PatientApi();
            _pillApi = new PillApi();
            _prescriptionApi = new PrescriptionApi();

            Load += async (_, __) => await LoadPatientsAsync();

            gridPatients.SelectionChanged += gridPatients_SelectionChanged;
            gridHistory.SelectionChanged += gridHistory_SelectionChanged;
            //btnReorder.Click += btnReorder_Click;
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
        //private async void btnReorder_Click(object sender, EventArgs e)
        //{
        //    if (gridHistory.SelectedRows.Count == 0)
        //    {
        //        new Dialog_Widget("출고", "재출고할 복약이력을 선택해주세요.").ShowDialog();
        //        return;
        //    }
        //    var record = gridHistory.SelectedRows[0].DataBoundItem as PrescriptionRecordDto;


        //    if (record == null) return;

        //    var confirm = MessageBox.Show("처방약을 출고하시겠습니까?", "처방 약 출고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (confirm == DialogResult.Yes)
        //    {
        //        var success = await _prescriptionApi.ReorderAsync(record.Id);
        //        var dialog = success

        //            ? new Dialog_Widget("출고 완료", "출고가 완료되었습니다.")
        //            : new Dialog_Widget("출고 실패", "출고 중 오류가 발생했습니다.");

        //        dialog.StartPosition = FormStartPosition.CenterScreen;
        //        dialog.ShowDialog();
        //    }
        //}
        private async void btnReorder_Click(object sender, EventArgs e)
        {
            if (gridHistory.SelectedRows.Count == 0)
            {
                new Dialog_Widget("출고", "재출고할 복약이력을 선택해주세요.").ShowDialog();
                return;
            }

            var record = gridHistory.SelectedRows[0].DataBoundItem as PrescriptionRecordDto;
            if (record == null) return;

            var confirm = MessageBox.Show("처방약을 출고하시겠습니까?", "처방 약 출고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var medicines = new List<object>();

                    foreach (var item in record.Items)
                    {
                        try
                        {
                            var pill = await _pillApi.GetByIdAsync(item.PillId);

                            if (pill != null)
                            {
                                medicines.Add(new
                                {
                                    name = pill.Yank_Name ?? item.PillName ?? "약물명 없음",
                                    quantity = item.Quantity,
                                    storage = pill.StorageLocation ?? "위치를 알 수 없음",
                                });
                            }
                            else
                            {
                                medicines.Add(new
                                {
                                    name = item.PillName ?? "약물명 없음",
                                    quantity = item.Quantity,
                                    storage = "카트리지를 불러올 수 없습니다.",
                                });
                            }
                        }
                        catch (Exception pillEx)
                        {
                            System.Diagnostics.Debug.WriteLine($"❌ 약물 처리 중 오류: {pillEx.Message}");

                            medicines.Add(new
                            {
                                name = item.PillName ?? "약물명 없음",
                                quantity = item.Quantity,
                                storage = "1"
                            });
                        }
                    }

                    // 🎯 1단계: 먼저 라즈베리파이 통신 시도
                    bool socketSuccess = false;
                    string raspberryResponse = "";

                    System.Diagnostics.Debug.WriteLine("🔄 라즈베리파이 통신 시도 중...");

                    try
                    {
                        var data = new { medicines = medicines };
                        string jsonData = JsonSerializer.Serialize(data);
                        System.Diagnostics.Debug.WriteLine($"📤 라즈베리파이 전송 데이터: {jsonData}");

                        using (var client = new TcpClient())
                        {
                            var connectTask = client.ConnectAsync("172.20.10.8", 8080);
                            if (await Task.WhenAny(connectTask, Task.Delay(10000)) != connectTask)
                            {
                                throw new TimeoutException("라즈베리파이 연결 시간 초과");
                            }

                            NetworkStream stream = client.GetStream();
                            byte[] data_bytes = Encoding.UTF8.GetBytes(jsonData);
                            await stream.WriteAsync(data_bytes, 0, data_bytes.Length);

                            byte[] buffer = new byte[4096];
                            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                            raspberryResponse = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                            socketSuccess = true;
                            System.Diagnostics.Debug.WriteLine($"✅ 라즈베리파이 통신 성공: {raspberryResponse}");
                        }
                    }
                    catch (Exception socketEx)
                    {
                        raspberryResponse = $"라즈베리파이 통신 오류: {socketEx.Message}";
                        socketSuccess = false;
                        System.Diagnostics.Debug.WriteLine($"❌ 라즈베리파이 통신 실패: {socketEx.Message}");
                    }

                    // 🎯 2단계: 라즈베리파이 통신이 성공한 경우에만 DB 저장
                    if (socketSuccess)
                    {
                        System.Diagnostics.Debug.WriteLine("✅ 라즈베리파이 통신 성공 - DB 업데이트 시작");

                        var dbSuccess = await _prescriptionApi.ReorderAsync(record.Id);

                        if (!dbSuccess)
                        {
                            System.Diagnostics.Debug.WriteLine("❌ DB 업데이트 실패");
                            new Dialog_Widget("출고 실패",
                                "⚠️ 라즈베리파이 통신은 성공했지만\n데이터베이스 저장 중 오류가 발생했습니다.").ShowDialog();
                            return;
                        }

                        System.Diagnostics.Debug.WriteLine("✅ DB 업데이트 성공");

                        // 🎯 3단계: 모든 것이 성공한 경우
                        string resultMessage = $"✅ 출고가 완료되었습니다.\n약물: {medicines.Count}개";

                        if (!string.IsNullOrEmpty(raspberryResponse))
                        {
                            try
                            {
                                var responseObj = JsonSerializer.Deserialize<JsonElement>(raspberryResponse);
                                if (responseObj.TryGetProperty("message", out var msgElement))
                                {
                                    resultMessage += $"\n\n🍓 라즈베리파이: {msgElement.GetString()}";
                                }
                            }
                            catch
                            {
                                resultMessage += $"\n\n🍓 라즈베리파이: {raspberryResponse}";
                            }
                        }

                        var dialog = new Dialog_Widget("출고 완료", resultMessage);
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.ShowDialog();
                    }
                    else
                    {
                        // 🎯 라즈베리파이 통신 실패 시 DB 저장하지 않음
                        System.Diagnostics.Debug.WriteLine("❌ 라즈베리파이 통신 실패 - DB 저장 중단");

                        var errorDialog = new Dialog_Widget("출고 실패",
                            $"❌ 라즈베리파이 통신에 실패하여 출고를 중단했습니다.\n\n" +
                            $"오류: {raspberryResponse}\n\n" +
                            $"※ 데이터베이스에는 변경사항이 반영되지 않았습니다.");
                        errorDialog.StartPosition = FormStartPosition.CenterScreen;
                        errorDialog.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ 시스템 오류: {ex.Message}");
                    var errorDialog = new Dialog_Widget("시스템 오류", $"❌ 시스템 오류가 발생했습니다:\n{ex.Message}");
                    errorDialog.StartPosition = FormStartPosition.CenterScreen;
                    errorDialog.ShowDialog();
                }
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
