using DotNetUniversalPatcher.UI;
using DotNetUniversalPatcher.Utilities;
using System;
using System.Windows.Forms;

namespace DotNetUniversalPatcher
{
    internal static class Program
    {
        internal static bool IsDebugModeEnabled;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Helpers.CreatePatcherDirIfNotExists();
            Helpers.SetDebugMode();
            FrmMain.Instance = new FrmMain();
            Application.Run(FrmMain.Instance);
        }
    }
}