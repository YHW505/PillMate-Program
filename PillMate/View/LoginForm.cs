using PillMate.ApiClients;
using PillMate.DTOs;
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

namespace PillMate.View
{
    public partial class LoginForm : Form
    {
        private readonly AuthApi _authApi;
        public LoginForm()
        {
            InitializeComponent();
            _authApi = new AuthApi();
        }

        private async void Loginbtn_Click(object sender, EventArgs e)
        {
            var user = new UserDto
            {
                Username = Nametxt.Text,
                Email = Emailtxt.Text,
                PasswordHash = Passwordtxt.Text
            };

            var result = await _authApi.LoginAsync(user);

            if (result != null)
            {
                MessageBox.Show("로그인 성공!");
                var mainView = new Principal(result.Username, result.Email); //result.Username, result.Email
                mainView.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("로그인 실패: 사용자 이름, 이메일 또는 비밀번호 확인");
            }
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            var registerView = new RegisterView(_authApi);
            registerView.ShowDialog();
        }
    }
}
