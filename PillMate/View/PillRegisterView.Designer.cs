namespace PillMate.View
{
    partial class PillRegisterView
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
            this.YName_Label = new System.Windows.Forms.Label();
            this.YName_TextBox = new System.Windows.Forms.TextBox();
            this.YCnt_Label = new System.Windows.Forms.Label();
            this.YCNT_TextBox = new System.Windows.Forms.TextBox();
            this.YNUM_Label = new System.Windows.Forms.Label();
            this.YNum_TextBox = new System.Windows.Forms.TextBox();
            this.Pill_Save_Button = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // YName_Label
            // 
            this.YName_Label.AutoSize = true;
            this.YName_Label.Location = new System.Drawing.Point(55, 84);
            this.YName_Label.Name = "YName_Label";
            this.YName_Label.Size = new System.Drawing.Size(41, 12);
            this.YName_Label.TabIndex = 0;
            this.YName_Label.Text = "약품명";
            // 
            // YName_TextBox
            // 
            this.YName_TextBox.Location = new System.Drawing.Point(136, 81);
            this.YName_TextBox.Name = "YName_TextBox";
            this.YName_TextBox.Size = new System.Drawing.Size(100, 21);
            this.YName_TextBox.TabIndex = 1;
            // 
            // YCnt_Label
            // 
            this.YCnt_Label.AutoSize = true;
            this.YCnt_Label.Location = new System.Drawing.Point(55, 146);
            this.YCnt_Label.Name = "YCnt_Label";
            this.YCnt_Label.Size = new System.Drawing.Size(53, 12);
            this.YCnt_Label.TabIndex = 2;
            this.YCnt_Label.Text = "약품개수";
            // 
            // YCNT_TextBox
            // 
            this.YCNT_TextBox.Location = new System.Drawing.Point(136, 143);
            this.YCNT_TextBox.Name = "YCNT_TextBox";
            this.YCNT_TextBox.Size = new System.Drawing.Size(100, 21);
            this.YCNT_TextBox.TabIndex = 3;
            // 
            // YNUM_Label
            // 
            this.YNUM_Label.AutoSize = true;
            this.YNUM_Label.Location = new System.Drawing.Point(55, 208);
            this.YNUM_Label.Name = "YNUM_Label";
            this.YNUM_Label.Size = new System.Drawing.Size(53, 12);
            this.YNUM_Label.TabIndex = 4;
            this.YNUM_Label.Text = "알약번호";
            // 
            // YNum_TextBox
            // 
            this.YNum_TextBox.Location = new System.Drawing.Point(136, 205);
            this.YNum_TextBox.Name = "YNum_TextBox";
            this.YNum_TextBox.Size = new System.Drawing.Size(100, 21);
            this.YNum_TextBox.TabIndex = 5;
            // 
            // Pill_Save_Button
            // 
            this.Pill_Save_Button.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Pill_Save_Button.BorderRadius = 5;
            this.Pill_Save_Button.BorderThickness = 1;
            this.Pill_Save_Button.FillColor = System.Drawing.Color.Transparent;
            this.Pill_Save_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Pill_Save_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Pill_Save_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Pill_Save_Button.HoverState.ForeColor = System.Drawing.Color.White;
            this.Pill_Save_Button.Location = new System.Drawing.Point(117, 315); this.Pill_Save_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Pill_Save_Button.Name = "Pill_Save_Button";
            this.Pill_Save_Button.Size = new System.Drawing.Size(98, 28);
            this.Pill_Save_Button.TabIndex = 9;
            this.Pill_Save_Button.Text = "Add 저장";
            this.Pill_Save_Button.Click += new System.EventHandler(this.Pill_Save_Button_Click);
            // 
            // PillRegisterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 360);
            this.Controls.Add(this.Pill_Save_Button);
            this.Controls.Add(this.YNum_TextBox);
            this.Controls.Add(this.YNUM_Label);
            this.Controls.Add(this.YCNT_TextBox);
            this.Controls.Add(this.YCnt_Label);
            this.Controls.Add(this.YName_TextBox);
            this.Controls.Add(this.YName_Label);
            this.Name = "PillRegisterView";
            this.Text = "약품 등록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label YName_Label;
        private System.Windows.Forms.TextBox YName_TextBox;
        private System.Windows.Forms.Label YCnt_Label;
        private System.Windows.Forms.TextBox YCNT_TextBox;
        private System.Windows.Forms.Label YNUM_Label;
        private System.Windows.Forms.TextBox YNum_TextBox;
        private Guna.UI2.WinForms.Guna2Button Pill_Save_Button;
    }
}