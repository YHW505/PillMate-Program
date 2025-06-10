using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.Client.ApiClients;
using PillMate.DTO;

namespace PillMate.View
{
    public partial class Pill : Form
    {
        private readonly PillAPI _api;
        public Pill()
        {
            InitializeComponent();
            _api = new PillAPI();
            this.Load += PillForm_Load;
        }
        private async Task LoadPillsAsync()
        {
            try
            {
                var Pills = await _api.GetPillsAsync();
                Pill_DataGreed.Columns.Clear(); // 이전 열 제거

                Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "id",
                    HeaderText = "No."
                });
                Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "yank_name",
                    HeaderText = "품명"
                });
                Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "yank_cnt",
                    HeaderText = "수량"
                });
                Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "yank_num",
                    HeaderText = "위치" // 약품 번호로 되어있는데 바꾸는게 좋을듯
                });

                Pill_DataGreed.DataSource = Pills;
                pillcnt.Text = Pills.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }
        private async Task LoadPillsToGrid()
        {
            var pillList = await _api.GetPillsAsync();
            Pill_DataGreed.DataSource = pillList;
        }
        private async void PillForm_Load(object sender, EventArgs e)
        {
            await LoadPillsAsync();
            await LoadPillsToGrid();
        }
        private void Createbtn_Click_1(object sender, EventArgs e)
        {
            PillRegisterView PillRegisterView = new PillRegisterView(LoadPillsAsync); // LoadPatientsAsync 메소드를 전달
            PillRegisterView.StartPosition = FormStartPosition.CenterScreen;
            PillRegisterView.ShowDialog();
        }

        private async void Deletebtn_Click_1(object sender, EventArgs e)
        {
            if (Pill_DataGreed.SelectedRows.Count > 0)
            {
                var selectedRow = Pill_DataGreed.SelectedRows[0].DataBoundItem as PillDto;

                if (selectedRow != null)
                {
                    var id = selectedRow.Id;
                    // 삭제 확인 메시지
                    var confirm = MessageBox.Show($"정말로 ID {id}번 알약을 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {

                        await _api.DeletePillAsync(id);
                        await LoadPillsToGrid();
                    }
                    //MessageBox.Show($"ID {id}번 알약이 삭제되었습니다.", "삭제");
                }
            }
            else
            {
                MessageBox.Show("삭제할 알약을 선택해주세요.");
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            /// 실험중 
            PillRegisterView PillRegisterView = new PillRegisterView(LoadPillsAsync); // LoadPatientsAsync 메소드를 전달
            PillRegisterView.StartPosition = FormStartPosition.CenterScreen;
            PillRegisterView.ShowDialog();
        }
    }
}
