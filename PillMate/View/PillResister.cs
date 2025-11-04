using System;
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
        private readonly PillApi _api;

        public PillResister(Func<Task> refreshList)
        {
            InitializeComponent();
            this.refreshList = refreshList;
            _api = new PillApi();
        }

        // 저장 버튼 클릭
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 입력값 유효성 검사 및 DTO 매핑
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    ShowDialogMessage("입력 오류", "약품명을 입력해주세요.");
                    return;
                }

                if (!int.TryParse(txtCount.Text.Trim(), out int quantity))
                {
                    ShowDialogMessage("입력 오류", "수량은 숫자만 입력 가능합니다.");
                    return;
                }

                var dto = new PillDto
                {
                    Yank_Name = txtName.Text.Trim(),
                    Yank_Num = txtNumber.Text.Trim(),
                    Yank_Cnt = quantity,
                    Manufacturer = txtManufacturer.Text.Trim(),
                    Category = txtCategory.Text.Trim(),
                    ExpirationDate = dtpExpiration.Value,
                    Description = txtDescription.Text.Trim(),
                    StorageLocation = txtStorage.Text.Trim()
                };

                // 🔹 서버 요청
                var success = await _api.CreateAsync(dto);

                if (success)
                {
                    ShowDialogMessage("약품 등록", "✅ 새 약품이 성공적으로 등록되었습니다.");
                    await refreshList();
                    this.Close();
                }
                else
                {
                    ShowDialogMessage("오류", "❌ 등록 실패: 서버 요청 중 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                ShowDialogMessage("예외 발생", $"등록 중 오류 발생: {ex.Message}");
            }
        }

        // 공통 다이얼로그
        private void ShowDialogMessage(string title, string message)
        {
            Dialog_Widget dialog = new Dialog_Widget(title, message);
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        // 취소 버튼
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
