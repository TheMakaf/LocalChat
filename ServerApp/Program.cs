using System;
using System.Windows.Forms;

namespace ServerApp
{
    static class Program
    {
        internal static MainForm isForm { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            isForm = new MainForm();
            Application.Run(isForm);
        }
    }
}
