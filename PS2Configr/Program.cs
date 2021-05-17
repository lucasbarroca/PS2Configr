using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PS2Configr
{
    static class Program
    {
        public static FrmMain frmMain;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new FrmMain();
            Application.Run(frmMain);
        }
    }
}
