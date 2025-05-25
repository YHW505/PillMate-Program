using System;
using System.Windows.Forms;

namespace PillMate.View
{
    public partial class MainUi : Form
    {
        int PanelWidth;
        bool isCollapsed;
        private readonly string _username;
        private readonly string _email;


        public MainUi(string username,string email) : this() 
        {
            _username = username;
            _email = email;
            namelabel.Text = _username;
            emaillabel.Text = _email;
        }

        public MainUi()
        {
            InitializeComponent();
            timer2.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            LoadView(new BukyoungView());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 50)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void moveSidePanel(Control btn)
        {
            panelSlide.Height = btn.Height;
            panelSlide.Top = btn.Top;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            LoadView(new BukyoungView());
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPatient);
            LoadView(new PatientView());
        }

        private void btnDrug_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnDrug);
            //LoadView(new PillView());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUser);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void LoadView(UserControl view)
        {
            MainPanel.Controls.Clear();        // 패널에 있는 기존 컨트롤 제거
            view.Dock = DockStyle.Fill;        // 꽉 채우게 설정
            MainPanel.Controls.Add(view);      // 새로운 컨트롤 추가
        }
    }
}
