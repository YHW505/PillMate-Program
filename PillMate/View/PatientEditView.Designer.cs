namespace PillMate.View
{
    partial class PatientEditView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelNo;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelGuardianName;
        private System.Windows.Forms.Label labelGuardianPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGender; // 성별을 입력할 텍스트박스로 변경
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtGuardianName;
        private System.Windows.Forms.TextBox txtGuardianPhone;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox(); // 성별을 입력할 텍스트박스
            this.txtNo = new System.Windows.Forms.TextBox();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtGuardianName = new System.Windows.Forms.TextBox();
            this.txtGuardianPhone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelNo = new System.Windows.Forms.Label();
            this.labelRoom = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelGuardianName = new System.Windows.Forms.Label();
            this.labelGuardianPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 25);
            this.txtName.TabIndex = 0;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(150, 80); // 텍스트박스 위치
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(200, 25);
            this.txtGender.TabIndex = 1; // 텍스트박스 TabIndex 설정
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(150, 120);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(200, 25);
            this.txtNo.TabIndex = 2;
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(150, 160);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(200, 25);
            this.txtRoom.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(150, 200);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 25);
            this.txtPhone.TabIndex = 4;
            // 
            // txtGuardianName
            // 
            this.txtGuardianName.Location = new System.Drawing.Point(150, 240);
            this.txtGuardianName.Name = "txtGuardianName";
            this.txtGuardianName.Size = new System.Drawing.Size(200, 25);
            this.txtGuardianName.TabIndex = 5;
            // 
            // txtGuardianPhone
            // 
            this.txtGuardianPhone.Location = new System.Drawing.Point(150, 280);
            this.txtGuardianPhone.Name = "txtGuardianPhone";
            this.txtGuardianPhone.Size = new System.Drawing.Size(200, 25);
            this.txtGuardianPhone.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);  // 수정 버튼 클릭 이벤트 연결
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(40, 40);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(72, 15);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "환자 이름";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(40, 80);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(37, 15);
            this.labelGender.TabIndex = 9;
            this.labelGender.Text = "성별";
            // 
            // labelNo
            // 
            this.labelNo.AutoSize = true;
            this.labelNo.Location = new System.Drawing.Point(40, 120);
            this.labelNo.Name = "labelNo";
            this.labelNo.Size = new System.Drawing.Size(72, 15);
            this.labelNo.TabIndex = 10;
            this.labelNo.Text = "환자 번호";
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Location = new System.Drawing.Point(40, 160);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(72, 15);
            this.labelRoom.TabIndex = 11;
            this.labelRoom.Text = "병실 정보";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(40, 200);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(102, 15);
            this.labelPhone.TabIndex = 12;
            this.labelPhone.Text = "환자 전화번호";
            // 
            // labelGuardianName
            // 
            this.labelGuardianName.AutoSize = true;
            this.labelGuardianName.Location = new System.Drawing.Point(40, 240);
            this.labelGuardianName.Name = "labelGuardianName";
            this.labelGuardianName.Size = new System.Drawing.Size(87, 15);
            this.labelGuardianName.TabIndex = 13;
            this.labelGuardianName.Text = "보호자 이름";
            // 
            // labelGuardianPhone
            // 
            this.labelGuardianPhone.AutoSize = true;
            this.labelGuardianPhone.Location = new System.Drawing.Point(40, 280);
            this.labelGuardianPhone.Name = "labelGuardianPhone";
            this.labelGuardianPhone.Size = new System.Drawing.Size(117, 15);
            this.labelGuardianPhone.TabIndex = 14;
            this.labelGuardianPhone.Text = "보호자 전화번호";
            // 
            // PatientEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.labelGuardianPhone);
            this.Controls.Add(this.labelGuardianName);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.labelNo);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGuardianPhone);
            this.Controls.Add(this.txtGuardianName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.txtGender); // 텍스트박스 추가
            this.Controls.Add(this.txtName);
            this.Name = "PatientEditView";
            this.Text = "환자 정보 수정";
            this.Load += new System.EventHandler(this.PatientEditView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
