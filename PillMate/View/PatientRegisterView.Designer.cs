namespace PillMate.View
{
    partial class PatientRegisterView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.성별 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGuardianName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGuardianPhone = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHwanjaAge = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "환자 이름";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(230, 41);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(124, 28);
            this.txtName.TabIndex = 1;
            // 
            // 성별
            // 
            this.성별.AutoSize = true;
            this.성별.Location = new System.Drawing.Point(70, 109);
            this.성별.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.성별.Name = "성별";
            this.성별.Size = new System.Drawing.Size(44, 18);
            this.성별.TabIndex = 2;
            this.성별.Text = "성별";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "남",
            "여",
            "기타"});
            this.cmbGender.Location = new System.Drawing.Point(230, 106);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(124, 26);
            this.cmbGender.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "환자 번호";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(230, 162);
            this.txtNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(124, 28);
            this.txtNo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 229);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "병실 정보";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(230, 226);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(124, 28);
            this.txtRoom.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 286);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "환자 전화번호";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(230, 282);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(124, 28);
            this.txtPhone.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 343);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "보호자 이름";
            // 
            // txtGuardianName
            // 
            this.txtGuardianName.Location = new System.Drawing.Point(230, 340);
            this.txtGuardianName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGuardianName.Name = "txtGuardianName";
            this.txtGuardianName.Size = new System.Drawing.Size(124, 28);
            this.txtGuardianName.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 400);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "보호자 전화번호";
            // 
            // txtGuardianPhone
            // 
            this.txtGuardianPhone.Location = new System.Drawing.Point(230, 396);
            this.txtGuardianPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGuardianPhone.Name = "txtGuardianPhone";
            this.txtGuardianPhone.Size = new System.Drawing.Size(124, 28);
            this.txtGuardianPhone.TabIndex = 13;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(154, 518);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(94, 28);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "등록";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "환자 나이";
            // 
            // txtHwanjaAge
            // 
            this.txtHwanjaAge.Location = new System.Drawing.Point(230, 452);
            this.txtHwanjaAge.Name = "txtHwanjaAge";
            this.txtHwanjaAge.Size = new System.Drawing.Size(124, 28);
            this.txtHwanjaAge.TabIndex = 16;
            // 
            // PatientRegisterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 583);
            this.Controls.Add(this.txtHwanjaAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtGuardianPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGuardianName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.성별);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PatientRegisterView";
            this.Text = "환자 등록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label 성별;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGuardianName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtGuardianPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHwanjaAge;
    }
}
