using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.View.Widget;

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
                Dialog_Widget dialog = new Dialog_Widget("오류", $"오류 발생: {ex.Message}"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show($"오류 발생: {ex.Message}");
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
            PillResister PillRegister = new PillResister(LoadPillsAsync); // LoadPatientsAsync 메소드를 전달
            PillRegister.StartPosition = FormStartPosition.CenterScreen;
            PillRegister.ShowDialog();
        }

        private void Edit_Pill_Btn(object sender, EventArgs e)
        {
            if (Pill_DataGreed.SelectedRows.Count > 0)
            {
                var selectedPill = Pill_DataGreed.SelectedRows[0].DataBoundItem as PillDto;

                if (selectedPill != null)
                {
                    PillEdit pillEdit = new PillEdit(selectedPill, LoadPillsAsync);
                    pillEdit.StartPosition = FormStartPosition.CenterScreen;
                    pillEdit.ShowDialog();
                }
            }
            else
            {
                //MessageBox.Show("수정할 약품을 선택해주세요.");
                Dialog_Widget dialog = new Dialog_Widget("약품 수정", "수정할 약품을 선택해주세요."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        private async void Deletebtn_Click_1(object sender, EventArgs e)
        {
            if (Pill_DataGreed.SelectedRows.Count > 0)
            {
                var selectedRow = Pill_DataGreed.SelectedRows[0].DataBoundItem as PillDto;

                if (selectedRow != null)
                {
                    Dialog_Delete_Pill dialog = new Dialog_Delete_Pill(selectedRow, LoadPillsAsync, LoadPillsToGrid); // LoadPatientsAsync 메소드를 전달
                    dialog.StartPosition = FormStartPosition.CenterScreen;
                    dialog.ShowDialog();
                }
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("약품 삭제", "삭제할 알약을 선택해주세요.."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("삭제할 알약을 선택해주세요.");
            }
        }

    }
}
