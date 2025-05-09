namespace PillMate.View
{
    partial class TakenMedicineResisterView
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
            this.btnResister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResister
            // 
            this.btnResister.Location = new System.Drawing.Point(128, 383);
            this.btnResister.Name = "btnResister";
            this.btnResister.Size = new System.Drawing.Size(66, 19);
            this.btnResister.TabIndex = 16;
            this.btnResister.Text = "등록";
            this.btnResister.UseVisualStyleBackColor = true;
            this.btnResister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // TakenMedicineResisterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 410);
            this.Controls.Add(this.btnResister);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TakenMedicineResisterView";
            this.Text = "복약 등록";
            this.Load += new System.EventHandler(this.ChkPill_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnResister;
    }
}