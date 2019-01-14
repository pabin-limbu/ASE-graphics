using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using graphicApplication.model;
using System.Windows.Forms;

namespace graphicApplication.controller
{
    class simpleShapeFactory
    {
        string type;
        
        public Bitmap createShape(string type,Bitmap drawArea) {
            this.type = type;

            if (type == "circle")
            {
                shape shape = new Circle(drawArea);
                try
                {
                    drawArea = shape.draw();
                    return drawArea;
                }
                catch (NotImplementedException e)
                {
                    MessageBox.Show(e.Message);
                };


            }
            else if (type == "rectangle")
            {
                graphicApplication.model.Rectangle shapeRec = new graphicApplication.model.Rectangle(drawArea);
                try
                {
                    drawArea = shapeRec.draw(400, 400);
                    return drawArea;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (type == "drawLine")
            {
                line l = new line();


                Pen p = new Pen(Color.Black, 2);
                drawArea = l.drawLine(p, drawArea, 0, 300);

                return drawArea;
            }
            else if (type == "triangle")
            {

                shape s = new Triangle(drawArea);
                drawArea = s.draw();
                return drawArea;
            }
            else if (type == "polygon") {
                shape s = new Polygon(drawArea);
                drawArea=s.draw();
                return drawArea;
            }
            return null;
        }
    }
}
