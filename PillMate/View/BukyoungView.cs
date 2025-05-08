using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.ApiClients;

namespace PillMate.View
{
    public partial class BukyoungView : UserControl
    {

        private readonly BukyoungStatusApi _api;

        public BukyoungView()
        {
            InitializeComponent();
            _api = new BukyoungStatusApi();

        }

        public async void Load_BukyoungStatus(object sender, EventArgs e)
        {
            await LoadBukyoungStatusAsync();
        }

        public async Task LoadBukyoungStatusAsync()
        {
            try
            {
                var BokyoungStatus = await _api.GetAllAsync();

                // 복용하지 않았으면 복용 시간에 "X"를 넣음
                foreach (var status in BokyoungStatus)
                {
                    if (!status.Bukyoung_Chk)
                        status.Bukyoung_At = DateTime.MinValue; // DateTime 속성일 경우
                }

                Bukyoung_Gridview.Columns.Clear(); // 이전 열 제거

                Bukyoung_Gridview.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "hwanja_name",
                    HeaderText = "환자 이름"
                });
                Bukyoung_Gridview.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "hwanja_no",
                    HeaderText = "환자 번호"
                });
                Bukyoung_Gridview.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Bukyoung_Chk",
                    HeaderText = "복용 현황",
                    Name = "Bukyoung_Chk",
                    ReadOnly = true
                });
                Bukyoung_Gridview.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DisplayTime", // <- 주의: 아래에서 만드는 가공된 속성
                    HeaderText = "복용 시간"
                });

                // 복용 시간 표시를 위해 DisplayTime 속성 추가
                var displayData = BokyoungStatus.Select(s => new
                {
                    s.Hwanja_Name,
                    s.Hwanja_No,
                    s.Bukyoung_Chk,
                    DisplayTime = s.Bukyoung_Chk ? s.Bukyoung_At.ToString("HH:mm:ss") : ""
                }).ToList();

                Bukyoung_Gridview.DataSource = displayData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }




    }
}
