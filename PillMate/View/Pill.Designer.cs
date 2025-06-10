using Guna.UI2.WinForms;

namespace PillMate.View
{
    partial class Pill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pillcnt = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.Createbtn = new Guna.UI2.WinForms.Guna2Button();
            this.Pill_DataGreed = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Deletebtn = new Guna.UI2.WinForms.Guna2Button();
            this.Editbtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pill_DataGreed)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2ComboBox1);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.pillcnt);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1337, 70);
            this.guna2Panel1.TabIndex = 10;
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            "Last appointment"});
            this.guna2ComboBox1.Location = new System.Drawing.Point(353, 16);
            this.guna2ComboBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(207, 36);
            this.guna2ComboBox1.StartIndex = 0;
            this.guna2ComboBox1.TabIndex = 3;
            this.guna2ComboBox1.TextOffset = new System.Drawing.Point(2, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label3.Location = new System.Drawing.Point(247, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sort by:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label2.Location = new System.Drawing.Point(81, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pills";
            // 
            // pillcnt
            // 
            this.pillcnt.AutoSize = true;
            this.pillcnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.pillcnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pillcnt.Location = new System.Drawing.Point(33, 12);
            this.pillcnt.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pillcnt.Name = "pillcnt";
            this.pillcnt.Size = new System.Drawing.Size(40, 42);
            this.pillcnt.TabIndex = 0;
            this.pillcnt.Text = "0";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.Createbtn);
            this.guna2Panel2.Controls.Add(this.Pill_DataGreed);
            this.guna2Panel2.Controls.Add(this.Deletebtn);
            this.guna2Panel2.Controls.Add(this.Editbtn);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 70);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1337, 739);
            this.guna2Panel2.TabIndex = 11;
            // 
            // Createbtn
            // 
            this.Createbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Createbtn.BorderRadius = 5;
            this.Createbtn.BorderThickness = 1;
            this.Createbtn.FillColor = System.Drawing.Color.Transparent;
            this.Createbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Createbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Createbtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Createbtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.Createbtn.Location = new System.Drawing.Point(903, 672);
            this.Createbtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Createbtn.Name = "Createbtn";
            this.Createbtn.Size = new System.Drawing.Size(112, 35);
            this.Createbtn.TabIndex = 13;
            this.Createbtn.Text = "Create";
            this.Createbtn.Click += new System.EventHandler(this.Createbtn_Click_1);
            // 
            // Pill_DataGreed
            // 
            this.Pill_DataGreed.AllowUserToAddRows = false;
            this.Pill_DataGreed.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.Pill_DataGreed.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Pill_DataGreed.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Pill_DataGreed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Pill_DataGreed.ColumnHeadersHeight = 50;
            this.Pill_DataGreed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Pill_DataGreed.DefaultCellStyle = dataGridViewCellStyle7;
            this.Pill_DataGreed.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Pill_DataGreed.Location = new System.Drawing.Point(11, 30);
            this.Pill_DataGreed.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Pill_DataGreed.Name = "Pill_DataGreed";
            this.Pill_DataGreed.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Pill_DataGreed.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Pill_DataGreed.RowHeadersVisible = false;
            this.Pill_DataGreed.RowHeadersWidth = 51;
            this.Pill_DataGreed.RowTemplate.DividerHeight = 5;
            this.Pill_DataGreed.RowTemplate.Height = 50;
            this.Pill_DataGreed.Size = new System.Drawing.Size(1309, 623);
            this.Pill_DataGreed.TabIndex = 12;
            this.Pill_DataGreed.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Pill_DataGreed.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Pill_DataGreed.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Pill_DataGreed.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Pill_DataGreed.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Pill_DataGreed.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Pill_DataGreed.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Pill_DataGreed.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Pill_DataGreed.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Pill_DataGreed.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Pill_DataGreed.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Pill_DataGreed.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Pill_DataGreed.ThemeStyle.HeaderStyle.Height = 50;
            this.Pill_DataGreed.ThemeStyle.ReadOnly = true;
            this.Pill_DataGreed.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Pill_DataGreed.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Pill_DataGreed.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Pill_DataGreed.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Pill_DataGreed.ThemeStyle.RowsStyle.Height = 50;
            this.Pill_DataGreed.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Pill_DataGreed.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Deletebtn
            // 
            this.Deletebtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Deletebtn.BorderRadius = 5;
            this.Deletebtn.BorderThickness = 1;
            this.Deletebtn.FillColor = System.Drawing.Color.Transparent;
            this.Deletebtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Deletebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Deletebtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Deletebtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.Deletebtn.Location = new System.Drawing.Point(1025, 672);
            this.Deletebtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(112, 35);
            this.Deletebtn.TabIndex = 11;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click_1);
            // 
            // Editbtn
            // 
            this.Editbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Editbtn.BorderRadius = 5;
            this.Editbtn.BorderThickness = 1;
            this.Editbtn.FillColor = System.Drawing.Color.Transparent;
            this.Editbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Editbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Editbtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Editbtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.Editbtn.Location = new System.Drawing.Point(1147, 672);
            this.Editbtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Size = new System.Drawing.Size(112, 35);
            this.Editbtn.TabIndex = 10;
            this.Editbtn.Text = "Edit";
            // 
            // Pill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1337, 809);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pill";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pill_DataGreed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna2Panel guna2Panel1;
        private Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pillcnt;
        private Guna2Panel guna2Panel2;
        private Guna2Button Createbtn;
        private Guna2DataGridView Pill_DataGreed;
        private Guna2Button Deletebtn;
        private Guna2Button Editbtn;
    }
}