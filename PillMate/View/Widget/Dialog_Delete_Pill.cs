using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;

namespace PillMate.View.Widget
{
    public partial class Dialog_Delete_Pill : Form
    {
        private readonly PillAPI _api;
        private readonly PillDto _selectedPill;
        private readonly Func<Task> loadP;
        private readonly Func<Task> loadG;
        public Dialog_Delete_Pill(PillDto selectedPill, Func<Task> LoadPill, Func<Task> LoadGrid)
        {
            InitializeComponent();
            _api = new PillAPI();
            _selectedPill = selectedPill;
            loadP = LoadPill;
            loadG = LoadGrid;
            Msg_Dialog.Text = $"정말로 ID {_selectedPill.Id}번 알약을 삭제하시겠습니까?";
        }

        private async void btn_OK_Click(object sender, EventArgs e)
        {
            var id = _selectedPill.Id;
            // 삭제 확인 메시지


            await _api.DeletePillAsync(id);
            await loadG();
            await loadP();

            //MessageBox.Show($"ID {id}번 알약이 삭제되었습니다.", "삭제");
            Dialog_Widget dialog = new Dialog_Widget("약품 삭제", $"ID {id}번 알약이 삭제되었습니다."); // LoadPatientsAsync 메소드를 전달
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
