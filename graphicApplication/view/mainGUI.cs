using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using graphicApplication.controller;
namespace graphicApplication.view
{
    public partial class mainGUI : Form
    {
        public mainGUI()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Bitmap drawArea = new Bitmap(1000, 1000);
            string command = txtCommandArea.Text;
            simpleShapeFactory f = new simpleShapeFactory();
            Bitmap b = f.createShape(command,drawArea);
            //  shapeGUI gui = new shapeGUI(b);
            // gui.Show();
            drawingCanvas.Image = b;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
