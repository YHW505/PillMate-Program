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
            }
        }

        private async Task LoadQRCodeAsync(int patientId)
        {
            string url = $"https://localhost:8938/api/QRCode/{patientId}";

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
            listView1.Columns.Add("약품명", 100);
            listView1.Columns.Add("복용량", 80);
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
    }
}
