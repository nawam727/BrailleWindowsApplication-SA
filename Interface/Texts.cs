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

        
        private void TextTBValidating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextTB.Text))
            {
                e.Cancel = true;
                label3.Text = "Please enter a value.";
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.Text = "";
            }
        }
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

        private void BraillePrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = BrailleTB.Text;
            e.Graphics.DrawString(text, new Font("Poppins", 14, FontStyle.Bold), Brushes.Black, new Point(80));
        }

        private void BraillePreviewDialog_Load(object sender, EventArgs e)
        {

        }

        private void Printbtn_Click(object sender, EventArgs e)
        {
            BraillePrint.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 1280, 720);
            if (BraillePreviewDialog.ShowDialog() == DialogResult.OK)
            {
                BraillePrint.Print();
            }
        }
    }
}
