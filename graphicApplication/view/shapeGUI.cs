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
    public partial class shapeGUI : Form
    {
        public shapeGUI()
        {
            InitializeComponent();
        }

        private void shapeGUI_Paint(object sender, PaintEventArgs e)
        {
            simpleShapeFactory f = new simpleShapeFactory();
            canvas.Image = f.createShape("circle");
        }
    }
}
