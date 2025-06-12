using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.View.Widget;

namespace PillMate.View
{
    public partial class PillResister : Form
    {
        private readonly Func<Task> refreshList;
        public PillResister(Func<Task> refreshList)
        {
            InitializeComponent();
            this.refreshList = refreshList;
        }

        private async void Pill_Save_Button_Click(object sender, EventArgs e)
        {
            var dto = new PillDto
            {
                Yank_Name = tBox_PillName.Text.Trim(),
                Yank_Cnt = int.Parse(tBox_PillCnt.Text.Trim()),
                Yank_Num = tBox_PillNum.Text.Trim()
            };

            if (string.IsNullOrEmpty(dto.Yank_Name) || string.IsNullOrEmpty(dto.Yank_Num))
            {
                Dialog_Widget dialog = new Dialog_Widget("약품 등록", "알약 이름과 알약 번호를 확인해주세요."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("필수 입력 항목이 비어 있습니다. 알약 이름과 알약 번호를 확인해주세요.");
                return;
            }

            var api = new PillAPI();
            var success = await api.CreatePillAsync(dto);

            if (success)
            {
                Dialog_Widget dialog = new Dialog_Widget("약품 등록", "✅ 약 등록이 완료되었습니다."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("✅ 약 등록이 완료되었습니다.");
                this.Close();  // 등록 후 창 닫기
                await refreshList(); // 환자 목록 새로고침
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("오류", "❌ 등록 실패: 서버 오류."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("❌ 등록 실패: 서버 오류");
            }
        }

    }
}
