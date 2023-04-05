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
    public partial class Texts : Form
    {
        public Texts()
        {
            InitializeComponent();
        }

        private void Texts_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShapesBtn_Click(object sender, EventArgs e)
        {
            Shapes obj = new Shapes();
            obj.Show();
            this.Hide();
        }

        private void ClosePic_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //To validate
        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            if (TextTB.Text.Trim().Length == 0)
            {
                label3.Text = "Please enter a value.";
                label3.ForeColor = Color.Red;
                TextTB.Focus();
            }
            else
            {
                label3.Text = "";

            }
        }
    }
}
