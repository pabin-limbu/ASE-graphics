using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicApplication.model
{
    class line:shape
    {
        Bitmap drawArea;

        public line(Bitmap drawArea) {
            this.drawArea = drawArea;

        }
        public override Bitmap draw()
        {
            //  throw new NotImplementedException();

            Graphics g = Graphics.FromImage(drawArea);
            Pen p = new Pen(Color.Black, 2);

            g.DrawLine(p, 0, 0, 200, 200);

            return drawArea;
        }

        public Bitmap draw(int x,int y) {
        
            Graphics g=Graphics.FromImage(drawArea);
            Pen p = new Pen(Color.Black, 2);

            g.DrawLine(p,x,x,y,y);
                       
            return drawArea;
        }
    }
}
