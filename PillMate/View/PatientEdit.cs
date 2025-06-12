using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.ApiClients;
using System.Xml.Linq;
using PillMate.DTO;
using PillMate.View.Widget;

namespace PillMate.View
{
    public partial class PatientEdit : Form
    {
        private readonly PatientDto _selectedPatient;
        private readonly Func<Task> refreshList;
        public PatientEdit(PatientDto selectedPatient, Func<Task> refreshList)
        {
            InitializeComponent();
            _selectedPatient = selectedPatient;
            this.refreshList = refreshList;
        }
        private async void PatientEditView_Load(object sender, EventArgs e)
        {
            tBox_Hwanja_Name.Text = _selectedPatient.Hwanja_Name;
            cBox_Hwanja_Gender.Text = _selectedPatient.Hwanja_Gender; // 텍스트박스에 성별 값을 설정
            tBox_Hwanja_Num.Text = _selectedPatient.Hwanja_No;
            tBox_Hwanja_Room.Text = _selectedPatient.Hwanja_Room;
            tBox_Hwanja_pNum.Text = _selectedPatient.Hwanja_PhoneNumber;
            tBox_Bohoja_Name.Text = _selectedPatient.Bohoja_Name;
            tBox_Bohoja_pNum.Text = _selectedPatient.Bohoja_PhoneNumber;
            tBox_Hwanja_Age.Text = _selectedPatient.Hwanja_Age.ToString() ?? ""; ;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tBox_Hwanja_Age.Text.Trim(), out int age))
            {
                //MessageBox.Show("나이는 숫자로 입력해주세요.");
                Dialog_Widget dialog = new Dialog_Widget("환자 수정", "나이는 숫자로 입력해주세요."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                return;
            }
            var dto = new UpdatePatientDto
            {
                Id = _selectedPatient.Id ?? 0,
                Hwanja_Name = tBox_Hwanja_Name.Text.Trim(),
                Hwanja_Gender = cBox_Hwanja_Gender.Text.Trim(), // 텍스트박스에서 성별 값을 가져옴
                Hwanja_No = tBox_Hwanja_Num.Text.Trim(),
                Hwanja_Room = tBox_Hwanja_Room.Text.Trim(),
                Hwanja_PhoneNumber = tBox_Hwanja_pNum.Text.Trim(),
                Bohoja_Name = tBox_Bohoja_Name.Text.Trim(),
                Bohoja_PhoneNumber = tBox_Bohoja_pNum.Text.Trim(),
                Hwanja_Age = age
            };

            if (string.IsNullOrEmpty(dto.Hwanja_Name) || string.IsNullOrEmpty(dto.Hwanja_No))
            {
                //MessageBox.Show("필수 입력 항목이 비어 있습니다. 이름과 환자 번호를 확인해주세요.");
                Dialog_Widget dialog = new Dialog_Widget("환자 수정", "이름과 환자 번호를 입력해주세요."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                return;
            }

            var api = new PatientApi();
            var success = await api.UpdateAsync(dto);

            if (success)
            {
                //MessageBox.Show("✅ 환자 정보가 수정되었습니다.");
                Dialog_Widget dialog = new Dialog_Widget("환자 수정", "✅ 환자 정보가 수정되었습니다."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                this.Close();  // 수정 후 창 닫기
                await refreshList(); // 환자 목록 새로고침
            }
            else
            {
                //MessageBox.Show("❌ 수정 실패: 서버 오류");
                Dialog_Widget dialog = new Dialog_Widget("환자 수정", "❌ 수정 실패: 서버 오류"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }
    }
}
