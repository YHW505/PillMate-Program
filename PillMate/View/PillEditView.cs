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
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;

namespace PillMate.View
{

    public partial class PillEditView : Form
    {
        private readonly PillDto _selectedPill;
        private readonly Func<Task> refreshList;
        public PillEditView(PillDto selectedPill, Func<Task> refreshList)
        {
            InitializeComponent();
            _selectedPill = selectedPill;
            this.refreshList = refreshList;
        }

        private async void PillEditView_Load(object sender, EventArgs e)
        {
            tBox_PillName.Text = _selectedPill.Yank_Name;
            tBox_PillCnt.Text = _selectedPill.Yank_Cnt.ToString();
            tBox_PillNum.Text = _selectedPill.Yank_Num;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            
            var dto = new UpdatePillDto
            {
                Id = _selectedPill.Id,
                Yank_Name = tBox_PillName.Text.Trim(),
                Yank_Cnt = String.IsNullOrWhiteSpace(tBox_PillCnt.Text) ? 0 : int.Parse(tBox_PillCnt.Text.Trim()),
                Yank_Num = tBox_PillNum.Text.Trim(),
            };

            if (string.IsNullOrEmpty(dto.Yank_Name) || string.IsNullOrEmpty(dto.Yank_Num))
            {
                MessageBox.Show("필수 입력 항목이 비어 있습니다. 약품명과 약품번호를 확인해주세요.");
                return;
            }

            var api = new PillAPI();
            var success = await api.UpdatePillAsync(_selectedPill.Id, dto);

            if (success)
            {
                MessageBox.Show("✅ 약품 정보가 수정되었습니다.");
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
