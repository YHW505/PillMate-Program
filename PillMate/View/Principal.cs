using System;
using System.Windows.Forms;

namespace PillMate.View
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e) // home load
        {
            guna2ShadowForm1.SetShadowForm(this);
            label_val.Text = "Dashboard Overview";
            //container(new Dashboard());
        }

        private void guna2Button1_Click(object sender, EventArgs e) //home
        {
            label_val.Text = "Dashboard Overview";
            //container(new Dashboard());
        }

        private void container(object _control)
        {
            if (guna2Panel_container.Controls.Count > 0)
                guna2Panel_container.Controls.Clear();

            if (_control is Form fm)
            {
                fm.TopLevel = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                fm.Dock = DockStyle.Fill;
                guna2Panel_container.Controls.Add(fm);
                guna2Panel_container.Tag = fm;
                fm.Show();
            }
            else if (_control is UserControl uc)
            {
                uc.Dock = DockStyle.Fill;
                guna2Panel_container.Controls.Add(uc);
                guna2Panel_container.Tag = uc;
                uc.Show(); // 없어도 되지만 있어도 안전함
            }
            else
            {
                MessageBox.Show("알 수 없는 컨트롤 타입입니다.");
            }
        }


        private void guna2Button3_Click(object sender, EventArgs e) //patients
        {
            label_val.Text = "Patients List";
            container(new Patient());
        }

        private void guna2Button4_Click(object sender, EventArgs e) //pill
        {
            label_val.Text = "Pill List";
            container(new PillView());
        }

        private void btnset_Click(object sender, EventArgs e)
        {
            label_val.Text = "Setting";
            container(new PatientView());
        }
    }
}
