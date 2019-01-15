using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicApplication.model
{
    class Circle : shape
    {
        Bitmap drawArea;
        public Circle(Bitmap drawArea) {
            this.drawArea = drawArea;

        }
        public override Bitmap draw()
        {
             //throw new NotImplementedException();
            Bitmap b = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(drawArea);

            Pen p = new Pen(Color.Black, 2);
            System.Drawing.Rectangle rec = new System.Drawing.Rectangle(50, 50, 300, 300);

            g.DrawEllipse(p, rec);
            return drawArea;
        }

        public Bitmap draw(int radius) {

            Bitmap b = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(drawArea);

            Pen p = new Pen(Color.Black, 2);
            System.Drawing.Rectangle rec = new System.Drawing.Rectangle(60, 60, radius*2, radius*2);

            g.DrawEllipse(p, rec);
            return drawArea;
        }
    }
}
