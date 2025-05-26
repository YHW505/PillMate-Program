using System;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTO;
using System.Threading.Tasks;
using PillMate.Models;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Drawing;
using System.Drawing.Printing;
using PillMate.Client.ApiClients;
using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;

namespace PillMate.View
{
    public partial class PatientView : UserControl
    {
        private readonly PatientApi _api;
        private readonly TakenMedicineAPI _Tapi;

        public PatientView()
        {
            InitializeComponent();
            _api = new PatientApi();
            _Tapi = new TakenMedicineAPI();
            // 우클릭 메뉴 설정 코드
            var contextMenu = new ContextMenuStrip();
            var deleteMenu = new ToolStripMenuItem("삭제");
            deleteMenu.Click += DeleteMenu_Click;
            contextMenu.Items.Add(deleteMenu);

            Bukyoung_list.ContextMenuStrip = contextMenu;
        }

        private async void PatientView_Load(object sender, EventArgs e)
        {
            await LoadPatientsAsync();
        }


        private async Task LoadPatientsAsync()
        {
            try
            {
                var patients = await _api.GetAllAsync();
                dataGridView1.Columns.Clear(); // 이전 열 제거

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "hwanja_name",
                    HeaderText = "환자 이름"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "hwanja_gender",
                    HeaderText = "성별"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "hwanja_no",
                    HeaderText = "환자 번호"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "hwanja_age",
                    HeaderText = "나이"
                });
                dataGridView1.DataSource = patients;



                if (patients != null && patients.Count > 0)
                {
                    labelStatus.Text = $"총 {patients.Count}명 환자 데이터";
                }
                else
                {
                    labelStatus.Text = "환자 데이터가 없습니다.";
                }
            }
            catch (Exception ex)
            {
                labelStatus.Text = "데이터를 불러오는 데 실패했습니다.";
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }

        public async Task LoadTakenMedicine(int patientId)
        {
            Bukyoung_list.Items.Clear();

            // View 및 컬럼 설정 확인
            Bukyoung_list.View = System.Windows.Forms.View.Details;
            if (Bukyoung_list.Columns.Count == 0)
            {
                Bukyoung_list.Columns.Add("약품명", 150);
                Bukyoung_list.Columns.Add("복용량", 100);
                Bukyoung_list.Columns[0].Width = 142;
                Bukyoung_list.Columns[1].Width = 142;
            }

            var takenList = await _Tapi.GetAllAsync(patientId);

            foreach (var tm in takenList)
            {
                if (tm.Pill != null)
                {
                    var item = new ListViewItem(tm.Pill.Yank_Name);
                    item.SubItems.Add($"{tm.Dosage}정");
                    item.Tag = tm; // ← 여기에서 Tag에 dto 넣기
                    Bukyoung_list.Items.Add(item);
                }
            }
        }

        

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            PatientRegisterView patientRegisterView = new PatientRegisterView(LoadPatientsAsync); // LoadPatientsAsync 메소드를 전달
            patientRegisterView.StartPosition = FormStartPosition.CenterScreen;
            patientRegisterView.ShowDialog();
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedPatient = dataGridView1.SelectedRows[0].DataBoundItem as PatientDto;

                if (selectedPatient != null)
                {
                    PatientEditView patientEditView = new PatientEditView(selectedPatient, LoadPatientsAsync); // LoadPatientsAsync 메소드를 전달
                    patientEditView.StartPosition = FormStartPosition.CenterScreen;
                    patientEditView.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("수정할 환자를 선택해주세요.");
            }
        }

        // 삭제 버튼 클릭 처리
        private async void btnDeletePatient_Click(object sender, EventArgs e)
        {
            // 선택된 환자가 있는지 확인
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedPatient = dataGridView1.SelectedRows[0].DataBoundItem as PatientDto;

                if (selectedPatient != null)
                {
                    var result = MessageBox.Show("정말 이 환자를 삭제하시겠습니까?", "환자 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // 환자 삭제 API 호출
                        var success = await _api.DeleteAsync(new DeletePatientDto { Id = selectedPatient.Id ?? 0 });

                        if (success)
                        {
                            MessageBox.Show("환자가 삭제되었습니다.");
                            await LoadPatientsAsync(); // 환자 리스트 새로고침
                            QR_Image_Box.Visible = false;
                            Print_QR.Visible = false;
                            Add_TakenMedicine.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("환자 삭제에 실패했습니다.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("삭제할 환자를 선택해주세요.");
            }
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.SelectedRows.Count > 0)
            {
                var selectedPatient = dataGridView1.SelectedRows[0].DataBoundItem as PatientDto;

                if (selectedPatient != null && selectedPatient.Id != null)
                {
                    await LoadQRCodeAsync(selectedPatient.Id.Value); // QR 불러오기
                    await LoadTakenMedicine(selectedPatient.Id.Value);
                    Bukyoung_list.Visible = true;
                    Add_TakenMedicine.Visible = true;
                    bohoja_name_label.Text = $"보호자 이름: {selectedPatient.Bohoja_Name}";
                    bohoja_pn_label.Text = $"보호자 번호: {selectedPatient.Bohoja_PhoneNumber}";
                    hwanja_room_label.Text = $"병실: {selectedPatient.Hwanja_Room}";
                }
            }
        }


        private async Task LoadQRCodeAsync(int patientId)
        {
            //이 부분 자신에 맞게 수정
            string url = $"https://localhost:8938/api/QRCode/{patientId}";

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    var imageBytes = await client.GetByteArrayAsync(url);  
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        QR_Image_Box.SizeMode = PictureBoxSizeMode.Zoom;
                        QR_Image_Box.Image = Image.FromStream(ms);

                        // ✅ QR 이미지가 생기면 버튼 보이게!
                        Print_QR.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                QR_Image_Box.Image = null;
                Print_QR.Visible = false; // ❌ 에러나면 숨기기
                MessageBox.Show("QR 코드 로드 실패: " + ex.Message);
            }
        }

        private Image qrImageToPrint;

        private void PrintQRCode()
        {
            if (QR_Image_Box.Image == null)
            {
                MessageBox.Show("인쇄할 QR 이미지가 없습니다.");
                return;
            }

            qrImageToPrint = QR_Image_Box.Image;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (qrImageToPrint != null)
            {
                // 인쇄 위치 및 사이즈 조정 (페이지 중앙에 200x200 사이즈로 출력)
                int x = (e.PageBounds.Width - 200) / 2;
                int y = (e.PageBounds.Height - 200) / 2;

                e.Graphics.DrawImage(qrImageToPrint, x, y, 200, 200);
            }
        }

        private void Print_QR_Click(object sender, EventArgs e)
        {
            PrintQRCode();
        }


        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            var selectedPatient = dataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
            if (selectedPatient?.Id == null) return;

            var form = new TakenMedicineResisterView(selectedPatient.Id.Value);
            form.OnPillsSelectedAsync += async (selectedList) =>
            {
                await LoadTakenMedicine(selectedPatient.Id.Value); // 새로고침
                await LoadQRCodeAsync(selectedPatient.Id.Value);
            };
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog(); // 이거 꼭 필요!
        }

        private async void DeleteMenu_Click(object? sender, EventArgs e)
        {
            if (Bukyoung_list.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택하세요.");
                return;
            }


            var selectedItem = Bukyoung_list.SelectedItems[0];

            if (selectedItem.Tag is TakenMedicineDto takenMedicine)
            {
                var result = MessageBox.Show($"'{selectedItem.Text}' 약을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var api = new TakenMedicineAPI();
                    bool isSuccess = await api.DeleteTakenMedicineAsync(takenMedicine.Id);

                    if (isSuccess)
                    {
                        var selectedPatient = dataGridView1.SelectedRows[0].DataBoundItem as PatientDto;

                        Bukyoung_list.Items.Remove(selectedItem); // ✅ 3번 코드: ListView에서 삭제
                        await LoadQRCodeAsync(selectedPatient.Id.Value);
                        MessageBox.Show("✅ 삭제 완료");
                    }
                    else
                    {
                        MessageBox.Show("❌ 삭제 실패");
                    }
                }
            }
        }



    }
}
