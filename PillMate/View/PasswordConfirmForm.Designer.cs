using System.Windows.Forms;

namespace PillMate.View
{
    partial class PasswordConfirmForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button cancelBtn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "탈퇴하시려면 비밀번호를 입력해주세요";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(23, 50);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '●';
            this.passwordBox.Size = new System.Drawing.Size(240, 21);
            this.passwordBox.TabIndex = 1;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(56, 90);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 2;
            this.confirmBtn.Text = "확인";
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(170, 90);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "취소";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // PasswordConfirmForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 140);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "PasswordConfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "비밀번호 확인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
