using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using graphicApplication.model;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace graphicApplication.controller
{
    class simpleShapeFactory
    {
        string type;
        static String circlePattern = @"^(circle)\(([a-zA-Z]+[0-9])\)$";
        Regex circleReg = new Regex(circlePattern);
        Dictionary<string,int> normalVarHolder;
        Dictionary<string, Point> pointVarHolder;

        //shape without parameter.
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
            else if (circleReg.IsMatch(type)) {

                MessageBox.Show("hello");
                return null;
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
                line l = new line(drawArea);


                Pen p = new Pen(Color.Black, 2);
                drawArea = l.draw();

                return drawArea;
            }
            else if (type == "triangle")
            {

                shape s = new Triangle(drawArea);
                drawArea = s.draw();
                return drawArea;
            }
            else if (type == "polygon")
            {
                shape s = new Polygon(drawArea);
                drawArea = s.draw();
                return drawArea;
            }


            return null;
        }


        //shape with point parameter.
        public Bitmap createShape(string type, Bitmap drawArea,Dictionary<String,Point> pointVarHolder)
        {
            this.pointVarHolder = pointVarHolder;
            String[] command = type.Split('(', ',', ')');
            String shapeType = command[0];

            //for triangle
            if (shapeType.Equals("triangle"))
            {
                String pName1 = command[1];    
                String pName2 = command[2];    
                String pName3 = command[3];
                Point p1 = pointVarHolder[pName1];
                Point p2 = pointVarHolder[pName2];
                Point p3 = pointVarHolder[pName3];
                Triangle t = new Triangle(drawArea);
                drawArea = t.draw(p1,p2,p3);
                return drawArea;
                

            }
            else if (shapeType.Equals("polygon")) {


            }

            //for polygon

            return null;
        }


        //shapes with normalParameter.
        public Bitmap createShape(string type, Bitmap drawArea,Dictionary<String,int> normalVarHolder) {
          
            String[] command = type.Split('(',',',')');
            String shapeType = command[0];
            this.normalVarHolder = normalVarHolder;
            //for circle
            if (shapeType.Equals("circle"))
            {
                Circle c = new Circle(drawArea);
                String varName = command[1];
                MessageBox.Show("" + varName);
                int radius = normalVarHolder[varName];
                drawArea = c.draw(radius);
                return drawArea;

            }
            else if (shapeType.Equals("drawLine"))
            {
                //for line

                line l = new line(drawArea);
                String varXName = command[1];
                String varYname = command[2];
                int xCordinate = normalVarHolder[varXName];
                int yCordinate = normalVarHolder[varYname];
                drawArea = l.draw(xCordinate, yCordinate);
                return drawArea;
            }
            else if (shapeType.Equals("rectangle")) {
                //for rectangle
                graphicApplication.model.Rectangle r = new graphicApplication.model.Rectangle(drawArea);
                String lname = command[1];
                String hname = command[2];
                int length = normalVarHolder[lname];
                int height = normalVarHolder[hname];

                drawArea = r.draw(length,height);
                return drawArea;

            }


            
            return null;
        }
    }
}
