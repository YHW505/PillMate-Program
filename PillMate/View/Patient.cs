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


            // 우클릭 메뉴 설정
            var contextMenu = new ContextMenuStrip();
            var deleteMenu = new ToolStripMenuItem("삭제");
            deleteMenu.Click += DeleteMenu_Click;
            contextMenu.Items.Add(deleteMenu);
            listView1.ContextMenuStrip = contextMenu;
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
            SerialPort tempPort = null;

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

                // 3. 아두이노 전송용 데이터 생성
                var medicineData = uniqueList
                    .Where(item => item?.Pill?.Yank_Name != null)
                    .Select(item => new
                    {
                        pillId = item.PillId,
                        name = item.Pill.Yank_Name,
                        dosage = item.Dosage,
                        unit = "정"
                    })
                    .ToList();

                // 4. JSON 데이터 구성
                var data = new
                {
                    type = "MEDICINE_DATA",
                    patientId = patientId,
                    patientName = selectedPatient.Hwanja_Name,
                    patientRoom = selectedPatient.Hwanja_Room,
                    timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    totalCount = medicineData.Count,
                    medicines = medicineData
                };

                string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                // 5. 시리얼 포트로 전송 + 응답 받기
                tempPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
                tempPort.ReadTimeout = 5000;  // 📈 응답 대기 시간 늘림
                tempPort.WriteTimeout = 2000;
                tempPort.Open();

                Thread.Sleep(2000); // 아두이노 부팅 대기

                // 📤 데이터 전송
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 데이터 전송 시작...");
                tempPort.WriteLine("=== MEDICINE DATA START ===");
                tempPort.WriteLine(jsonData);
                tempPort.WriteLine("=== MEDICINE DATA END ===");

                // 📥 아두이노 응답 받기
                Thread.Sleep(1000); // 아두이노 처리 시간 대기

                string arduinoResponse = "";
                DateTime startTime = DateTime.Now;

                // 🕐 3초 동안 응답 수집
                while ((DateTime.Now - startTime).TotalSeconds < 3)
                {
                    try
                    {
                        if (tempPort.BytesToRead > 0)
                        {
                            string chunk = tempPort.ReadExisting();
                            arduinoResponse += chunk;
                            Console.WriteLine($"[응답 수신] {chunk}");
                        }
                        Thread.Sleep(100);
                    }
                    catch (TimeoutException)
                    {
                        Console.WriteLine("응답 타임아웃");
                        break;
                    }
                }

                // 📋 결과 메시지 구성
                string resultMessage = $"✅ 복용 약물 데이터 전송 완료!\n\n" +
                                      $"👤 환자: {selectedPatient.Hwanja_Name}\n" +
                                      $"🏥 병실: {selectedPatient.Hwanja_Room}\n" +
                                      $"📊 전송된 약물 수: {medicineData.Count}개\n\n";

                // 🎯 아두이노 응답 표시
                if (!string.IsNullOrEmpty(arduinoResponse.Trim()))
                {
                    resultMessage += $"📨 아두이노 응답:\n{arduinoResponse.Trim()}\n\n";
                    resultMessage += "🟢 아두이노와 통신 성공!";
                }
                else
                {
                    resultMessage += "📭 아두이노 응답 없음\n";
                    resultMessage += "🟡 데이터는 전송되었지만 응답을 받지 못했습니다.";
                }

                MessageBox.Show(resultMessage);

                // 디버깅용 출력
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 약물 데이터 전송 완료");
                Console.WriteLine($"환자: {selectedPatient.Hwanja_Name} (ID: {patientId}), 약물 수: {medicineData.Count}");
                Console.WriteLine("전송된 JSON:");
                Console.WriteLine(jsonData);
                Console.WriteLine("\n=== 아두이노 응답 ===");
                Console.WriteLine(string.IsNullOrEmpty(arduinoResponse) ? "응답 없음" : arduinoResponse);
                Console.WriteLine("==================\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ 전송 오류: {ex.Message}");
                Console.WriteLine($"오류 상세: {ex}");
            }
            finally
            {
                try
                {
                    tempPort?.Close();
                    tempPort?.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"포트 해제 오류: {ex.Message}");
                }
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


        private async void ejaculation_btn_wifi(object sender, EventArgs e)
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

                // 3. 아두이노 전송용 데이터 생성
                var medicineData = uniqueList
                    .Where(item => item?.Pill?.Yank_Name != null)
                    .Select(item => new
                    {
                        pillId = item.PillId,
                        name = item.Pill.Yank_Name,
                        dosage = item.Dosage,
                        unit = "정"
                    })
                    .ToList();

                // 4. JSON 데이터 구성
                var data = new
                {
                    type = "MEDICINE_DATA",
                    patientId = patientId,
                    patientName = selectedPatient.Hwanja_Name,
                    patientRoom = selectedPatient.Hwanja_Room,
                    timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    totalCount = medicineData.Count,
                    medicines = medicineData
                };

                string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                // 5. WiFi로 HTTP POST 전송
                string arduinoIP = "192.168.1.100"; // 아두이노 IP 주소 (시리얼 모니터에서 확인)
                string url = $"http://{arduinoIP}/medicine";

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // 전송 시작 알림
                    var loadingForm = new Form
                    {
                        Text = "전송 중...",
                        Size = new Size(300, 100),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };

                    var loadingLabel = new Label
                    {
                        Text = "아두이노로 데이터 전송 중...",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    loadingForm.Controls.Add(loadingLabel);
                    loadingForm.Show();

                    try
                    {
                        var response = await client.PostAsync(url, content);
                        loadingForm.Close();

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();

                            MessageBox.Show($"✅ WiFi 전송 성공!\n\n" +
                                           $"👤 환자: {selectedPatient.Hwanja_Name}\n" +
                                           $"🏥 병실: {selectedPatient.Hwanja_Room}\n" +
                                           $"📊 전송된 약물 수: {medicineData.Count}개\n" +
                                           $"🌐 아두이노 IP: {arduinoIP}\n" +
                                           $"📡 응답: {responseContent}",
                                           "전송 완료",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"❌ 전송 실패!\n" +
                                           $"상태 코드: {response.StatusCode}\n" +
                                           $"오류: {response.ReasonPhrase}",
                                           "전송 오류",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Error);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        loadingForm.Close();
                        MessageBox.Show($"❌ 네트워크 오류!\n\n" +
                                       $"아두이노 IP({arduinoIP})에 연결할 수 없습니다.\n" +
                                       $"오류: {ex.Message}\n\n" +
                                       $"확인사항:\n" +
                                       $"1. 아두이노가 같은 WiFi에 연결되어 있는지\n" +
                                       $"2. IP 주소가 올바른지\n" +
                                       $"3. 방화벽 설정",
                                       "연결 오류",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                    }
                    catch (TaskCanceledException)
                    {
                        loadingForm.Close();
                        MessageBox.Show("⏰ 전송 시간 초과!\n아두이노 응답이 없습니다.",
                                       "시간 초과",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                    }
                }

                // 디버깅용 출력
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] WiFi 약물 데이터 전송 시도");
                Console.WriteLine($"환자: {selectedPatient.Hwanja_Name} (ID: {patientId})");
                Console.WriteLine($"아두이노 IP: {arduinoIP}");
                Console.WriteLine("전송된 JSON:");
                Console.WriteLine(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ 전송 오류: {ex.Message}\n\n상세: {ex}");
                Console.WriteLine($"오류 상세: {ex}");
            }
        }

        private async Task<string> FindArduinoIP()
        {
            var localIP = GetLocalIPAddress();
            var subnet = localIP.Substring(0, localIP.LastIndexOf('.'));

            var tasks = new List<Task<string>>();

            for (int i = 1; i <= 254; i++)
            {
                string ip = $"{subnet}.{i}";
                tasks.Add(CheckArduinoAtIP(ip));
            }

            var results = await Task.WhenAll(tasks);
            return results.FirstOrDefault(ip => !string.IsNullOrEmpty(ip));
        }

        // 실시간 상태 확인
        private async void btnCheckStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string arduinoIP = "192.168.1.100";
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"http://{arduinoIP}/status");
                    if (response.IsSuccessStatusCode)
                    {
                        string status = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"🟢 아두이노 온라인!\n\n{status}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"🔴 아두이노 오프라인\n{ex.Message}");
            }
        }


        private async Task<string> CheckArduinoAtIP(string ip)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(2);
                    var response = await client.GetAsync($"http://{ip}/status");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (content.Contains("Arduino") || content.Contains("status"))
                        {
                            return ip;
                        }
                    }
                }
            }
            catch { }

            return null;
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                ?.ToString() ?? "127.0.0.1";
        }





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
                    Label_Bohoja_Name.Text = $"{patient.Bohoja_Name}";
                    Label_Bohoja_pNum.Text = $"{patient.Bohoja_PhoneNumber}";
                    Label_Hwanja_Room.Text = $"{patient.Hwanja_Room}";
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
            listView1.Items.Clear();
            if (e.RowIndex < 0) return;

            if (guna2DataGridView1.Rows[e.RowIndex].DataBoundItem is PatientDto patient && patient.Id != null)
            {
                Label_Bohoja_Name.Text = $"{patient.Bohoja_Name}";
                Label_Bohoja_pNum.Text = $"{patient.Bohoja_PhoneNumber}";
                Label_Hwanja_Room.Text = $"{patient.Hwanja_Room}";
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

            listView1.Items.Clear();
            var takenList = await _Tapi.GetAllAsync(patientId);
            var uniqueList = takenList.GroupBy(x => new { x.PillId, x.Dosage }).Select(g => g.First()).ToList();

            foreach (var item in uniqueList)
            {
                if (item?.Pill?.Yank_Name == null) continue;
                var lvi = new ListViewItem(item.Pill.Yank_Name);
                lvi.SubItems.Add($"{item.Dosage}정");
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }

            _isLoadingMedicine = false;
        }

        private void SetupListView()
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("약품명", 80);
            listView1.Columns.Add("복용량", 70);
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

        private async void DeleteMenu_Click(object? sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                Dialog_Widget dialog = new Dialog_Widget("삭제", "삭제할 항목을 선택하세요.");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            if (selectedItem.Tag is TakenMedicineDto takenMedicine)
            {
                var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
                var result = MessageBox.Show($"'{selectedItem.Text}' 약을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var api = new TakenMedicineAPI();
                    bool isSuccess = await api.DeleteTakenMedicineAsync(takenMedicine.Id);
                    if (isSuccess)
                    {
                        listView1.Items.Remove(selectedItem);
                        //await LoadQRCodeAsync(selectedPatient.Id.Value);
                        Dialog_Widget dialog = new Dialog_Widget("삭제", "✅ 삭제 완료");
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.ShowDialog();
                    }
                    else
                    {
                        Dialog_Widget dialog = new Dialog_Widget("삭제", "✅ 삭제 실패");
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.ShowDialog();
                    }
                }
            }
        }
    }
}
