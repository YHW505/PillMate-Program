using System.Windows.Forms;

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
            this.pillLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pill_DataGreed)).BeginInit();
            this.SuspendLayout();
            // 
            // Pill_DataGreed
            // 
            this.Pill_DataGreed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Pill_DataGreed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Pill_DataGreed.Location = new System.Drawing.Point(0, 0);
            this.Pill_DataGreed.Name = "Pill_DataGreed";
            this.Pill_DataGreed.RowHeadersWidth = 62;
            this.Pill_DataGreed.RowTemplate.Height = 23;
            this.Pill_DataGreed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Pill_DataGreed.Size = new System.Drawing.Size(591, 324);
            this.Pill_DataGreed.TabIndex = 0;
            this.Pill_DataGreed.AutoGenerateColumns = false;
            this.Pill_DataGreed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Pill_DataGreed.ScrollBars = ScrollBars.Vertical;

            // 
            // Pill_Register_Button
            // 
            this.Pill_Register_Button.Font = new System.Drawing.Font("Gulim", 9F);
            this.Pill_Register_Button.Location = new System.Drawing.Point(597, 12);
            this.Pill_Register_Button.Name = "Pill_Register_Button";
            this.Pill_Register_Button.Size = new System.Drawing.Size(92, 39);
            this.Pill_Register_Button.TabIndex = 2;
            this.Pill_Register_Button.Text = "등록";
            this.Pill_Register_Button.UseVisualStyleBackColor = true;
            this.Pill_Register_Button.Click += new System.EventHandler(this.Pill_Register_Button_Click);
            // 
            // Pill_Delete_Button
            // 
            this.Pill_Delete_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Pill_Delete_Button.Font = new System.Drawing.Font("Gulim", 9F);
            this.Pill_Delete_Button.Location = new System.Drawing.Point(597, 57);
            this.Pill_Delete_Button.Name = "Pill_Delete_Button";
            this.Pill_Delete_Button.Size = new System.Drawing.Size(92, 39);
            this.Pill_Delete_Button.TabIndex = 3;
            this.Pill_Delete_Button.Text = "삭제";
            this.Pill_Delete_Button.UseVisualStyleBackColor = true;
            this.Pill_Delete_Button.Click += new System.EventHandler(this.Pill_Delete_Button_Click);
            // 
            // pillLabel
            // 
            this.pillLabel.AutoSize = true;
            this.pillLabel.Location = new System.Drawing.Point(3, 327);
            this.pillLabel.Name = "pillLabel";
            this.pillLabel.Size = new System.Drawing.Size(161, 12);
            this.pillLabel.TabIndex = 10;
            this.pillLabel.Text = "알약 데이터를 불러오는 중...";
            // 
            // PillView
            // 
            this.AutoSize = true;
            this.Controls.Add(this.pillLabel);
            this.Controls.Add(this.Pill_Delete_Button);
            this.Controls.Add(this.Pill_Register_Button);
            this.Controls.Add(this.Pill_DataGreed);
            this.Name = "PillView";
            this.Size = new System.Drawing.Size(798, 420);
            ((System.ComponentModel.ISupportInitialize)(this.Pill_DataGreed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Pill_DataGreed;
        private System.Windows.Forms.Button Pill_Register_Button;
        private System.Windows.Forms.Button Pill_Delete_Button;
        private Label pillLabel;
    }
}