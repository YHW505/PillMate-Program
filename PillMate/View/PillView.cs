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
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.ApiClients;
using PillMate.Models;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Drawing.Printing;

namespace PillMate.View
{
    public partial class PillView : Form
    {

        private readonly PillAPI _api;

        public PillView()
        {
            InitializeComponent();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _api = new PillAPI();
            this.Load += PillForm_Load;
        }
        /*
        private void ClearInput()
        {
            YName_TextBox.Text = "";
            YCNT_TextBox.Text = "";
            YNum_TextBox.Text = "";
        }  
        */

        private async Task LoadPillsAsync()
        {
            try
            {
                var Pills = await _api.GetPillsAsync();
                Pill_DataGreed.Columns.Clear(); // 이전 열 제거

                Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "yank_name",
                    HeaderText = "약명"
                });
                Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "yank_cnt",
                    HeaderText = "잔여 개수"
                });
                Pill_DataGreed.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "yank_num",
                    HeaderText = "약품 번호"
                });


                Pill_DataGreed.DataSource = Pills;


                if (Pills != null && Pills.Count > 0)
                {
                    pillLabel.Text = $"총 {Pills.Count}개의 알약 데이터";
                }
                else
                {
                    pillLabel.Text = "알약 데이터가 없습니다.";
                }
            }
            catch (Exception ex)
            {
                pillLabel.Text = "데이터를 불러오는 데 실패했습니다.";
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }

        private void Pill_Register_Button_Click(object sender, EventArgs e)
        {
            /// 실험중 
            PillRegisterView PillRegisterView = new PillRegisterView(LoadPillsAsync); // LoadPatientsAsync 메소드를 전달
            PillRegisterView.StartPosition = FormStartPosition.CenterScreen;
            PillRegisterView.ShowDialog();
            ///
            ///
            /*
            var pill = new PillDto
            {
                Yank_Name = YName_TextBox.Text,
                Yank_Cnt = int.TryParse(YCNT_TextBox.Text, out int cnt) ? cnt : 0,
                Yank_Num = YNum_TextBox.Text
            };

            bool success = await _api.CreatePillAsync(pill);

            if (success && pill != null)
            {
                MessageBox.Show("등록 성공!", "등록");
                await LoadPillsToGrid();
                ClearInput();
            }
            else
            {
                MessageBox.Show("등록 실패", "등록");
            }
            */
        }


        private async void Pill_Delete_Button_Click(object sender, EventArgs e)
        {
            //ToggleInputControls(false);
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
                    MessageBox.Show($"ID {id}번 알약이 삭제되었습니다.", "삭제");
                }
            }
            else
            {
                MessageBox.Show("삭제할 알약을 선택해주세요.");
            }
        }



        private async void PillForm_Load(object sender, EventArgs e)
        {
            await LoadPillsAsync();
            await LoadPillsToGrid();
        }

        private async Task LoadPillsToGrid()
        {
            var pillList = await _api.GetPillsAsync();
            Pill_DataGreed.DataSource = pillList;
        }
    }
}
