using System.Windows.Forms;

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
            this.bohoja_name_label = new System.Windows.Forms.Label();
            this.bohoja_pn_label = new System.Windows.Forms.Label();
            this.hwanja_room_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Bukyoung_list = new System.Windows.Forms.ListView();
            this.TakenMedicine_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TakenmMedicine_dosage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Add_TakenMedicine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QR_Image_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(844, 486);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += dataGridView1_CellClick;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ScrollBars = ScrollBars.Vertical;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(4, 489);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(242, 18);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "환자 데이터를 불러오는 중...";
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Font = new System.Drawing.Font("굴림", 9F);
            this.btnAddPatient.Location = new System.Drawing.Point(853, 4);
            this.btnAddPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(131, 58);
            this.btnAddPatient.TabIndex = 2;
            this.btnAddPatient.Text = "환자 등록";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Font = new System.Drawing.Font("굴림", 9F);
            this.btnEditPatient.Location = new System.Drawing.Point(853, 69);
            this.btnEditPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(131, 58);
            this.btnEditPatient.TabIndex = 3;
            this.btnEditPatient.Text = "환자 수정";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            this.btnEditPatient.Click += new System.EventHandler(this.btnEditPatient_Click);
            // 
            // btnDeletePatient
            // 
            this.btnDeletePatient.Font = new System.Drawing.Font("굴림", 9F);
            this.btnDeletePatient.Location = new System.Drawing.Point(853, 134);
            this.btnDeletePatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeletePatient.Name = "btnDeletePatient";
            this.btnDeletePatient.Size = new System.Drawing.Size(131, 58);
            this.btnDeletePatient.TabIndex = 4;
            this.btnDeletePatient.Text = "환자 삭제";
            this.btnDeletePatient.UseVisualStyleBackColor = true;
            this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click);
            // 
            // QR_Image_Box
            // 
            this.QR_Image_Box.Location = new System.Drawing.Point(856, 508);
            this.QR_Image_Box.Margin = new System.Windows.Forms.Padding(4);
            this.QR_Image_Box.Name = "QR_Image_Box";
            this.QR_Image_Box.Size = new System.Drawing.Size(238, 206);
            this.QR_Image_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QR_Image_Box.TabIndex = 5;
            this.QR_Image_Box.TabStop = false;
            // 
            // Print_QR
            // 
            this.Print_QR.Font = new System.Drawing.Font("굴림", 9F);
            this.Print_QR.Location = new System.Drawing.Point(987, 722);
            this.Print_QR.Margin = new System.Windows.Forms.Padding(4);
            this.Print_QR.Name = "Print_QR";
            this.Print_QR.Size = new System.Drawing.Size(107, 34);
            this.Print_QR.TabIndex = 7;
            this.Print_QR.Text = "QR 인쇄";
            this.Print_QR.UseVisualStyleBackColor = true;
            this.Print_QR.Visible = false;
            this.Print_QR.Click += new System.EventHandler(this.Print_QR_Click);
            // 
            // bohoja_name_label
            // 
            this.bohoja_name_label.AutoSize = true;
            this.bohoja_name_label.Location = new System.Drawing.Point(853, 458);
            this.bohoja_name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bohoja_name_label.Name = "bohoja_name_label";
            this.bohoja_name_label.Size = new System.Drawing.Size(110, 18);
            this.bohoja_name_label.TabIndex = 11;
            this.bohoja_name_label.Text = "보호자 이름:";
            // 
            // bohoja_pn_label
            // 
            this.bohoja_pn_label.AutoSize = true;
            this.bohoja_pn_label.Location = new System.Drawing.Point(853, 432);
            this.bohoja_pn_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bohoja_pn_label.Name = "bohoja_pn_label";
            this.bohoja_pn_label.Size = new System.Drawing.Size(146, 18);
            this.bohoja_pn_label.TabIndex = 12;
            this.bohoja_pn_label.Text = "보호자 전화번호:";
            // 
            // hwanja_room_label
            // 
            this.hwanja_room_label.AutoSize = true;
            this.hwanja_room_label.Location = new System.Drawing.Point(853, 410);
            this.hwanja_room_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hwanja_room_label.Name = "hwanja_room_label";
            this.hwanja_room_label.Size = new System.Drawing.Size(50, 18);
            this.hwanja_room_label.TabIndex = 14;
            this.hwanja_room_label.Text = "병실:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(852, 375);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "상세정보";
            // 
            // Bukyoung_list
            // 
            this.Bukyoung_list.GridLines = true;
            this.Bukyoung_list.HideSelection = false;
            this.Bukyoung_list.Location = new System.Drawing.Point(439, 520);
            this.Bukyoung_list.Margin = new System.Windows.Forms.Padding(4);
            this.Bukyoung_list.Name = "Bukyoung_list";
            this.Bukyoung_list.Size = new System.Drawing.Size(404, 236);
            this.Bukyoung_list.TabIndex = 17;
            this.Bukyoung_list.UseCompatibleStateImageBehavior = false;
            this.Bukyoung_list.View = System.Windows.Forms.View.Details;
            this.Bukyoung_list.Visible = false;
            // 
            // Add_TakenMedicine
            // 
            this.Add_TakenMedicine.Font = new System.Drawing.Font("굴림", 9F);
            this.Add_TakenMedicine.Location = new System.Drawing.Point(856, 724);
            this.Add_TakenMedicine.Name = "Add_TakenMedicine";
            this.Add_TakenMedicine.Size = new System.Drawing.Size(107, 34);
            this.Add_TakenMedicine.TabIndex = 18;
            this.Add_TakenMedicine.Text = "복약 등록";
            this.Add_TakenMedicine.UseVisualStyleBackColor = true;
            this.Add_TakenMedicine.Visible = false;
            this.Add_TakenMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);

            // 
            // PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Add_TakenMedicine);
            this.Controls.Add(this.Bukyoung_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hwanja_room_label);
            this.Controls.Add(this.bohoja_pn_label);
            this.Controls.Add(this.bohoja_name_label);
            this.Controls.Add(this.Print_QR);
            this.Controls.Add(this.QR_Image_Box);
            this.Controls.Add(this.btnDeletePatient);
            this.Controls.Add(this.btnEditPatient);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PatientView";
            this.Size = new System.Drawing.Size(1140, 789);
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
        private System.Windows.Forms.Label bohoja_name_label;
        private System.Windows.Forms.Label bohoja_pn_label;
        private System.Windows.Forms.Label hwanja_room_label;
        private System.Windows.Forms.Label label1;
        private ColumnHeader TakenMedicine_name;
        private ColumnHeader TakenmMedicine_dosage;
        private ListView Bukyoung_list;
        private Button Add_TakenMedicine;
    }
}
