using System.Drawing;

namespace graphicApplication.model
{
    class Polygon : shape
    {
        Bitmap drawArea;
        public Polygon(Bitmap drawArea) {
            this.drawArea = drawArea;
        }

        public override Bitmap draw()
        {
            // throw new NotImplementedException();
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
            Graphics g = Graphics.FromImage(drawArea);
            // Create points that define polygon.
            PointF point1 = new PointF(200.0F, 0.0F);
            PointF point2 = new PointF(100.0F, 50.0F);
            PointF point3 = new PointF(150.0F, 150.0F);
            PointF point4 = new PointF(250.5F, 150.0F);
            PointF point5 = new PointF(300.0F, 50.0F);
           
            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5
              
             };

            // Draw polygon curve to screen.
           g.DrawPolygon(blackPen, curvePoints);
            return drawArea;

        }

        public Bitmap draw(Point p1,Point p2,Point p3,Point p4,Point p5) {
            Point[] points = { p1, p2, p3, p4, p5 };
            Pen blackPen = new Pen(Color.Black, 3);
            Graphics g = Graphics.FromImage(drawArea);
            g.DrawPolygon(blackPen,points);
            return drawArea;
        }

    }
}
