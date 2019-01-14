using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphicApplication.model
{
    class Rectangle : shape
    {
        public override Bitmap draw()
        {
            //  throw new NotImplementedException();
            return null;
        }

        public Bitmap draw(int length, int height) {
            Bitmap b = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(b);

            Pen p = new Pen(Color.Black, 2);
            System.Drawing.Rectangle rec = new System.Drawing.Rectangle(50, 50, length, height);
            g.DrawRectangle(p, rec);
            //g.DrawEllipse(p, rec);
            return b;



        }
    }
}
