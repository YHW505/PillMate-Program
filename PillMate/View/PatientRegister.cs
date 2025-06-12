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
using PillMate.DTO;
using System.Xml.Linq;
using PillMate.View.Widget;

namespace PillMate.View
{
    public partial class PatientRegister : Form
    {
        private readonly Func<Task> refreshList;
        public PatientRegister(Func<Task> refreshList)
        {
            InitializeComponent();
            this.refreshList = refreshList;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tBox_Hwanja_Age.Text.Trim(), out int age))
            {
                Dialog_Widget dialog = new Dialog_Widget("환자 등록", "나이는 숫자로 입력해주세요."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("나이는 숫자로 입력해주세요.");
                return;
            }

            var dto = new CreatePatientDto
            {
                Hwanja_Name = tBox_Hwanja_Name.Text.Trim(),
                Hwanja_Gender = cBox_Hwanja_Gender.SelectedItem?.ToString() ?? "",
                Hwanja_No = tBox_Hwanja_Num.Text.Trim(),
                Hwanja_Room = tBox_Hwanja_Room.Text.Trim(),
                Hwanja_PhoneNumber = tBox_Hwanja_pNum.Text.Trim(),
                Bohoja_Name = tBox_Bohoja_Name.Text.Trim(),
                Bohoja_PhoneNumber = tBox_Bohoja_pNum.Text.Trim(),
                Hwanja_Age = age
            };

            if (string.IsNullOrEmpty(dto.Hwanja_Name) || string.IsNullOrEmpty(dto.Hwanja_No))
            {
                Dialog_Widget dialog = new Dialog_Widget("환자 등록", "이름과 환자 번호를 확인해주세요."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("필수 입력 항목이 비어 있습니다. 이름과 환자 번호를 확인해주세요.");
                return;
            }

            var api = new PatientApi();
            var patientId = await api.AddAsync(dto);

            if (patientId.HasValue)
            {
                // BukyoungStatus 등록
                var bukApi = new BukyoungStatusApi();
                var bukDto = new CreateBukyoungStatusDto
                {
                    Hwanja_Name = dto.Hwanja_Name,
                    Hwanja_No = dto.Hwanja_No,
                    PatientId = patientId.Value,
                    Bukyoung_Chk = false, // 기본값
                    Bukyoung_At = DateTime.Now
                };

                await bukApi.AddAsync(bukDto);

                Dialog_Widget dialog = new Dialog_Widget("환자 등록", "✅ 환자 및 복용 상태 등록 완료!"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("✅ 환자 및 복용 상태 등록 완료!");
                this.Close();
                await refreshList();
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("환자 등록", "❌ 등록 실패: 서버 오류"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("❌ 등록 실패: 서버 오류");
            }
        }
    }
}
