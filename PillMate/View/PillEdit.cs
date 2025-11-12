using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.View.Widget;

namespace PillMate.View
{
    public partial class PillEdit : Form
    {
        private readonly Func<Task> refreshList;
        private readonly PillDto selectedPill;
        private readonly PillApi _api;

        public PillEdit(PillDto selectedPill, Func<Task> refreshList)
        {
            InitializeComponent();
            this.selectedPill = selectedPill;
            this.refreshList = refreshList;
            _api = new PillApi();

            // ✅ (주의) 디자이너에서 Load 이벤트 이미 등록되어 있음
            // => 여기서 LoadPillData() 직접 호출하지 않음
        }

        // ✅ 폼이 로드될 때 자동 호출됨 (디자이너에서 연결되어 있음)
        private void PillEditView_Load(object sender, EventArgs e)
        {
            LoadPillData();
        }

        // ✅ 기존 약품 데이터 불러오기
        private void LoadPillData()
        {
            if (selectedPill == null)
                return;

            txtName.Text = selectedPill.Yank_Name;
            txtNumber.Text = selectedPill.Yank_Num;
            txtCount.Text = selectedPill.Yank_Cnt.ToString();
            txtManufacturer.Text = selectedPill.Manufacturer;
            txtCategory.Text = selectedPill.Category;
            dtpExpiration.Value = selectedPill.ExpirationDate ?? DateTime.Now;
            txtStorage.Text = selectedPill.StorageLocation;
            txtDescription.Text = selectedPill.Description;
        }

        // ✅ 저장 버튼 클릭 시 (수정 실행)
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 유효성 검사
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

                // 수정된 데이터 매핑
                var updatedPill = new PillDto
                {
                    Id = selectedPill.Id,
                    Yank_Name = txtName.Text.Trim(),
                    Yank_Num = txtNumber.Text.Trim(),
                    Yank_Cnt = quantity,
                    Manufacturer = txtManufacturer.Text.Trim(),
                    Category = txtCategory.Text.Trim(),
                    ExpirationDate = (DateTime?)dtpExpiration.Value, // ✅ 명시적 캐스팅
                    Description = txtDescription.Text.Trim(),
                    StorageLocation = txtStorage.Text.Trim()
                };

                // ✅ API 호출 (UpdateAsync or UpdatePillAsync 중 실제 사용 중인 메서드 확인)
                var success = await _api.UpdateAsync(updatedPill.Id, updatedPill);

                if (success)
                {
                    ShowDialogMessage("약품 수정", "✅ 약품 정보가 성공적으로 수정되었습니다.");
                    await refreshList();  // 리스트 새로고침
                    this.Close();
                }
                else
                {
                    ShowDialogMessage("오류", "❌ 수정 실패: 서버 응답이 올바르지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                ShowDialogMessage("예외 발생", $"수정 중 오류 발생: {ex.Message}");
            }
        }

        // ✅ 취소 버튼
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ✅ 공통 다이얼로그
        private void ShowDialogMessage(string title, string message)
        {
            Dialog_Widget dialog = new Dialog_Widget(title, message);
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }
    }
}
