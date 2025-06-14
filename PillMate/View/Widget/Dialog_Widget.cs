using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillMate.View.Widget
{

    public partial class Dialog_Widget : Form
    {

        private String title;
        private String msg;
        

        //, Func<Task> do_OK, Func<Task> do_Cancel
        public Dialog_Widget(String dialog_title, String dialog_msg)
        {
            InitializeComponent();
            title = dialog_title;
            msg = dialog_msg;
            
        }

        private async void Dialog_Load(object sender, EventArgs e)
        {
            
            Label_Dialog.Text = title.ToString();
            Msg_Dialog.Text = msg.ToString();
        }

        private async void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
