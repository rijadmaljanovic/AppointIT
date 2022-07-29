using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointIT.WinUI.SalonForms;
using AppointIT.WinUI.EmployeeForms;
using AppointIT.WinUI.ServiceForms;
using AppointIT.WinUI.TermForms;
using AppointIT.WinUI.NewsForms;
using AppointIT.WinUI.Report;

namespace AppointIT.WinUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
