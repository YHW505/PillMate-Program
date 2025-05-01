using System;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTO;
using System.Threading.Tasks;

namespace PillMate.View
{
    public partial class PatientEditView : Form
    {
        private readonly PatientDto _selectedPatient;
        private readonly Func<Task> refreshList;

        public PatientEditView(PatientDto selectedPatient, Func<Task> refreshList)
        {
            InitializeComponent();
            _selectedPatient = selectedPatient;
            this.refreshList = refreshList;
        }

        private async void PatientEditView_Load(object sender, EventArgs e)
        {
            txtName.Text = _selectedPatient.Hwanja_Name;
            txtGender.Text = _selectedPatient.Hwanja_Gender; // 텍스트박스에 성별 값을 설정
            txtNo.Text = _selectedPatient.Hwanja_No;
            txtRoom.Text = _selectedPatient.Hwanja_Room;
            txtPhone.Text = _selectedPatient.Hwanja_PhoneNumber;
            txtGuardianName.Text = _selectedPatient.Bohoja_Name;
            txtGuardianPhone.Text = _selectedPatient.Bohoja_PhoneNumber;
            txtHwanjaAge.Text = _selectedPatient.Hwanja_Age.ToString() ?? "";;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtHwanjaAge.Text.Trim(), out int age))
            {
                MessageBox.Show("나이는 숫자로 입력해주세요.");
                return;
            }
            var dto = new UpdatePatientDto
            {
                Id = _selectedPatient.Id ?? 0,
                Hwanja_Name = txtName.Text.Trim(),
                Hwanja_Gender = txtGender.Text.Trim(), // 텍스트박스에서 성별 값을 가져옴
                Hwanja_No = txtNo.Text.Trim(),
                Hwanja_Room = txtRoom.Text.Trim(),
                Hwanja_PhoneNumber = txtPhone.Text.Trim(),
                Bohoja_Name = txtGuardianName.Text.Trim(),
                Bohoja_PhoneNumber = txtGuardianPhone.Text.Trim(),
                Hwanja_Age = age
            };

            if (string.IsNullOrEmpty(dto.Hwanja_Name) || string.IsNullOrEmpty(dto.Hwanja_No))
            {
                MessageBox.Show("필수 입력 항목이 비어 있습니다. 이름과 환자 번호를 확인해주세요.");
                return;
            }

            var api = new PatientApi();
            var success = await api.UpdateAsync(dto);

            if (success)
            {
                MessageBox.Show("✅ 환자 정보가 수정되었습니다.");
                this.Close();  // 수정 후 창 닫기
                await refreshList(); // 환자 목록 새로고침
            }
            else
            {
                MessageBox.Show("❌ 수정 실패: 서버 오류");
            }
        }
    }
}
