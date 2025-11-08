using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using PillMate.ApiClients;
using PillMate.DTO;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http;
using Guna.UI2.WinForms;
using PillMate.Client.ApiClients;
using PillMate.View.Widget;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Text.Json;
using System.IO.Ports;
using System.Threading;
using System.Net;

namespace PillMate.View
{
    public partial class Patient : Form
    {
        private readonly PatientApi _api;
        private readonly TakenMedicineAPI _Tapi;
        private bool _isLoadingMedicine = false;

        private SerialPort serialPort;


        public Patient()
        {
            InitializeComponent();
            _api = new PatientApi();
            _Tapi = new TakenMedicineAPI();
            SetupListView();
            guna2DataGridView1.AutoGenerateColumns = false;


            // 우클릭 메뉴 설정
            var contextMenu = new ContextMenuStrip();
            var deleteMenu = new ToolStripMenuItem("삭제");
            //deleteMenu.Click += DeleteMenu_Click;
            contextMenu.Items.Add(deleteMenu);
            //listView1.ContextMenuStrip = contextMenu;
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM3"; // 아두이노가 연결된 포트 (장치 관리자에서 확인)
            serialPort.BaudRate = 9600;   // 아두이노와 동일한 속도
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;

            try
            {
                serialPort.Open();
                MessageBox.Show("아두이노 연결 성공!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"아두이노 연결 실패: {ex.Message}");
            }
        }

        private async void ejaculation_btn_serial(object sender, EventArgs e)
        {
            try
            {
                // 1. 선택된 환자 가져오기
                if (guna2DataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("전송할 환자를 선택해주세요!");
                    return;
                }

                var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
                if (selectedPatient?.Id == null)
                {
                    MessageBox.Show("선택된 환자 정보가 올바르지 않습니다!");
                    return;
                }

                int patientId = selectedPatient.Id.Value;

                // 2. 복용 약물 데이터 로드
                var takenList = await _Tapi.GetAllAsync(patientId);
                var uniqueList = takenList.GroupBy(x => new { x.PillId, x.Dosage })
                                         .Select(g => g.First())
                                         .ToList();

                // 3. 약물 데이터 생성
                var medicineData = uniqueList
                    .Where(item => item?.Pill?.Yank_Name != null)
                    .Select(item => new
                    {
                        name = item.Pill.Yank_Name,
                        dosage = item.Dosage
                    })
                    .ToList();

                // 4. JSON 데이터 구성
                var data = new
                {
                    patientName = selectedPatient.Hwanja_Name,
                    patientRoom = selectedPatient.Hwanja_Room,
                    medicines = medicineData
                };

                string jsonData = JsonSerializer.Serialize(data);

                // 5. TCP 소켓으로 전송
                using (var client = new TcpClient())
                {
                    // 연결 시도 (10초 타임아웃)
                    var connectTask = client.ConnectAsync("172.20.10.13", 8080);
                    if (await Task.WhenAny(connectTask, Task.Delay(10000)) != connectTask)
                    {
                        throw new TimeoutException("연결 시간 초과");
                    }

                    // 데이터 전송
                    NetworkStream stream = client.GetStream();
                    byte[] data_bytes = Encoding.UTF8.GetBytes(jsonData);
                    await stream.WriteAsync(data_bytes, 0, data_bytes.Length);

                    // 응답 수신
                    byte[] buffer = new byte[4096];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // 응답 파싱
                    string resultMessage = $"✅ 전송 완료!\n환자: {selectedPatient.Hwanja_Name}\n약물: {medicineData.Count}개";

                    if (!string.IsNullOrEmpty(response))
                    {
                        try
                        {
                            var responseObj = JsonSerializer.Deserialize<JsonElement>(response);
                            if (responseObj.TryGetProperty("message", out var msgElement))
                            {
                                resultMessage += $"\n\n📨 응답: {msgElement.GetString()}";
                            }
                        }
                        catch
                        {
                            resultMessage += $"\n\n📨 응답: {response}";
                        }
                    }

                    MessageBox.Show(resultMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ 오류: {ex.Message}");
            }
        }




        //private async void ejaculation_btn_serial(object sender, EventArgs e)
        //{
        //    SerialPort tempPort = null;

        //    try
        //    {
        //        // 1. 선택된 환자 가져오기
        //        if (guna2DataGridView1.SelectedRows.Count == 0)
        //        {
        //            MessageBox.Show("전송할 환자를 선택해주세요!");
        //            return;
        //        }

        //        var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
        //        if (selectedPatient?.Id == null)
        //        {
        //            MessageBox.Show("선택된 환자 정보가 올바르지 않습니다!");
        //            return;
        //        }

        //        int patientId = selectedPatient.Id.Value;

        //        // 2. 복용 약물 데이터 로드
        //        var takenList = await _Tapi.GetAllAsync(patientId);
        //        var uniqueList = takenList.GroupBy(x => new { x.PillId, x.Dosage })
        //                                 .Select(g => g.First())
        //                                 .ToList();

        //        // 3. 아두이노 전송용 데이터 생성
        //        var medicineData = uniqueList
        //            .Where(item => item?.Pill?.Yank_Name != null)
        //            .Select(item => new
        //            {
        //                pillId = item.PillId,
        //                name = item.Pill.Yank_Name,
        //                dosage = item.Dosage,
        //                unit = "정"
        //            })
        //            .ToList();

        //        // 4. JSON 데이터 구성
        //        var data = new
        //        {
        //            type = "MEDICINE_DATA",
        //            patientId = patientId,
        //            patientName = selectedPatient.Hwanja_Name,
        //            patientRoom = selectedPatient.Hwanja_Room,
        //            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        //            totalCount = medicineData.Count,
        //            medicines = medicineData
        //        };

        //        string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
        //        {
        //            WriteIndented = true,
        //            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // 한글 지원
        //        });

        //        // 5. 시리얼 포트로 전송
        //        tempPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        //        tempPort.ReadTimeout = 2000;
        //        tempPort.WriteTimeout = 2000;
        //        tempPort.Open();

        //        Thread.Sleep(2000); // 아두이노 부팅 대기

        //        // 전송
        //        tempPort.WriteLine("=== MEDICINE DATA START ===");
        //        tempPort.WriteLine(jsonData);
        //        tempPort.WriteLine("=== MEDICINE DATA END ===");

        //        Thread.Sleep(500);

        //        MessageBox.Show($"✅ 복용 약물 데이터 전송 완료!\n\n" +
        //                       $"👤 환자: {selectedPatient.Hwanja_Name}\n" +
        //                       $"🏥 병실: {selectedPatient.Hwanja_Room}\n" +
        //                       $"📊 전송된 약물 수: {medicineData.Count}개\n\n" +
        //                       "🔍 아두이노 시리얼 모니터에서 확인하세요.");

        //        // 디버깅용 출력
        //        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 약물 데이터 전송 완료");
        //        Console.WriteLine($"환자: {selectedPatient.Hwanja_Name} (ID: {patientId}), 약물 수: {medicineData.Count}");
        //        Console.WriteLine("전송된 JSON:");
        //        Console.WriteLine(jsonData);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"❌ 전송 오류: {ex.Message}");
        //        Console.WriteLine($"오류 상세: {ex}");
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            tempPort?.Close();
        //            tempPort?.Dispose();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"포트 해제 오류: {ex.Message}");
        //        }
        //    }
        //}

        // 폼 종료시 시리얼 포트 닫기
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }


        private async void Patient_Load(object sender, EventArgs e)
        {
            await LoadPatientsAsync();
        }

        private async Task LoadPatientsAsync()
        {
            try
            {
                var patients = await _api.GetAllAsync();
                for (int i = 0; i < patients.Count; i++)
                {
                    patients[i].No = i + 1;
                }
                guna2DataGridView1.Columns.Clear();

                // 이벤트 잠깐 제거
                guna2DataGridView1.CellClick -= guna2DataGridView1_CellClick;

                guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColumnId", HeaderText = "No.", DataPropertyName = "No", Width = 50 });
                guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColumnName", HeaderText = "이름", DataPropertyName = "Hwanja_Name", Width = 100 });
                guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColumnGender", HeaderText = "성별", DataPropertyName = "Hwanja_Gender", Width = 100 });
                guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColumnAge", HeaderText = "나이", DataPropertyName = "Hwanja_Age", Width = 100 });
                guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColumnPhone", HeaderText = "전화번호", DataPropertyName = "Hwanja_PhoneNumber", Width = 100 });
                //guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColumnRoom", HeaderText = "병실", DataPropertyName = "Hwanja_Room", Width = 80 });

                guna2DataGridView1.DataSource = patients;

                patientcnt.Text = patients.Count.ToString("D2");

                if (patients.Any())
                {
                    guna2DataGridView1.ClearSelection();
                    guna2DataGridView1.Rows[0].Selected = true;

                    var patient = patients[0];
                    //Label_Bohoja_Name.Text = $"{patient.Bohoja_Name}";
                    //Label_Bohoja_pNum.Text = $"{patient.Bohoja_PhoneNumber}";
                    //Label_Hwanja_Room.Text = $"{patient.Hwanja_Room}";
                    //await LoadQRCodeAsync(patient.Id.Value);
                    await LoadTakenMedicine(patient.Id.Value);
                }

                // 다시 이벤트 연결
                guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            }
            catch (Exception ex)
            {
                Dialog_Widget dialog = new Dialog_Widget("오류", $"환자 목록 로드 실패: {ex.Message}");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        private async void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //listView1.Items.Clear();
            if (e.RowIndex < 0) return;

            if (guna2DataGridView1.Rows[e.RowIndex].DataBoundItem is PatientDto patient && patient.Id != null)
            {
                //Label_Bohoja_Name.Text = $"{patient.Bohoja_Name}";
                //Label_Bohoja_pNum.Text = $"{patient.Bohoja_PhoneNumber}";
                //Label_Hwanja_Room.Text = $"{patient.Hwanja_Room}";
                //await LoadQRCodeAsync(patient.Id.Value);
                await LoadTakenMedicine(patient.Id.Value);
            }
        }

        //private async Task LoadQRCodeAsync(int patientId)
        //{
        //    string url = $"https://localhost:14188/api/QRCode/{patientId}";
        //    try
        //    {
        //        using var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (a, b, c, d) => true };
        //        using var client = new HttpClient(handler);
        //        var imageBytes = await client.GetByteArrayAsync(url);
        //        using var ms = new MemoryStream(imageBytes);
        //        using var img = Image.FromStream(ms);
        //        QR_Image_Box.Image?.Dispose();
        //        QR_Image_Box.Image = new Bitmap(img);
        //    }
        //    catch (Exception ex)
        //    {
        //        QR_Image_Box.Image = null;
        //        Dialog_Widget dialog = new Dialog_Widget("오류", $"QR 코드 로드 실패: {ex.Message}");
        //        dialog.StartPosition = FormStartPosition.CenterScreen;
        //        dialog.ShowDialog();
        //        listView1.Items.Clear();
        //    }
        //}

        private async Task LoadTakenMedicine(int patientId)
        {
            if (_isLoadingMedicine) return;
            _isLoadingMedicine = true;

            //listView1.Items.Clear();
            var takenList = await _Tapi.GetAllAsync(patientId);
            var uniqueList = takenList.GroupBy(x => new { x.PillId, x.Dosage }).Select(g => g.First()).ToList();

            foreach (var item in uniqueList)
            {
                if (item?.Pill?.Yank_Name == null) continue;
                var lvi = new ListViewItem(item.Pill.Yank_Name);
                lvi.SubItems.Add($"{item.Dosage}정");
                lvi.Tag = item;
                //listView1.Items.Add(lvi);
            }

            _isLoadingMedicine = false;
        }

        private void SetupListView()
        {
            //listView1.View = System.Windows.Forms.View.Details;
            //listView1.Columns.Add("약품명", 80);
            //listView1.Columns.Add("복용량", 70);
        }

        //private void guna2Button1_Click(object sender, EventArgs e)
        //{
        //    PrintQRCode();
        //}

        //private void PrintQRCode()
        //{
        //    if (QR_Image_Box.Image == null)
        //    {
        //        Dialog_Widget dialog = new Dialog_Widget("오류", "인쇄할 QR 이미지가 없습니다.");
        //        dialog.StartPosition = FormStartPosition.CenterScreen;
        //        dialog.ShowDialog();
        //        return;
        //    }

        //    var pd = new PrintDocument();
        //    pd.PrintPage += (s, e) => e.Graphics.DrawImage(QR_Image_Box.Image, new Rectangle(100, 100, 200, 200));
        //    var dlg = new PrintDialog { Document = pd };
        //    if (dlg.ShowDialog() == DialogResult.OK) pd.Print();
        //}

        private void Createbtn_Click(object sender, EventArgs e)
        {
            var register = new PatientRegister(LoadPatientsAsync);
            register.StartPosition = FormStartPosition.CenterScreen;
            register.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
                if (selectedPatient != null)
                {
                    var edit = new PatientEdit(selectedPatient, LoadPatientsAsync);
                    edit.StartPosition = FormStartPosition.CenterScreen;
                    edit.ShowDialog();
                }
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("환자 수정", "수정할 환자를 선택해주세요.");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
                if (selectedPatient != null)
                {
                    var deleteDialog = new Dialog_Delete_Patient(selectedPatient, LoadPatientsAsync);
                    deleteDialog.StartPosition = FormStartPosition.CenterScreen;
                    deleteDialog.ShowDialog();
                }
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("삭제", "삭제할 환자를 선택해주세요.");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        private void AddPillbtn_Click(object sender, EventArgs e)
        {
            var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
            if (selectedPatient?.Id == null) return;

            var form = new TakenMedicineRegister(selectedPatient.Id.Value);
            form.OnPillsSelectedAsync += async (selectedList) =>
            {
                await LoadTakenMedicine(selectedPatient.Id.Value);
                //await LoadQRCodeAsync(selectedPatient.Id.Value);
            };
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        //private async void DeleteMenu_Click(object? sender, EventArgs e)
        //{
        //    if (listView1.SelectedItems.Count == 0)
        //    {
        //        Dialog_Widget dialog = new Dialog_Widget("삭제", "삭제할 항목을 선택하세요.");
        //        dialog.StartPosition = FormStartPosition.CenterScreen;
        //        dialog.ShowDialog();
        //        return;
        //    }

        //    var selectedItem = listView1.SelectedItems[0];
        //    if (selectedItem.Tag is TakenMedicineDto takenMedicine)
        //    {
        //        var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
        //        var result = MessageBox.Show($"'{selectedItem.Text}' 약을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (result == DialogResult.Yes)
        //        {
        //            var api = new TakenMedicineAPI();
        //            bool isSuccess = await api.DeleteTakenMedicineAsync(takenMedicine.Id);
        //            if (isSuccess)
        //            {
        //                listView1.Items.Remove(selectedItem);
        //                //await LoadQRCodeAsync(selectedPatient.Id.Value);
        //                Dialog_Widget dialog = new Dialog_Widget("삭제", "✅ 삭제 완료");
        //                dialog.StartPosition = FormStartPosition.CenterScreen;
        //                dialog.ShowDialog();
        //            }
        //            else
        //            {
        //                Dialog_Widget dialog = new Dialog_Widget("삭제", "✅ 삭제 실패");
        //                dialog.StartPosition = FormStartPosition.CenterScreen;
        //                dialog.ShowDialog();
        //            }
        //        }
        //    }
        //}
    }
}
