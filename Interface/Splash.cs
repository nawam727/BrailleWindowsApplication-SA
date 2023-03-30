using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrailleWindowsApplication_SA.Interface
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }


        //Progress bar 
        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 5;
            if (startP <= MyProgress.Maximum) // Check if startP is within the maximum value of the progress bar
            {
                MyProgress.Value = startP;
                PercentageLbl.Text = startP + "%";
                if (MyProgress.Value == 100)
                {
                    MyProgress.Value = 0;
                    Shapes Obj = new Shapes();
                    Obj.Show();
                    this.Hide();
                    timer1.Stop();
                }
            }
            else
            {
                // If startP exceeds the maximum value of the progress bar, reset it to 0
                startP = 0;
            }
        }
    }
}
