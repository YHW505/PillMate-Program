using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Media;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http;
using Guna.UI2.WinForms;
using PillMate.ApiClients;
using PillMate.Client.ApiClients;
using PillMate.DTO;
using PillMate.View.Widget;


namespace PillMate.View
{
    public partial class HomeView : Form
    {
        private readonly PatientApi _api;
        private readonly TakenMedicineAPI _Tapi;
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
