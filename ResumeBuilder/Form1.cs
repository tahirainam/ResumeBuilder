using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class SplashScreen: Form
    {
        int progress = 0;
        public SplashScreen()
        {
            InitializeComponent();
            timer2.Interval = 5; 
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progress++;
            if (progress >= 100)
            {
                timer2.Stop();
                this.Close();
            }
            progressBar.Value = progress;
            txtLoading.Text = progress.ToString() + "%";
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
