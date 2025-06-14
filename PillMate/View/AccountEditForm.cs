using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PillMate.ApiClients;
using PillMate.DTOs;

namespace PillMate.View
{
    public partial class AccountEditForm : Form
    {
        private readonly string _username;
        private readonly string _email;
        public AccountEditForm(string username, string email)
        {
            InitializeComponent();
            _username = username;
            _email = email;
        }
        private void AccountEditForm_Load(object sender, EventArgs e)
        {
            nameLabel.Text = _username;
            emailLabel.Text = _email;
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            string currentPw = txtCurrentPassword.Text.Trim();
            string newPw = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(currentPw) || string.IsNullOrEmpty(newPw))
            {
                MessageBox.Show("비밀번호를 모두 입력해주세요.");
                return;
            }

            var api = new AuthApi();
            var success = await api.ChangePasswordAsync(new ChangePasswordDto
            {
                Email = _email,
                CurrentPassword = currentPw,
                NewPassword = newPw
            });

            if (success)
            {
                MessageBox.Show("비밀번호가 성공적으로 변경되었습니다.");
                Close();
            }
            else
            {
                MessageBox.Show("비밀번호 변경에 실패했습니다.\n기존 비밀번호가 올바른지 확인해주세요.");
            }
        }
    }
}
