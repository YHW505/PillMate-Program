using System;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTOs;

namespace PillMate.View
{
    public partial class RegisterView : Form
    {
        private readonly AuthApi _authApi;

        // ✅ 생성자에서 AuthApi 주입
        public RegisterView(AuthApi authApi)
        {
            InitializeComponent();
            _authApi = authApi;
        }

        // ✅ async 추가
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var user = new UserDto
            {
                Username = txtUsername.Text,
                PasswordHash = txtPassword.Text,
                Email = txtEmail.Text
            };

            var success = await _authApi.RegisterAsync(user);
            if (success)
            {
                MessageBox.Show("회원가입 성공");
                this.Close();
            }
            else
            {
                MessageBox.Show("회원가입 실패: 중복 아이디 등");
            }
        }
    }
}
