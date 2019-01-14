using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphicApplication.model
{
    class line
    {
        Bitmap drawArea;
        public Bitmap drawLine(Pen pen,Bitmap drawArea,int x,int y) {
        
            this.drawArea = drawArea;
            Graphics g=Graphics.FromImage(drawArea);
            Pen p = pen;

            g.DrawLine(p,x,x,y,y);
                       
            return drawArea;
        }
    }
}
