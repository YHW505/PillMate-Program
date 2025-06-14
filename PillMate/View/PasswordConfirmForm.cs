using System;
using System.Windows.Forms;

namespace PillMate.View
{
    public partial class PasswordConfirmForm : Form
    {
        public string ConfirmedPassword => passwordBox.Text;

        public PasswordConfirmForm()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordBox.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
