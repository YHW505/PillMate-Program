using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTOs;

namespace PillMate.View
{
    public partial class SettingView : Form
    {
        private readonly string _username;
        private readonly string _email;
        private readonly Principal _main;

        public SettingView(string username, string email, Principal main)
        {
            InitializeComponent();
            _username = username;
            _email = email;
            myemail.Text = _email;
            _main = main;
        }

        private void ChangeEmailbtn_Click(object sender, EventArgs e)
        {
            var form = new AccountEditForm(_username, _email);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // 부모 폼(Principal)을 찾고 종료
            var mainForm = this.ParentForm as Principal;
            if (mainForm != null)
            {
                mainForm.Hide(); // 또는 mainForm.Close(); → 완전 종료 원할 시
            }

            // 로그인 폼 열기
            var loginForm = new LoginForm();
            loginForm.Show();

            // 현재 SettingView 닫기
            this.Dispose();
        }

        private async void label9_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("정말 회원 탈퇴하시겠습니까?", "회원 탈퇴", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var passwordForm = new PasswordConfirmForm(); // 비밀번호 재확인 창
            if (passwordForm.ShowDialog() != DialogResult.OK) return;

            var api = new AuthApi();
            var success = await api.DeleteAccountAsync(new UserDto
            {
                Username = _username,
                Email = _email,
                PasswordHash = passwordForm.ConfirmedPassword // 평문
            });

            if (success)
            {
                MessageBox.Show("회원 탈퇴가 완료되었습니다.");
                var mainForm = this.ParentForm as Principal;
                if (mainForm != null)
                {
                    mainForm.Hide(); // 또는 mainForm.Close(); → 완전 종료 원할 시
                }

                // 로그인 폼 열기
                var loginForm = new LoginForm();
                loginForm.Show();

                // 현재 SettingView 닫기
                this.Dispose();
            }
            else
            {
                MessageBox.Show("회원 탈퇴 실패. 비밀번호를 확인해주세요.");
            }
        }
    }
}
