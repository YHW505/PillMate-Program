using System;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTO;
using System.Threading.Tasks;

namespace PillMate.View
{
    public partial class PatientView : UserControl
    {
        private readonly PatientApi _api;

        public PatientView()
        {
            InitializeComponent();
            _api = new PatientApi();
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

                if (patients != null && patients.Count > 0)
                {
                    dataGridView1.DataSource = patients;
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
    }
}
