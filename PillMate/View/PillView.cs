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

namespace PillMate.View
{
    public partial class PillView : Form
    {

        private PillAPI apiClient = new PillAPI();

        public PillView()
        {
            InitializeComponent();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            ToggleInputControls(false);
            this.Load += PillForm_Load;
        }
        private void ToggleInputControls(bool visible)
        {
            YName_Label.Visible = visible;
            YName_TextBox.Visible = visible;
            YCNT_TextBox.Visible = visible;
            YCnt_Label.Visible = visible;
            YNUM_Label.Visible = visible;
            YNum_TextBox.Visible = visible;
        }

        private void ClearInput()
        {
            YName_TextBox.Text = "";
            YCNT_TextBox.Text = "";
            YNum_TextBox.Text = "";
        }

        private void Pill_Register_Button_Click(object sender, EventArgs e)
        {
            ClearInput();
            ToggleInputControls(true);
        }

        private async void Pill_Delete_Button_Click(object sender, EventArgs e)
        {
            ToggleInputControls(false);
            ClearInput();
            if (Pill_DataGreed.SelectedRows.Count > 0)
            {
                // 선택된 행의 첫 번째 셀 (Id) 값 가져오기
                var selectedRow = Pill_DataGreed.SelectedRows[0];
                if (selectedRow.Cells["Id"].Value is int id)
                {
                    // 삭제 확인 메시지
                    var confirm = MessageBox.Show($"정말로 ID {id}번 알약을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {

                        await apiClient.DeletePillAsync(id);
                    }
                    MessageBox.Show($"ID {id}번 알약이 삭제되었습니다.", "삭제 확인");
                }
            }
            else
            {
                MessageBox.Show("삭제할 알약을 선택해주세요.");
            }
        }

        private async void Pill_Modify_Button_Click(object sender, EventArgs e)
        {
            var pill = new PillDto
            {
                Yank_Name = YName_TextBox.Text,
                Yank_Cnt = int.TryParse(YCNT_TextBox.Text, out int cnt) ? cnt : 0,
                Yank_Num = YNum_TextBox.Text
            };

            bool success = await apiClient.CreatePillAsync(pill);

            if (success)
            {
                MessageBox.Show("등록 성공!");
                await LoadPillsToGrid();
            }
            else
            {
                MessageBox.Show("등록 실패");
            }
        }

        private async void PillForm_Load(object sender, EventArgs e)
        {
            await LoadPillsToGrid();
        }

        private async Task LoadPillsToGrid()
        {
            var pillList = await apiClient.GetPillsAsync();
            Pill_DataGreed.DataSource = pillList;
        }
    }
}
