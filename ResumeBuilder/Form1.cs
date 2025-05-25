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
            timer2.Interval = 50; // slightly slower to see the bar
            timer2.Tick += timer2_Tick;  // this connects the Tick event
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progress++;
            if (progress >= 100)
            {
                timer2.Stop();
                this.Hide(); // hide splash
                //Form1 mainForm = new Form1();
                //mainForm.Show();
            }
            progressBar.Value = progress;
            txtLoading.Text = progress.ToString() + "%";
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
