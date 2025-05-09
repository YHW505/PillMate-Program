using System.Windows.Forms;

namespace PillMate.View
{
    partial class BukyoungView
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
            this.Bukyoung_Gridview = new System.Windows.Forms.DataGridView();
            this.Loading_Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Bukyoung_Gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // Bukyoung_Gridview
            // 
            this.Bukyoung_Gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Bukyoung_Gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Bukyoung_Gridview.Location = new System.Drawing.Point(0, 0);
            this.Bukyoung_Gridview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bukyoung_Gridview.Name = "Bukyoung_Gridview";
            this.Bukyoung_Gridview.RowTemplate.Height = 23;
            this.Bukyoung_Gridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Bukyoung_Gridview.Size = new System.Drawing.Size(844, 486);
            this.Bukyoung_Gridview.TabIndex = 0;
            // 
            // Loading_Status
            // 
            this.Loading_Status.AutoSize = true;
            this.Loading_Status.Location = new System.Drawing.Point(4, 494);
            this.Loading_Status.Name = "Loading_Status";
            this.Loading_Status.Size = new System.Drawing.Size(80, 18);
            this.Loading_Status.TabIndex = 1;
            this.Loading_Status.Text = "로딩중...";
            // 
            // BukyoungView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Loading_Status);
            this.Controls.Add(this.Bukyoung_Gridview);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BukyoungView";
            this.Size = new System.Drawing.Size(1140, 630);
            this.Load += new System.EventHandler(this.Load_BukyoungStatus);
            ((System.ComponentModel.ISupportInitialize)(this.Bukyoung_Gridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Bukyoung_Gridview;
        private Label Loading_Status;
    }
}