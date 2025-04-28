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
            this.btnEditPatient = new System.Windows.Forms.Button();
            this.btnDeletePatient = new System.Windows.Forms.Button();
            this.QR_Image_Box = new System.Windows.Forms.PictureBox();
            this.Print_QR = new System.Windows.Forms.Button();
            this.bokyoung_imform = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QR_Image_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(591, 324);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(3, 326);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(161, 12);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "환자 데이터를 불러오는 중...";
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Font = new System.Drawing.Font("Gulim", 12F);
            this.btnAddPatient.Location = new System.Drawing.Point(597, 3);
            this.btnAddPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(168, 75);
            this.btnAddPatient.TabIndex = 2;
            this.btnAddPatient.Text = "환자 등록";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Font = new System.Drawing.Font("Gulim", 12F);
            this.btnEditPatient.Location = new System.Drawing.Point(597, 82);
            this.btnEditPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(168, 75);
            this.btnEditPatient.TabIndex = 3;
            this.btnEditPatient.Text = "환자 수정";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            this.btnEditPatient.Click += new System.EventHandler(this.btnEditPatient_Click);
            // 
            // btnDeletePatient
            // 
            this.btnDeletePatient.Font = new System.Drawing.Font("Gulim", 12F);
            this.btnDeletePatient.Location = new System.Drawing.Point(597, 161);
            this.btnDeletePatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletePatient.Name = "btnDeletePatient";
            this.btnDeletePatient.Size = new System.Drawing.Size(168, 75);
            this.btnDeletePatient.TabIndex = 4;
            this.btnDeletePatient.Text = "환자 삭제";
            this.btnDeletePatient.UseVisualStyleBackColor = true;
            this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click);
            // 
            // QR_Image_Box
            // 
            this.QR_Image_Box.Location = new System.Drawing.Point(598, 242);
            this.QR_Image_Box.Name = "QR_Image_Box";
            this.QR_Image_Box.Size = new System.Drawing.Size(167, 154);
            this.QR_Image_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QR_Image_Box.TabIndex = 5;
            this.QR_Image_Box.TabStop = false;
            // 
            // Print_QR
            // 
            this.Print_QR.Location = new System.Drawing.Point(517, 373);
            this.Print_QR.Name = "Print_QR";
            this.Print_QR.Size = new System.Drawing.Size(75, 23);
            this.Print_QR.TabIndex = 7;
            this.Print_QR.Text = "QR 인쇄";
            this.Print_QR.UseVisualStyleBackColor = true;
            this.Print_QR.Visible = false;
            this.Print_QR.Click += new System.EventHandler(this.Print_QR_Click);
            // 
            // bokyoung_imform
            // 
            this.bokyoung_imform.Location = new System.Drawing.Point(498, 344);
            this.bokyoung_imform.Name = "bokyoung_imform";
            this.bokyoung_imform.Size = new System.Drawing.Size(93, 23);
            this.bokyoung_imform.TabIndex = 8;
            this.bokyoung_imform.Text = "복약 정보 확인";
            this.bokyoung_imform.UseVisualStyleBackColor = true;
            this.bokyoung_imform.Visible = false;
            // 
            // PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.bokyoung_imform);
            this.Controls.Add(this.Print_QR);
            this.Controls.Add(this.QR_Image_Box);
            this.Controls.Add(this.btnDeletePatient);
            this.Controls.Add(this.btnEditPatient);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PatientView";
            this.Size = new System.Drawing.Size(798, 420);
            this.Load += new System.EventHandler(this.PatientView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QR_Image_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnEditPatient;  // 수정 버튼 추가
        private System.Windows.Forms.Button btnDeletePatient;  // 삭제 버튼 추가
        private System.Windows.Forms.PictureBox QR_Image_Box;
        private System.Windows.Forms.Button Print_QR;
        private System.Windows.Forms.Button bokyoung_imform;
    }
}
