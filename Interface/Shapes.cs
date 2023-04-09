using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrailleWindowsApplication_SA.Interface
{
    public partial class Shapes : Form
    {
        public Shapes()
        {
            InitializeComponent();
        }

        //Convert btn and error
        private void convertShapes_Click(object sender, EventArgs e)
        {
            errlabel.ForeColor = Color.Red;
            if (ShapesCB.SelectedItem == null)
            {
                errlabel.Show();
                errlabel.Text = "Select an Item";
                return;
            }
            errlabel.Hide();
            errlabel.Text = "";
            ShapesCB_SelectedIndexChanged(sender, e);
        }

        private void ClosePic_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Shapes comboBox list
        private void ShapesList()
        {
            string[] shapes = {"Square", "Rectangle", "Pyramid", "Right Triangle", "Left Triangle",
                   "Diamond", "Circle"};
            Array.Sort(shapes);
            ShapesCB.Items.AddRange(shapes);
        }
        private void ShapesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShapesList();
            string selectedItem = ShapesCB.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Square":
                    string textValue = textBox1.Text;
                    ShapeRectangle(textValue, textValue, false);
                    break;
                case "Rectangle":
                    string textValue1 = textBox1.Text;
                    string textValue2 = textBox2.Text;
                    ShapeRectangle(textValue1, textValue2, true);
                    break;
                case "Pyramid":
                    ShapePyramid();
                    break;
                case "Circle":
                    ShapeCircle();
                    break;
                case "Right Triangle":
                    ShapeRTriangle();
                    break;
                case "Left Triangle":
                    ShapeLTriangle();
                    break;
                case "Diamond":
                    ShapeDiamond();
                    break;
                default:
                    break;
            }
        }

        private void TextsBtn_Click(object sender, EventArgs e)
        {
            Texts obj = new Texts();
            obj.Show();
            this.Hide();
        }

        private void ShapesBtn_Click(object sender, EventArgs e)
        {

        }

        //Rectangle and Squre printing
        private void ShapeRectangle(string textValue1, string textValue2, bool second)
        {
            para1Lbl.Show();
            textBox1.Show();
            para1Lbl.Text = "Side Length";
            para2Lbl.Hide();
            textBox2.Hide();
            panelPara2.Hide();

            Second_Value(second);
            string url = $"http://localhost:8082/DotPrint/api/rectangle/{textValue1}/{textValue2}";
            GetApi(url);
        }
        private void Second_Value(bool second)
        {
            if (second)
            {
                para2Lbl.Show();
                textBox2.Show();
                panelPara2.Show();
                para1Lbl.Text = "Width";
                para2Lbl.Text = "Height";
            }
        }

        private void Parms(string labelText1, string labelText2, bool second)
        {
            para1Lbl.Show();
            panelPara1.Show();
            para1Lbl.Text = labelText1;
            para2Lbl.Hide();
            panelPara2.Hide();

            if (second)
            {
                para2Lbl.Show();
                panelPara2.Show();
                para2Lbl.Text = labelText2;
            }
        }

        //Circle printing
        private void ShapeCircle()
        {
            Parms("Radius", "", false);
            string textValue1 = textBox1.Text;
            string textValue2 = "3";

            string url = $"http://localhost:8082/DotPrint/api/circle/{textValue1}/{textValue2}";
            GetApi(url);
        }

        //Pyramid printing
        private void ShapePyramid()
        {
            Parms("Rows", "", false);
            string textValue1 = textBox1.Text;
            //string textValue2 = "3";
            string url = $"http://localhost:8082/DotPrint/api/piramide/{textValue1}";
            GetApi(url);

        }
        //Right Triangle printing
        private void ShapeRTriangle()
        {
            Parms("Rows", "", false);
            string textValue1 = textBox1.Text;
            string url = $"http://localhost:8082/DotPrint/api/righttriangle/{textValue1}";
            GetApi(url);
        }

        //Left Triangle printing
        private void ShapeLTriangle()
        {
            Parms("Rows", "", false);
            string textValue1 = textBox1.Text;
            string url = $"http://localhost:8082/DotPrint/api/lefttriangle/{textValue1}";
            GetApi(url);
        }
        //Diamond printing
        private void ShapeDiamond()
        {
            Parms("Rows", "", false);
            string textValue1 = textBox1.Text;
            string url = $"http://localhost:8082/DotPrint/api/diamond/{textValue1}";
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
                    brailleshapTB.Text = dotPrint;
                }
                else
                {
                    brailleshapTB.Text = "Server Error";
                }
            }
            catch (Exception ex)
            {
                brailleshapTB.Text = ex.Message;
            }
        }
    }
}
