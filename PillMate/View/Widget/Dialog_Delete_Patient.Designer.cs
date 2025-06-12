namespace PillMate.View.Widget
{
    partial class Dialog_Delete_Patient
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel_top = new Guna.UI2.WinForms.Guna2Panel();
            this.Label_Dialog = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel_container = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_Cancel = new Guna.UI2.WinForms.Guna2Button();
            this.Msg_Dialog = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_OK = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel_top.SuspendLayout();
            this.guna2Panel_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel_top
            // 
            this.guna2Panel_top.Controls.Add(this.Label_Dialog);
            this.guna2Panel_top.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel_top.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel_top.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel_top.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel_top.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2Panel_top.Name = "guna2Panel_top";
            this.guna2Panel_top.Size = new System.Drawing.Size(300, 30);
            this.guna2Panel_top.TabIndex = 1;
            // 
            // Label_Dialog
            // 
            this.Label_Dialog.AutoSize = true;
            this.Label_Dialog.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F);
            this.Label_Dialog.Location = new System.Drawing.Point(9, 7);
            this.Label_Dialog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Dialog.Name = "Label_Dialog";
            this.Label_Dialog.Size = new System.Drawing.Size(58, 16);
            this.Label_Dialog.TabIndex = 5;
            this.Label_Dialog.Text = "환자 삭제";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(273, 0);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(27, 27);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel_top;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Panel_container
            // 
            this.guna2Panel_container.Controls.Add(this.btn_Cancel);
            this.guna2Panel_container.Controls.Add(this.Msg_Dialog);
            this.guna2Panel_container.Controls.Add(this.btn_OK);
            this.guna2Panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel_container.Location = new System.Drawing.Point(0, 30);
            this.guna2Panel_container.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2Panel_container.Name = "guna2Panel_container";
            this.guna2Panel_container.Size = new System.Drawing.Size(300, 170);
            this.guna2Panel_container.TabIndex = 2;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Cancel.BorderRadius = 5;
            this.btn_Cancel.BorderThickness = 1;
            this.btn_Cancel.FillColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Cancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Cancel.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(163, 111);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(98, 28);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Msg_Dialog
            // 
            this.Msg_Dialog.BackColor = System.Drawing.Color.Transparent;
            this.Msg_Dialog.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F);
            this.Msg_Dialog.Location = new System.Drawing.Point(37, 58);
            this.Msg_Dialog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Msg_Dialog.Name = "Msg_Dialog";
            this.Msg_Dialog.Size = new System.Drawing.Size(233, 22);
            this.Msg_Dialog.TabIndex = 5;
            this.Msg_Dialog.Text = "정말 이 환자를 삭제하시겠습니까?";
            // 
            // btn_OK
            // 
            this.btn_OK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_OK.BorderRadius = 5;
            this.btn_OK.BorderThickness = 1;
            this.btn_OK.FillColor = System.Drawing.Color.Transparent;
            this.btn_OK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_OK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_OK.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_OK.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(42, 111);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(98, 28);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "확인";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // Dialog_Delete_Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.guna2Panel_container);
            this.Controls.Add(this.guna2Panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Dialog_Delete_Patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog_Widget_Choice";
            this.guna2Panel_top.ResumeLayout(false);
            this.guna2Panel_top.PerformLayout();
            this.guna2Panel_container.ResumeLayout(false);
            this.guna2Panel_container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel_top;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel_container;
        private System.Windows.Forms.Label Label_Dialog;
        private Guna.UI2.WinForms.Guna2Button btn_OK;
        private Guna.UI2.WinForms.Guna2HtmlLabel Msg_Dialog;
        private Guna.UI2.WinForms.Guna2Button btn_Cancel;
    }
}