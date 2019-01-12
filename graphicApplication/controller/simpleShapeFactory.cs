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
        public Bitmap createShape(string type) {

            if (type == "circle") {
                shape shape = new circle();
                try
                {
                    Bitmap b = shape.draw();
                    return b;
                }
                catch (NotImplementedException e) {
                    MessageBox.Show(e.Message);
                        };
               

            }
            return null;
        }
    }
}
