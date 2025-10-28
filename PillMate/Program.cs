using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.Services;
using PillMate.View;

namespace PillMate
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serverService = new PillMate.Services.ServerService();

            serverService.StartServer();

            Application.ApplicationExit += (s, e) =>
            {
                serverService.StopServer();
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            
      }
    }
}
