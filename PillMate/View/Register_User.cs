using System;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTOs;

namespace PillMate.View.Widget
{
    public partial class Register_User : Form
    {
        private readonly AuthApi _authApi;

        public Register_User(AuthApi authApi)
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
                Dialog_Widget dialog = new Dialog_Widget("회원가입", "회원가입 성공"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("회원가입 성공");
                this.Close();
            }
            else
            {
                Dialog_Widget dialog = new Dialog_Widget("회원가입", "회원가입 실패: 중복 아이디 등"); // LoadPatientsAsync 메소드를 전달
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                //MessageBox.Show("회원가입 실패: 중복 아이디 등");
            }
        }
    }
}
