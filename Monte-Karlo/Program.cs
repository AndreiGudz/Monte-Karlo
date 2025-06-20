using Monte_Karlo.DataBase;
using Monte_Karlo.Models;

namespace Monte_Karlo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show(
                    "Программа уже запущена.",
                    "Оповещение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            Application.Run(new SplashScreenForm());
        }
    }
}