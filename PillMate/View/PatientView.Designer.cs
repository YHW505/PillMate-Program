namespace PillMate.View
{
    partial class PatientView
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.btnEditPatient = new System.Windows.Forms.Button();  // 수정 버튼 추가
            this.btnDeletePatient = new System.Windows.Forms.Button(); // 삭제 버튼 추가
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(591, 324);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(3, 327);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(202, 15);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "환자 데이터를 불러오는 중...";
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Font = new System.Drawing.Font("굴림", 12F);
            this.btnAddPatient.Location = new System.Drawing.Point(597, 3);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(192, 94);
            this.btnAddPatient.TabIndex = 2;
            this.btnAddPatient.Text = "환자 등록";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Font = new System.Drawing.Font("굴림", 12F);
            this.btnEditPatient.Location = new System.Drawing.Point(597, 103);  // 위치 조정
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(192, 94); // 크기 설정
            this.btnEditPatient.TabIndex = 3;
            this.btnEditPatient.Text = "환자 수정";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            this.btnEditPatient.Click += new System.EventHandler(this.btnEditPatient_Click);  // 클릭 이벤트 연결

            // 
            // btnDeletePatient
            // 
            this.btnDeletePatient.Font = new System.Drawing.Font("굴림", 12F);
            this.btnDeletePatient.Location = new System.Drawing.Point(597, 203); // 위치 설정
            this.btnEditPatient.Name = "btnDeletePatient";
            this.btnDeletePatient.Size = new System.Drawing.Size(192, 94); // 크기 설정
            this.btnDeletePatient.TabIndex = 4;
            this.btnDeletePatient.Text = "환자 삭제";  // 버튼 텍스트 설정
            this.btnDeletePatient.UseVisualStyleBackColor = true;
            this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click); // 클릭 이벤트 연결

            // 
            // PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnDeletePatient);
            this.Controls.Add(this.btnEditPatient);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PatientView";
            this.Size = new System.Drawing.Size(798, 420);
            this.Load += new System.EventHandler(this.PatientView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }        

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnEditPatient;  // 수정 버튼 추가
        private System.Windows.Forms.Button btnDeletePatient;  // 삭제 버튼 추가
    }
}
