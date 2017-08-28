using AppLocadora.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppLocadora
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
            Application.SetCompatibleTextRenderingDefault(false);
            LoginAppContext loginAppContext = new LoginAppContext(new Central(), new Login());
            Application.Run(loginAppContext);
            //Application.Run(new Central(context));

        }
    }
}