using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.View;

namespace PillMate
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Home_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void Patient_Button_Click(object sender, EventArgs e)
        {
            LoadView(new PatientView());
        }

        private void Pill_Button_Click(object sender, EventArgs e)
        {
            LoadView(new PillView());
        }

        private void LoadView(UserControl view)
        {
            Main_Pannel.Controls.Clear();        // 패널에 있는 기존 컨트롤 제거
            view.Dock = DockStyle.Fill;        // 꽉 채우게 설정
            Main_Pannel.Controls.Add(view);      // 새로운 컨트롤 추가
        }
    }
}