using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PillMate.View
{
    public partial class PillRegisterView : Form
    {
        private readonly Func<Task> refreshList;
        public PillRegisterView(Func<Task> refreshList)
        {
            InitializeComponent();
            this.refreshList = refreshList;
        }

        private async void Pill_Save_Button_Click(object sender, EventArgs e)
        {
            var dto = new PillDto
            {
                Yank_Name = YName_TextBox.Text.Trim(),
                Yank_Cnt = int.Parse(YCNT_TextBox.Text.Trim()),
                Yank_Num = YNum_TextBox.Text.Trim()
            };

            if (string.IsNullOrEmpty(dto.Yank_Name) || string.IsNullOrEmpty(dto.Yank_Num))
            {
                MessageBox.Show("필수 입력 항목이 비어 있습니다. 알약 이름과 알약 번호를 확인해주세요.");
                return;
            }

            var api = new PillAPI();
            var success = await api.CreatePillAsync(dto);

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
