using System;
using System.Windows.Forms;

namespace OwlTechScheduler.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Schedulers.CpuScheduler()); // This launches your custom UI
        }
    }
}