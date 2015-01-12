using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GFindStr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string filename = String.Empty;
            if (args.Length > 0)
            {
                filename = args[0];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GFindStrForm(filename));
        }
    }
}
