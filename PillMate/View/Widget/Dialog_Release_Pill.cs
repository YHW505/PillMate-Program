using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.View.Widget;

namespace PillMate.View.Widget
{
    public partial class Dialog_Release_Pill : Form
    {
        private readonly StockTransactionApi _stockApi;
        private readonly PillDto _pill;
        private readonly Func<Task> _refreshList;

        public Dialog_Release_Pill(PillDto pill, Func<Task> refreshList)
        {
            InitializeComponent();
            _stockApi = new StockTransactionApi();
            _pill = pill;
            _refreshList = refreshList;

            lblPillName.Text = pill.Yank_Name;
            lblStock.Text = $"현재 재고: {pill.Yank_Cnt}개";
        }

        private async void btnRelease_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
                {
                    ShowDialog("출고 오류", "출고 수량을 올바르게 입력해주세요.");
                    return;
                }

                if (quantity > _pill.Yank_Cnt)
                {
                    ShowDialog("출고 오류", "재고보다 많은 수량을 출고할 수 없습니다.");
                    return;
                }

                var dto = new CreateStockTransactionDto
                {
                    PillId = _pill.Id,
                    Quantity = quantity,
                    PharmacistName = txtPharmacist.Text.Trim(),
                    Note = txtNote.Text.Trim()
                };

                var success = await _stockApi.CreateAsync(dto);

                if (success)
                {
                    ShowDialog("출고 완료", $"✅ {_pill.Yank_Name} {_pill.Id}번 약품이 출고되었습니다.");
                    await _refreshList();
                    this.Close();
                }
                else
                {
                    ShowDialog("출고 실패", "❌ 서버 응답이 올바르지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                ShowDialog("오류", $"예외 발생: {ex.Message}");
            }
        }

        private void ShowDialog(string title, string message)
        {
            var dialog = new Dialog_Widget(title, message);
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
