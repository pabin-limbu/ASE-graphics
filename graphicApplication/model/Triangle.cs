using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphicApplication.model
{
    class Triangle:shape
    {
        Bitmap drawArea;
        public Triangle(Bitmap drawArea) {
            this.drawArea = drawArea;
        }

        public override Bitmap draw()
        {
            //throw new NotImplementedException();
            Graphics g = Graphics.FromImage(drawArea);

            Pen p = new Pen(Color.Black, 2);
            PointF point1 = new PointF(200.0F, 40.0F);
            PointF point2 = new PointF(0.0F, 300.0F);
            PointF point3 = new PointF(400.0F, 300.0F);
           
            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3
                
                
             };

            // Draw polygon curve to screen.
            g.DrawPolygon(p, curvePoints);
            // g.DrawRectangle(p, rec);
            //g.DrawEllipse(p, rec);
            return drawArea;
          //  return null;
        }

        public Bitmap draw(Point a,Point b,Point c) {
            Point[] trianglePoints = { a, b, c };
            Graphics g = Graphics.FromImage(drawArea);
            Pen p = new Pen(Color.Black, 2);
            g.DrawPolygon(p,trianglePoints);
            return drawArea;
        }


    }
}
