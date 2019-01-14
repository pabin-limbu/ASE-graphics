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
            String[] commands = txtCommandArea.Text.Split('\n');
            simpleShapeFactory f = new simpleShapeFactory();
            foreach (String s in commands) {
                Bitmap b = f.createShape(s, drawArea);
                drawArea = b;
            }
           
            //  shapeGUI gui = new shapeGUI(b);
            // gui.Show();
            drawingCanvas.Image = drawArea;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] command = txtCommandArea.Text.Split('\n');
          //  MessageBox.Show(""+command[0]);
        }
    }
}
