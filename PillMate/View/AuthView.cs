using System;
using System.Drawing;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTOs;

namespace PillMate.View
{
    public partial class AuthView : Form
    {
        private readonly AuthApi _authApi;

        public AuthView()
        {
            InitializeComponent();
            _authApi = new AuthApi();

            // 👉 Placeholder 초기 설정
            txtUsername.Text = "Name";
            txtUsername.ForeColor = Color.Gray;

            txtEmail.Text = "Email";
            txtEmail.ForeColor = Color.Gray;

            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;

            // 👉 이벤트 핸들러 등록
            txtUsername.Enter += txtUsername_Enter;
            txtUsername.Leave += txtUsername_Leave;

            txtEmail.Enter += txtEmail_Enter;
            txtEmail.Leave += txtEmail_Leave;

            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var user = new UserDto
            {
                Username = txtUsername.Text,
                Email = txtEmail.Text,
                PasswordHash = txtPassword.Text
            };

            var result = await _authApi.LoginAsync(user);

            if (result != null)
            {
                MessageBox.Show("로그인 성공!");
                var mainView = new MainUi(result.Username,result.Email);
                mainView.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("로그인 실패: 사용자 이름, 이메일 또는 비밀번호 확인");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerView = new RegisterView(_authApi);
            registerView.ShowDialog();
        }

        // 📌 Placeholder 효과 핸들러들
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Name")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Name";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }
    }
}
