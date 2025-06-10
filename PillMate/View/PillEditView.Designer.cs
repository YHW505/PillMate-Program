namespace PillMate.View
{
    partial class PillEditView
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_PillName = new System.Windows.Forms.Label();
            this.tBox_PillName = new System.Windows.Forms.TextBox();
            this.Label_PillCnt = new System.Windows.Forms.Label();
            this.tBox_PillCnt = new System.Windows.Forms.TextBox();
            this.Label_PillNum = new System.Windows.Forms.Label();
            this.tBox_PillNum = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_PillName
            // 
            this.Label_PillName.AutoSize = true;
            this.Label_PillName.Location = new System.Drawing.Point(64, 112);
            this.Label_PillName.Name = "Label_PillName";
            this.Label_PillName.Size = new System.Drawing.Size(41, 12);
            this.Label_PillName.TabIndex = 10;
            this.Label_PillName.Text = "약품명";
            // 
            // tBox_PillName
            // 
            this.tBox_PillName.Location = new System.Drawing.Point(164, 106);
            this.tBox_PillName.Name = "tBox_PillName";
            this.tBox_PillName.Size = new System.Drawing.Size(119, 21);
            this.tBox_PillName.TabIndex = 9;
            // 
            // Label_PillCnt
            // 
            this.Label_PillCnt.AutoSize = true;
            this.Label_PillCnt.Location = new System.Drawing.Point(64, 159);
            this.Label_PillCnt.Name = "Label_PillCnt";
            this.Label_PillCnt.Size = new System.Drawing.Size(29, 12);
            this.Label_PillCnt.TabIndex = 12;
            this.Label_PillCnt.Text = "개수";
            // 
            // tBox_PillCnt
            // 
            this.tBox_PillCnt.Location = new System.Drawing.Point(164, 153);
            this.tBox_PillCnt.Name = "tBox_PillCnt";
            this.tBox_PillCnt.Size = new System.Drawing.Size(119, 21);
            this.tBox_PillCnt.TabIndex = 11;
            // 
            // Label_PillNum
            // 
            this.Label_PillNum.AutoSize = true;
            this.Label_PillNum.Location = new System.Drawing.Point(64, 206);
            this.Label_PillNum.Name = "Label_PillNum";
            this.Label_PillNum.Size = new System.Drawing.Size(53, 12);
            this.Label_PillNum.TabIndex = 14;
            this.Label_PillNum.Text = "약품번호";
            // 
            // tBox_PillNum
            // 
            this.tBox_PillNum.Location = new System.Drawing.Point(164, 200);
            this.tBox_PillNum.Name = "tBox_PillNum";
            this.tBox_PillNum.Size = new System.Drawing.Size(119, 21);
            this.tBox_PillNum.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(125, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 24);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PillEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 330);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Label_PillNum);
            this.Controls.Add(this.tBox_PillNum);
            this.Controls.Add(this.Label_PillCnt);
            this.Controls.Add(this.tBox_PillCnt);
            this.Controls.Add(this.Label_PillName);
            this.Controls.Add(this.tBox_PillName);
            this.Name = "PillEditView";
            this.Text = "약품 정보 수정";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += new System.EventHandler(this.PillEditView_Load);

        }

        #endregion

        private System.Windows.Forms.Label Label_PillName;
        private System.Windows.Forms.TextBox tBox_PillName;
        private System.Windows.Forms.Label Label_PillCnt;
        private System.Windows.Forms.TextBox tBox_PillCnt;
        private System.Windows.Forms.Label Label_PillNum;
        private System.Windows.Forms.TextBox tBox_PillNum;
        private System.Windows.Forms.Button btnSave;
    }
}