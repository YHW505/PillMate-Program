﻿namespace PillMate
{
    partial class MainView
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
            this.Main_Pannel = new System.Windows.Forms.Panel();
            this.Home_Button = new System.Windows.Forms.Button();
            this.Patient_Button = new System.Windows.Forms.Button();
            this.Pill_Button = new System.Windows.Forms.Button();
            this.Get_Pill_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Main_Pannel
            // 
            this.Main_Pannel.AutoSize = true;
            this.Main_Pannel.BackColor = System.Drawing.SystemColors.Control;
            this.Main_Pannel.Location = new System.Drawing.Point(283, 62);
            this.Main_Pannel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Main_Pannel.Name = "Main_Pannel";
            this.Main_Pannel.Size = new System.Drawing.Size(855, 481);
            this.Main_Pannel.TabIndex = 0;
            // 
            // Home_Button
            // 
            this.Home_Button.Location = new System.Drawing.Point(57, 62);
            this.Home_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Home_Button.Name = "Home_Button";
            this.Home_Button.Size = new System.Drawing.Size(182, 105);
            this.Home_Button.TabIndex = 1;
            this.Home_Button.Text = "메인 홈";
            this.Home_Button.UseVisualStyleBackColor = true;
            this.Home_Button.Click += new System.EventHandler(this.Home_Button_Click);
            // 
            // Patient_Button
            // 
            this.Patient_Button.Location = new System.Drawing.Point(57, 188);
            this.Patient_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Patient_Button.Name = "Patient_Button";
            this.Patient_Button.Size = new System.Drawing.Size(182, 105);
            this.Patient_Button.TabIndex = 2;
            this.Patient_Button.Text = "환자 관리";
            this.Patient_Button.UseVisualStyleBackColor = true;
            this.Patient_Button.Click += new System.EventHandler(this.Patient_Button_Click);
            // 
            // Pill_Button
            // 
            this.Pill_Button.Location = new System.Drawing.Point(57, 312);
            this.Pill_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pill_Button.Name = "Pill_Button";
            this.Pill_Button.Size = new System.Drawing.Size(182, 105);
            this.Pill_Button.TabIndex = 3;
            this.Pill_Button.Text = "약품 관리";
            this.Pill_Button.UseVisualStyleBackColor = true;
            this.Pill_Button.Click += new System.EventHandler(this.Pill_Button_Click);
            // 
            // Get_Pill_Button
            // 
            this.Get_Pill_Button.Location = new System.Drawing.Point(57, 438);
            this.Get_Pill_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Get_Pill_Button.Name = "Get_Pill_Button";
            this.Get_Pill_Button.Size = new System.Drawing.Size(182, 105);
            this.Get_Pill_Button.TabIndex = 4;
            this.Get_Pill_Button.Text = "약 수령 현황";
            this.Get_Pill_Button.UseVisualStyleBackColor = true;
            this.Get_Pill_Button.Click += new System.EventHandler(this.Get_Pill_Button_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 632);
            this.Controls.Add(this.Get_Pill_Button);
            this.Controls.Add(this.Pill_Button);
            this.Controls.Add(this.Patient_Button);
            this.Controls.Add(this.Home_Button);
            this.Controls.Add(this.Main_Pannel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainView";
            this.Text = "PillMate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MySql.Data.MySqlClient.MySqlConnection mySqlConnection1;
        private System.Windows.Forms.Panel Main_Pannel;
        private System.Windows.Forms.Button Home_Button;
        private System.Windows.Forms.Button Patient_Button;
        private System.Windows.Forms.Button Pill_Button;
        private System.Windows.Forms.Button Get_Pill_Button;
    }
}

