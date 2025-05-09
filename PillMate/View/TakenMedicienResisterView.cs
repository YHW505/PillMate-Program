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

        public TakenMedicineResisterView(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        

        private TableLayoutPanel tableLayout;

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

        


        //private async Task LoadPillListAsync()
        //{
        //    var api = new PillAPI();
        //    _pills = await api.GetAllAsync();

        //    foreach (var pill in _pills)
        //    {
        //        var checkbox = new CheckBox
        //        {
        //            Text = pill.Yank_Name,
        //            Tag = pill
        //        };
        //        flowLayoutPanel1.Controls.Add(checkbox); // 약 체크박스 추가
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
            var view = new PatientView();
            

            for (int i = 0; i < tableLayout.Controls.Count; i += 2)
            {
                var chk = tableLayout.Controls[i] as CheckBox;
                var txt = tableLayout.Controls[i + 1] as TextBox;

                if (chk?.Checked == true && chk.Tag is PillDto pill && int.TryParse(txt?.Text, out int dosage))
                {
                    var dto = new TakenMedicineDto
                    {
                        PatientId = _patientId,
                        PillId = pill.Id,
                        Dosage = dosage.ToString()
                    };
                    await _takenApi.CreateTakenMedicineAsync(dto); // ✅ DB 저장
                }
            }

            if (OnPillsSelectedAsync != null)
            {
                await OnPillsSelectedAsync(list);
            }

            this.Close();
        }
    }

        //private async void btnConfirm_Click(object sender, EventArgs e)
        //{
            //var selected = new List<TakenMedicineDto>();

        //    for (int i = 0; i < tableLayout.Controls.Count; i += 2)
        //    {
        //        var checkBox = tableLayout.Controls[i] as CheckBox;
        //        var textBox = tableLayout.Controls[i + 1] as TextBox;

        //        if (checkBox != null && checkBox.Checked && checkBox.Tag is PillDto pill)
        //        {
        //            if (int.TryParse(textBox.Text, out int dosage))
        //            {
        //                selected.Add(new TakenMedicineDto
        //                {
        //                    PillId = pill.Id,
        //                    Dosage = dosage.ToString()
        //                    // PatientId는 부모에서 넘겨받도록 설정
        //                });
        //            }
        //        }
        //    }

        //            if (OnPillsSelectedAsync != null)
        //            {
        //                await OnPillsSelectedAsync(selected);
        //}

        //    this.Close();
        //}


    }
