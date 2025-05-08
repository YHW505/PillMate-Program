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
            ((System.ComponentModel.ISupportInitialize)(this.Bukyoung_Gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // Bukyoung_Gridview
            // 
            this.Bukyoung_Gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Bukyoung_Gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Bukyoung_Gridview.Location = new System.Drawing.Point(0, 0);
            this.Bukyoung_Gridview.Name = "Bukyoung_Gridview";
            this.Bukyoung_Gridview.RowTemplate.Height = 23;
            this.Bukyoung_Gridview.Size = new System.Drawing.Size(591, 324);
            this.Bukyoung_Gridview.AutoGenerateColumns = false;
            this.Bukyoung_Gridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Bukyoung_Gridview.ScrollBars = ScrollBars.Vertical;

            this.Bukyoung_Gridview.TabIndex = 0;
            // 
            // BukyoungView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Bukyoung_Gridview);
            this.Name = "BukyoungView";
            this.Size = new System.Drawing.Size(798, 420);
            this.Load += new System.EventHandler(this.Load_BukyoungStatus);
            ((System.ComponentModel.ISupportInitialize)(this.Bukyoung_Gridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Bukyoung_Gridview;
    }
}