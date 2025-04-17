using System;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTO;
using System.Threading.Tasks;

namespace PillMate.View
{
    public partial class PatientRegisterView : Form
    {
        private readonly Func<Task> refreshList;

        public PatientRegisterView(Func<Task> refreshList)
        {
            InitializeComponent();
            this.refreshList = refreshList;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var dto = new CreatePatientDto
            {
                Hwanja_Name = txtName.Text.Trim(),
                Hwanja_Gender = cmbGender.SelectedItem?.ToString() ?? "",
                Hwanja_No = txtNo.Text.Trim(),
                Hwanja_Room = txtRoom.Text.Trim(),
                Hwanja_PhoneNumber = txtPhone.Text.Trim(),
                Bohoja_Name = txtGuardianName.Text.Trim(),
                Bohoja_PhoneNumber = txtGuardianPhone.Text.Trim()
            };

            if (string.IsNullOrEmpty(dto.Hwanja_Name) || string.IsNullOrEmpty(dto.Hwanja_No))
            {
                MessageBox.Show("필수 입력 항목이 비어 있습니다. 이름과 환자 번호를 확인해주세요.");
                return;
            }

            var api = new PatientApi();
            var success = await api.AddAsync(dto);

            if (success)
            {
                MessageBox.Show("✅ 환자 등록이 완료되었습니다.");
                this.Close();  // 등록 후 창 닫기
                await refreshList(); // 환자 목록 새로고침
            }
            else
            {
                MessageBox.Show("❌ 등록 실패: 서버 오류");
            }
        }
    }
}
