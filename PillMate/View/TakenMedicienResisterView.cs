using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PillMate.View
{
    public partial class TakenMedicineResisterView : Form
    {

        //public Action<List<PillDto>>? OnPillsSelected;
        public Func<List<TakenMedicineDto>, Task>? OnPillsSelectedAsync;


        private List<PillDto> _pills = new();

        private readonly TakenMedicineAPI _takenmedicineApi = new TakenMedicineAPI();


        private readonly int _patientId;

        private TableLayoutPanel tableLayout;

        public TakenMedicineResisterView(int patientId)
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
            var api = new PillAPI();
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
                var checkBox = new CheckBox
                {
                    Text = pill.Yank_Name,
                    Tag = pill
                };

                var textBox = new TextBox
                {
                    Enabled = false,
                    Width = 50,
                    Tag = pill
                };

                // 체크되었을 때만 텍스트박스 활성화
                checkBox.CheckedChanged += (s, e) => {
                    textBox.Enabled = checkBox.Checked;
                };

                tableLayout.Controls.Add(checkBox);
                tableLayout.Controls.Add(textBox);
            }
        }


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
                var chk = tableLayout.Controls[i] as CheckBox;
                var txt = tableLayout.Controls[i + 1] as TextBox;

                if (chk?.Checked == true && chk.Tag is PillDto pill && int.TryParse(txt?.Text, out int dosage))
                {
                    bool isDuplicate = existingMedicines.Any(m => m.PillId == pill.Id);
                    if (isDuplicate)
                    {
                        MessageBox.Show($"❗ '{pill.Yank_Name}' 약은 이미 등록되어 있습니다.", "중복 알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("✅ 복약 등록이 완료되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"❌ '{pill.Yank_Name}' 등록 실패", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
