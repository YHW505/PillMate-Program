using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.Models;
using Guna.UI2.WinForms;
using PillMate.View.Widget;


namespace PillMate.View
{
    public partial class TakenMedicineRegister : Form
    {
        //public Action<List<PillDto>>? OnPillsSelected;
        public Func<List<TakenMedicineDto>, Task>? OnPillsSelectedAsync;


        private List<PillDto> _pills = new();

        private readonly int _patientId;


        private TableLayoutPanel tableLayout;
        public TakenMedicineRegister(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }
        private async void ChkPill_Load(object sender, EventArgs e)
        {
            await TakenMedicineResisterView_Load();
        }
        private async Task TakenMedicineResisterView_Load()
        {
            var api = new PillApi();
            var pills = await api.GetAllAsync();

            tableLayout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = pills.Count,
                Dock = DockStyle.Fill,
                AutoScroll = true,
               
            };
            Controls.Add(tableLayout);

            foreach (var pill in pills)
            {
                var checkBox = new Guna2CheckBox
                {
                    Text = pill.Yank_Name,
                    Tag = pill,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Black,
                    Location = new Point(10, 15),
                    CheckedState = { FillColor = Color.DodgerBlue }
                };

                var textBox = new Guna2TextBox
                {
                    Enabled = false,
                    Width = 65,
                    Tag = pill,
                    BorderRadius = 5,
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(200, 5)
                };

                //var checkBox = new CheckBox
                //{
                //    Text = pill.Yank_Name,
                //    Tag = pill
                //};

                //var textBox = new TextBox
                //{
                //    Enabled = false,
                //    Width = 50,
                //    Tag = pill
                //};

                // 체크되었을 때만 텍스트박스 활성화
                checkBox.CheckedChanged += (s, e) => {
                    textBox.Enabled = checkBox.Checked;
                };

                tableLayout.Controls.Add(checkBox);
                tableLayout.Controls.Add(textBox);
                guna2Panel_container.Controls.Add(tableLayout);
            }
            
        }




        //private async Task TakenMedicineResisterView_Load()
        //{
        //    var api = new PillAPI();
        //    var pills = await api.GetAllAsync();

        //    // 컨테이너 설정 (스크롤 되게)
        //    guna2Panel_container.Controls.Clear();
        //    guna2Panel_container.AutoScroll = true;



        //    foreach (var pill in pills)
        //    {
        //        // ✅ pillPanel을 루프 안에서 새로 생성
        //        var pillPanel = new Guna2Panel
        //        {
        //            Width = 325,
        //            Height = 50,
        //            BorderRadius = 5,
        //            BorderThickness = 1,
        //            BorderColor = Color.LightGray,
        //            Margin = new Padding(5),
        //            Padding = new Padding(10),
        //            BackColor = Color.White
        //        };

        //var checkBox = new Guna2CheckBox
        //{
        //    Text = pill.Yank_Name,
        //    Tag = pill,
        //    AutoSize = true,
        //    Font = new Font("Segoe UI", 10),
        //    ForeColor = Color.Black,
        //    Location = new Point(10, 15),
        //    CheckedState = { FillColor = Color.DodgerBlue }
        //};

        //var textBox = new Guna2TextBox
        //{
        //    Enabled = false,
        //    Width = 65,
        //    Tag = pill,
        //    BorderRadius = 5,
        //    Font = new Font("Segoe UI", 10),
        //    PlaceholderText = "복용량",
        //    Location = new Point(200, 5)
        //};

        //        checkBox.CheckedChanged += (s, e) =>
        //        {
        //            textBox.Enabled = checkBox.Checked;
        //        };

        //        pillPanel.Controls.Add(checkBox);
        //        pillPanel.Controls.Add(textBox);

        //        // ✅ 매 반복마다 생성된 패널을 추가
        //        guna2Panel_container.Controls.Add(pillPanel);

        //    }
        //}




        public List<PillDto> GetSelectedPills()
        {
            var selected = new List<PillDto>();
            foreach (var ctrl in tableLayout.Controls)
            {
                if (ctrl is CheckBox cb && cb.Checked)
                {
                    if (cb.Tag is PillDto pill)
                        selected.Add(pill);
                }
            }
            return selected;
        }


        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var list = new List<TakenMedicineDto>();
            var _takenApi = new TakenMedicineAPI();

            // 기존 복약 목록
            var existingMedicines = await _takenApi.GetTakenMedicinesAsync(_patientId);

            bool anyRegistered = false;

            for (int i = 0; i < tableLayout.Controls.Count; i += 2)
            {
                var chk = tableLayout.Controls[i] as Guna2CheckBox;
                var txt = tableLayout.Controls[i + 1] as Guna2TextBox;

                if (chk?.Checked == true && chk.Tag is PillDto pill && int.TryParse(txt?.Text, out int dosage))
                {
                    bool isDuplicate = existingMedicines.Any(m => m.PillId == pill.Id);
                    if (isDuplicate)
                    {
                        Dialog_Widget dialog = new Dialog_Widget("복약 등록", $"❗'{pill.Yank_Name}' 약은 이미 등록되어 있습니다."); // LoadPatientsAsync 메소드를 전달
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.ShowDialog();
                        //MessageBox.Show($"❗ '{pill.Yank_Name}' 약은 이미 등록되어 있습니다.", "중복 알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    var dto = new TakenMedicineDto
                    {
                        PatientId = _patientId,
                        PillId = pill.Id,
                        Dosage = dosage.ToString()
                    };

                    bool isSuccess = await _takenApi.CreateTakenMedicineAsync(dto);
                    if (isSuccess)
                    {
                        list.Add(dto);
                        Dialog_Widget dialog = new Dialog_Widget("복약 등록", "✅ 복약 등록이 완료되었습니다"); // LoadPatientsAsync 메소드를 전달
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.ShowDialog();
                        //MessageBox.Show("✅ 복약 등록이 완료되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Dialog_Widget dialog = new Dialog_Widget("복약 등록", $"❌ '{pill.Yank_Name}' 등록 실패"); // LoadPatientsAsync 메소드를 전달
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.ShowDialog();
                        //MessageBox.Show($"❌ '{pill.Yank_Name}' 등록 실패", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (OnPillsSelectedAsync != null)
            {
                await OnPillsSelectedAsync(list);
            }

            this.Close();
        }
    }
}
