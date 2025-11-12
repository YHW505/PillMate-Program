using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.Client.ApiClients;
using PillMate.DTO;

namespace PillMate.View.Widget
{
    public partial class Dialog_Delete_Pill : Form
    {
        private readonly PillApi _api;
        private readonly PillDto _selectedPill;
        private readonly Func<Task> loadP;
        private readonly Func<Task> loadG;

        public Dialog_Delete_Pill(PillDto selectedPill, Func<Task> LoadPill, Func<Task> LoadGrid)
        {
            InitializeComponent();
            _api = new PillApi();
            _selectedPill = selectedPill;
            loadP = LoadPill;
            loadG = LoadGrid;

            // ✅ 정보 표시
            SetPillInfo();
        }

        private void SetPillInfo()
        {
            string name = string.IsNullOrWhiteSpace(_selectedPill.Yank_Name) ? "(이름 없음)" : _selectedPill.Yank_Name;
            string manufacturer = string.IsNullOrWhiteSpace(_selectedPill.Manufacturer) ? "제조사 정보 없음" : _selectedPill.Manufacturer;
            string expiration = _selectedPill.ExpirationDate.HasValue
                ? _selectedPill.ExpirationDate.Value.ToString("yyyy-MM-dd")
                : "유통기한 정보 없음";

            lblTitle.Text = $"{_selectedPill.Id}번 약품을 삭제하시겠습니까?";
            lblName.Text = $"약품명: {name}";
            lblManufacturer.Text = $"제조사: {manufacturer}";
            lblExpiration.Text = $"유통기한: {expiration}";
        }

        private async void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                int id = _selectedPill.Id;
                string name = _selectedPill.Yank_Name ?? $"ID {id}";

                bool success = await _api.DeleteAsync(id);
                if (!success)
                {
                    var errorDialog = new Dialog_Widget("삭제 실패", "서버에서 약품 삭제에 실패했습니다.");
                    errorDialog.StartPosition = FormStartPosition.CenterScreen;
                    errorDialog.ShowDialog();
                    return;
                }

                await loadG();
                await loadP();

                var dialog = new Dialog_Widget("약품 삭제", $"✅ '{name}' 약품(ID {id})이 삭제되었습니다.");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();

                this.Close();
            }
            catch (Exception ex)
            {
                var dialog = new Dialog_Widget("오류", $"삭제 중 오류 발생: {ex.Message}");
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
