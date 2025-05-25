using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dental_sys
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Add(15);
            //guna2DataGridView1.Rows[0].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[0].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[0].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[0].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[0].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[0].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[0].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[1].Cells[1].Value = Image.FromFile("photos\\5.png");
            guna2DataGridView1.Rows[1].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[1].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[1].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[1].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[1].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[1].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[2].Cells[1].Value = Image.FromFile("photos\\3.png");
            guna2DataGridView1.Rows[2].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[2].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[2].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[2].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[2].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[2].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[3].Cells[1].Value = Image.FromFile("photos\\4.png");
            guna2DataGridView1.Rows[3].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[3].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[3].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[3].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[3].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[3].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[4].Cells[1].Value = Image.FromFile("photos\\5.png");
            guna2DataGridView1.Rows[4].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[4].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[4].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[4].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[4].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[4].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[5].Cells[1].Value = Image.FromFile("photos\\6.png");
            guna2DataGridView1.Rows[5].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[5].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[5].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[5].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[5].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[5].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[6].Cells[1].Value = Image.FromFile("photos\\5.png");
            guna2DataGridView1.Rows[6].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[6].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[6].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[6].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[6].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[6].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[7].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[7].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[7].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[7].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[7].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[7].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[7].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[8].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[9].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[9].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[9].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[9].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[9].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[9].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[8].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[10].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[10].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[10].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[10].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[10].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[10].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[8].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[11].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[11].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[11].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[11].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[11].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[11].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[8].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[12].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[12].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[12].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[12].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[12].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[12].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[8].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[13].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[13].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[13].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[13].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[13].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[13].Cells[7].Value = "Jan 21,2020";

            //guna2DataGridView1.Rows[8].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView1.Rows[14].Cells[2].Value = "Dian Cooper";
            guna2DataGridView1.Rows[14].Cells[3].Value = "(239)555-2020";
            guna2DataGridView1.Rows[14].Cells[4].Value = "Cilacap";
            guna2DataGridView1.Rows[14].Cells[5].Value = "Jan 21,2020 -13:30";
            guna2DataGridView1.Rows[14].Cells[6].Value = "Jan 21,2020";
            guna2DataGridView1.Rows[14].Cells[7].Value = "Jan 21,2020";
        }
    }
}
