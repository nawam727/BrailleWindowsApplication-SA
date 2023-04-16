using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
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
            TextTB.Validating += TextTBValidating;
            ConvertBtn.Click += ConvertBtn_Click;
        }

        private void Texts_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //To navigate to shapes tab
        private void ShapesBtn_Click(object sender, EventArgs e)
        {
            Shapes obj = new Shapes();
            obj.Show();
            this.Hide();
        }

        //To close the application
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

        //Convert bttn
        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            PrintBraille();
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


        //Print braille charactors in BrailleTB
        private void PrintBraille()
        {
            string text = TextTB.Text;
            string url = $"http://localhost:8082/DotPrint/api/brailletext/{text}";
            GetApi(url);
        }

        //Get Api data from api
        private async void GetApi(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                string dotPrint = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    BrailleTB.Text = dotPrint;
                }
                else
                {
                    BrailleTB.Text = "Server Error";
                }
            }
            catch (Exception ex)
            {
                BrailleTB.Text = ex.Message;
            }

        }
        //Print page
        private void BraillePrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = BrailleTB.Text;
            e.Graphics.DrawString(text, new Font("Poppins", 20, FontStyle.Bold), Brushes.Black, new Point(80));
        }

        private void BraillePreviewDialog_Load(object sender, EventArgs e)
        {

        }

        //Print button
        private void Printbtn_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.BraillePrint_PrintPage);

            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
    }
}
