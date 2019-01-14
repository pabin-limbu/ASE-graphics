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
          
            if (type == "circle") {
                shape shape = new circle();
                try
                {
                    drawArea = shape.draw();
                    return drawArea;
                }
                catch (NotImplementedException e) {
                    MessageBox.Show(e.Message);
                };


            } else if (type == "rectangle") {
                graphicApplication.model.Rectangle shapeRec = new graphicApplication.model.Rectangle();
                try
                {
                    drawArea = shapeRec.draw(400, 400);
                    return drawArea;
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            } else if (type=="drawLine") {
                line l = new line();


                Pen p = new Pen(Color.Black, 2);
              drawArea=l.drawLine(p,drawArea,0,300);

                return drawArea;
            }
            return null;
        }
    }
}
