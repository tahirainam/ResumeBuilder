﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
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
            using (SplashScreen splashScreen = new SplashScreen())
            {
                splashScreen.ShowDialog();
            }
            Application.Run(new RegistrationForm());
        }
    }
}
