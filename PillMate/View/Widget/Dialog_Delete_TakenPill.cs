using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PillMate.Client.ApiClients;
using PillMate.DTO;

namespace PillMate.View.Widget
{
    public partial class Dialog_Delete_TakenPill : Form
    {
        private readonly TakenMedicineDto _tkMedicenDTO;
        private readonly ListView _listV;
        private Func<Task> _load;
        private readonly ListViewItem _selectedItem;
        public Dialog_Delete_TakenPill(TakenMedicineDto tkMedicenDTO, ListView listV, Func<Task> load, ListViewItem selectedItem)
        {
            InitializeComponent();
            _tkMedicenDTO = tkMedicenDTO;
            _listV = listV;
            _load = load;
            _selectedItem = selectedItem;


        }

        private async void btn_OK_Click(object sender, EventArgs e)
        {
            var api = new TakenMedicineAPI();
            bool isSuccess = await api.DeleteTakenMedicineAsync(_tkMedicenDTO.Id);

            if (isSuccess)
            {
                //var selectedPatient = guna2DataGridView1.SelectedRows[0].DataBoundItem as PatientDto;

                _listV.Items.Remove(_selectedItem); // ✅ 3번 코드: ListView에서 삭제
                await _load();
                Dialog_Widget dialog = new Dialog_Widget("삭제", "✅ 삭제 완료"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("✅ 삭제 완료");
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("삭제", "✅ 삭제 실패"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                MessageBox.Show("❌ 삭제 실패");
            }
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
