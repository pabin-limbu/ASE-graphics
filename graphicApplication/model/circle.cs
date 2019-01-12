using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicApplication.model
{
    class circle : shape
    {
        public override Bitmap draw()
        {
             //throw new NotImplementedException();
            Bitmap b = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(b);

            Pen p = new Pen(Color.Black, 2);
            Rectangle rec = new Rectangle(50, 50, 300, 200);

            g.DrawEllipse(p, rec);
            return b;
        }
    }
}
