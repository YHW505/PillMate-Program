namespace PillMate.View
{
    partial class PillView
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
            this.Pill_DataGreed = new System.Windows.Forms.DataGridView();
            this.Pill_Register_Button = new System.Windows.Forms.Button();
            this.Pill_Delete_Button = new System.Windows.Forms.Button();
            this.Pill_Modify_Button = new System.Windows.Forms.Button();
            this.YName_Label = new System.Windows.Forms.Label();
            this.YCNT_TextBox = new System.Windows.Forms.TextBox();
            this.YName_TextBox = new System.Windows.Forms.TextBox();
            this.YCnt_Label = new System.Windows.Forms.Label();
            this.YNUM_Label = new System.Windows.Forms.Label();
            this.YNum_TextBox = new System.Windows.Forms.TextBox();
            this.Pill_Reload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Pill_DataGreed)).BeginInit();
            this.SuspendLayout();
            // 
            // Pill_DataGreed
            // 
            this.Pill_DataGreed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Pill_DataGreed.Location = new System.Drawing.Point(0, 0);
            this.Pill_DataGreed.Name = "Pill_DataGreed";
            this.Pill_DataGreed.RowTemplate.Height = 23;
            this.Pill_DataGreed.Size = new System.Drawing.Size(591, 324);
            this.Pill_DataGreed.TabIndex = 0;
            // 
            // Pill_Register_Button
            // 
            this.Pill_Register_Button.Location = new System.Drawing.Point(599, 361);
            this.Pill_Register_Button.Name = "Pill_Register_Button";
            this.Pill_Register_Button.Size = new System.Drawing.Size(91, 56);
            this.Pill_Register_Button.TabIndex = 2;
            this.Pill_Register_Button.Text = "등록";
            this.Pill_Register_Button.UseVisualStyleBackColor = true;
            this.Pill_Register_Button.Click += new System.EventHandler(this.Pill_Register_Button_Click);
            // 
            // Pill_Delete_Button
            // 
            this.Pill_Delete_Button.Location = new System.Drawing.Point(696, 361);
            this.Pill_Delete_Button.Name = "Pill_Delete_Button";
            this.Pill_Delete_Button.Size = new System.Drawing.Size(99, 54);
            this.Pill_Delete_Button.TabIndex = 3;
            this.Pill_Delete_Button.Text = "삭제";
            this.Pill_Delete_Button.UseVisualStyleBackColor = true;
            this.Pill_Delete_Button.Click += new System.EventHandler(this.Pill_Delete_Button_Click);
            // 
            // Pill_Modify_Button
            // 
            this.Pill_Modify_Button.Location = new System.Drawing.Point(713, 33);
            this.Pill_Modify_Button.Name = "Pill_Modify_Button";
            this.Pill_Modify_Button.Size = new System.Drawing.Size(75, 23);
            this.Pill_Modify_Button.TabIndex = 10;
            this.Pill_Modify_Button.Text = "수정";
            this.Pill_Modify_Button.UseVisualStyleBackColor = true;
            this.Pill_Modify_Button.Click += new System.EventHandler(this.Pill_Modify_Button_Click);
            // 
            // YName_Label
            // 
            this.YName_Label.AutoSize = true;
            this.YName_Label.Location = new System.Drawing.Point(612, 156);
            this.YName_Label.Name = "YName_Label";
            this.YName_Label.Size = new System.Drawing.Size(41, 12);
            this.YName_Label.TabIndex = 5;
            this.YName_Label.Text = "약품명";
            // 
            // YCNT_TextBox
            // 
            this.YCNT_TextBox.Location = new System.Drawing.Point(614, 219);
            this.YCNT_TextBox.Name = "YCNT_TextBox";
            this.YCNT_TextBox.Size = new System.Drawing.Size(100, 21);
            this.YCNT_TextBox.TabIndex = 6;
            // 
            // YName_TextBox
            // 
            this.YName_TextBox.Location = new System.Drawing.Point(614, 171);
            this.YName_TextBox.Name = "YName_TextBox";
            this.YName_TextBox.Size = new System.Drawing.Size(100, 21);
            this.YName_TextBox.TabIndex = 4;
            // 
            // YCnt_Label
            // 
            this.YCnt_Label.AutoSize = true;
            this.YCnt_Label.Location = new System.Drawing.Point(615, 204);
            this.YCnt_Label.Name = "YCnt_Label";
            this.YCnt_Label.Size = new System.Drawing.Size(57, 12);
            this.YCnt_Label.TabIndex = 7;
            this.YCnt_Label.Text = "약품 개수";
            // 
            // YNUM_Label
            // 
            this.YNUM_Label.AutoSize = true;
            this.YNUM_Label.Location = new System.Drawing.Point(615, 254);
            this.YNUM_Label.Name = "YNUM_Label";
            this.YNUM_Label.Size = new System.Drawing.Size(85, 12);
            this.YNUM_Label.TabIndex = 8;
            this.YNUM_Label.Text = "알약 고유 번호";
            // 
            // YNum_TextBox
            // 
            this.YNum_TextBox.Location = new System.Drawing.Point(614, 269);
            this.YNum_TextBox.Name = "YNum_TextBox";
            this.YNum_TextBox.Size = new System.Drawing.Size(100, 21);
            this.YNum_TextBox.TabIndex = 9;
            // 
            // Pill_Reload
            // 
            this.Pill_Reload.Location = new System.Drawing.Point(713, 63);
            this.Pill_Reload.Name = "button1";
            this.Pill_Reload.Size = new System.Drawing.Size(75, 23);
            this.Pill_Reload.TabIndex = 11;
            this.Pill_Reload.Text = "새로고침";
            this.Pill_Reload.UseVisualStyleBackColor = true;
            this.Pill_Reload.Click += new System.EventHandler(this.PillForm_Load);
            // 
            // PillView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pill_Reload);
            this.Controls.Add(this.Pill_Modify_Button);
            this.Controls.Add(this.YNum_TextBox);
            this.Controls.Add(this.YNUM_Label);
            this.Controls.Add(this.YCnt_Label);
            this.Controls.Add(this.YCNT_TextBox);
            this.Controls.Add(this.YName_Label);
            this.Controls.Add(this.YName_TextBox);
            this.Controls.Add(this.Pill_Delete_Button);
            this.Controls.Add(this.Pill_Register_Button);
            this.Controls.Add(this.Pill_DataGreed);
            this.Name = "PillView";
            this.Text = "PillList";
            ((System.ComponentModel.ISupportInitialize)(this.Pill_DataGreed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label YName_Label;
        private System.Windows.Forms.TextBox YCNT_TextBox;
        private System.Windows.Forms.TextBox YName_TextBox;
        private System.Windows.Forms.Label YCnt_Label;
        private System.Windows.Forms.Label YNUM_Label;
        private System.Windows.Forms.TextBox YNum_TextBox;

        private System.Windows.Forms.DataGridView Pill_DataGreed;
        private System.Windows.Forms.Button Pill_Register_Button;
        private System.Windows.Forms.Button Pill_Delete_Button;
        private System.Windows.Forms.Button Pill_Modify_Button;
        private System.Windows.Forms.Button Pill_Reload;
    }
}