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
                    //ShapeRectangle(textValue, textValue, false);
                    break;
                case "Rectangle":
                    string textValue1 = textBox1.Text;
                    string textValue2 = textBox2.Text;
                    //ShapeRectangle(textValue1, textValue2, true);
                    break;
                case "Pyramid":
                    //ShapePyramid();
                    break;
                case "Circle":
                    //ShapeCircle();
                    break;
                case "Right Triangle":
                    //ShapeRTriangle();
                    break;
                case "Left Triangle":
                    //ShapeLTriangle();
                    break;
                case "Diamond":
                    //ShapeDiamond();
                    break;
                default:
                    break;
            }
        }

    }
}
