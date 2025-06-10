using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http;
using Guna.UI2.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using System.Net;

namespace PillMate.View
{
    public partial class Patient : Form
    {
        private readonly PatientApi _api;
        private readonly TakenMedicineAPI _Tapi;

        public Patient()
        {
            InitializeComponent();
            _api = new PatientApi();
            _Tapi = new TakenMedicineAPI();
            SetupListView();
        }

        private async void Patient_Load(object sender, EventArgs e)
        {
            await LoadPatientsAsync();
            if (guna2DataGridView1.Rows[0].DataBoundItem is PatientDto patient && patient.Id != null)
            {
                QR_Image_Box.Visible = true;
                guna2Button1.Visible = true;
                Label_Bohoja_Name.Text = $"보호자 이름: {patient.Bohoja_Name}";
                Label_Bohoja_pNum.Text = $"보호자 번호: {patient.Bohoja_PhoneNumber}";
                Label_Hwanja_Room.Text = $"병실: {patient.Hwanja_Room}";
                await LoadQRCodeAsync(patient.Id.Value);
                await LoadTakenMedicine(patient.Id.Value);
            }
        }

        private async Task LoadPatientsAsync()
        {
            var patients = await _api.GetAllAsync();

            // 컬럼 데이터 연결 (디자이너에서 이미 컬럼 이름이 설정되어 있다고 가정)
            guna2DataGridView1.Columns["ColumnId"].DataPropertyName = "Id";
            guna2DataGridView1.Columns["ColumnName"].DataPropertyName = "Hwanja_Name";
            guna2DataGridView1.Columns["ColumnPhone"].DataPropertyName = "Hwanja_PhoneNumber";
            guna2DataGridView1.Columns["ColumnRoom"].DataPropertyName = "Hwanja_Room";

            guna2DataGridView1.DataSource = patients;

            patientcnt.Text = patients.Count.ToString("D2");
            patientcnt.Text = $"{patients.Count}";

        }

        private async void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 선택된 행에서 데이터 추출
            if (guna2DataGridView1.Rows[e.RowIndex].DataBoundItem is PatientDto patient && patient.Id != null)
            {
                await LoadQRCodeAsync(patient.Id.Value);
                await LoadTakenMedicine(patient.Id.Value);
                Label_Bohoja_Name.Text = $"보호자 이름: {patient.Bohoja_Name}";
                Label_Bohoja_pNum.Text = $"보호자 번호: {patient.Bohoja_PhoneNumber}";
                Label_Hwanja_Room.Text = $"병실: {patient.Hwanja_Room}";
            }
        }

        private async Task LoadQRCodeAsync(int patientId)
        {
            string url = $"https://localhost:14188/api/QRCode/{patientId}";
            try
            {

                using var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (a, b, c, d) => true };
                using var client = new HttpClient(handler);

                var imageBytes = await client.GetByteArrayAsync(url);
                using var ms = new MemoryStream(imageBytes);
                QR_Image_Box.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                QR_Image_Box.Image = null;
                MessageBox.Show("QR 코드 로드 실패: " + ex.Message);
            }
        }

        private async Task LoadTakenMedicine(int patientId)
        {
            listView1.Items.Clear();
            var takenList = await _Tapi.GetAllAsync(patientId);

            foreach (var item in takenList)
            {
                var lvi = new ListViewItem(item.Pill.Yank_Name);
                lvi.SubItems.Add($"{item.Dosage}정");
                listView1.Items.Add(lvi);
            }
        }

        private void SetupListView()
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("약품명", 80);
            listView1.Columns.Add("복용량", 70);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PrintQRCode();
        }

        private void PrintQRCode()
        {
            if (QR_Image_Box.Image == null)
            {
                MessageBox.Show("인쇄할 QR 이미지가 없습니다.");
                return;
            }

            var pd = new PrintDocument();
            pd.PrintPage += (s, e) =>
            {
                var img = QR_Image_Box.Image;
                e.Graphics.DrawImage(img, new Rectangle(100, 100, 200, 200));
            };

            var dlg = new PrintDialog { Document = pd };
            if (dlg.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
            PatientRegisterView patientRegisterView = new PatientRegisterView(LoadPatientsAsync); // LoadPatientsAsync 메소드를 전달
            patientRegisterView.StartPosition = FormStartPosition.CenterScreen;
            patientRegisterView.ShowDialog();
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;

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

        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            // 선택된 환자가 있는지 확인
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;

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

        private void AddPillbtn_Click(object sender, EventArgs e)
        {
            var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;
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
    }
}
