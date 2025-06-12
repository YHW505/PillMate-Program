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
using PillMate.DTO;

namespace PillMate.View.Widget
{
    
    public partial class Dialog_Delete_Patient : Form
    {
        private readonly PatientApi _api;
        private readonly PatientDto _selectedPatient;
        private readonly Func<Task> load;

        public Dialog_Delete_Patient(PatientDto selectedPatient, Func<Task> Load)
        {
            InitializeComponent();
            _api = new PatientApi();
            _selectedPatient = selectedPatient;
            load = Load;
        }

        private  async void btn_OK_Click(object sender, EventArgs e)
        {
            var success = await _api.DeleteAsync(new DeletePatientDto { Id = _selectedPatient.Id ?? 0 });

            if (success)
            {
                //MessageBox.Show("환자가 삭제되었습니다.");
                Dialog_Widget dialog = new Dialog_Widget("삭제", "환자가 삭제되었습니다."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                await load(); // 환자 리스트 새로고침
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("삭제", "환자 삭제에 실패했습니다."); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("환자 삭제에 실패했습니다.");
            }
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
