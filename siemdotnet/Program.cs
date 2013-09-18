using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace psframework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception e)
            { 
                //Safety Net
                //This is a global exception handler.
                MessageBox.Show("Unhandled Exception" + Environment.NewLine + e.Message + Environment.NewLine + "Stack Trace: " + Environment.NewLine + e.StackTrace, "Unhandled Exception. Program Will Halt.");
                Application.Exit();
            }
        }
    }
}