using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using graphicApplication.controller;
using System.Text.RegularExpressions;

namespace graphicApplication.view

{
    public partial class mainGUI : Form
    {
        public mainGUI()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Bitmap drawArea = new Bitmap(1000, 1000);
            String[] commands = txtCommandArea.Text.Split('\n');
            simpleShapeFactory f = new simpleShapeFactory();

            //test
            


            //creating regular expression to match patterns.
            String variablePattern = @"^[a-zA_Z0-9]+=[0-9]+$";
            String varPointText = @"^([a-zA-Z]+[0-9]*)=[0-9]+,[0-9]+$";
            String varMethod = @"^(circle|(circle)\(([a-zA-Z]+[0-9]*)\)|triangle|rectangle|polygon|drawLine|(drawLine)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(rectangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(triangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\))$";
            Regex varReg = new Regex(variablePattern);
            Regex varPointReg = new Regex(varPointText);
            Regex varMethodReg = new Regex(varMethod);
            // creating list to hold variables
            Dictionary<String, int> normalVarHolder = new Dictionary<string, int>();
            Dictionary<String, Point> pointVariableHolder = new Dictionary<string, Point>();
            foreach (String s in commands) {
                if (varReg.IsMatch(s))
                {
                    // create variable
                    String[] splitedCommand = s.Split('=');
                    String varName = splitedCommand[0];
                    int varValue = Convert.ToInt32(splitedCommand[1]);
                    normalVarHolder.Add(varName, varValue);
                    MessageBox.Show("variable declaired");

                }
                else if (varPointReg.IsMatch(s))
                {
                    // create variable point
                    String[] splitedCommand = s.Split('=', ',');
                    String varName = splitedCommand[0];
                    Point varValue = new Point(Convert.ToInt32(splitedCommand[1]), Convert.ToInt32(splitedCommand[2]));
                    pointVariableHolder.Add(varName, varValue);
                    MessageBox.Show("point variable declaired");

                }
                else if (varMethodReg.IsMatch(s))
                {
                    //ren methods

                    //regex for simple command
                    String simpleVarCommand = @"^(triangle|circle|rectangle|drawLine|polygon)$";
                    Regex simpleVarReg = new Regex(simpleVarCommand);
                    //regex for parameterized command
                    String parameterizedCommand = @"^((circle)\(([a-zA-Z]+[0-9]*)\)|(drawLine)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(rectangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\))$";
                    Regex parameterizedVarReg = new Regex(parameterizedCommand);

                    //regex for pointBased parameterized command

                    String pointParameterizedCommand = @"^(triangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)$";
                    Regex pointParaReg = new Regex(pointParameterizedCommand);

                    //compare command
                    if (simpleVarReg.IsMatch(s))
                    {
                        // if simple command matched run this section of code.
                        MessageBox.Show("normal command matched");
                       Bitmap b = f.createShape(s, drawArea);
                        drawArea = b;

                    }
                    else if (parameterizedVarReg.IsMatch(s)) {
                        //if parameterized variable is declared run this section of code.
                        MessageBox.Show("parameterized command matched");
                        
                       Bitmap b = f.createShape(s, drawArea,normalVarHolder);
                        drawArea = b;

                    }
                    else if(pointParaReg.IsMatch(s))
                    {
                        //if point based parameterized command is matched run this section of code.
                        MessageBox.Show("point parameterized command matched");
                       Bitmap b = f.createShape(s, drawArea, pointVariableHolder);
                        drawArea = b;


                    }


                }
               
                else {
                    MessageBox.Show("false");

                }
                             


              
            }
           
            //  shapeGUI gui = new shapeGUI(b);
            // gui.Show();
            drawingCanvas.Image = drawArea;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  String[] command = txtCommandArea.Text.Split('\n');
            String variableText = @"^[a-zA_Z0-9]=[0-9]$";
            string varPointText = @"^[a-zA-Z0-9]=[0-9],[0-9]";
            string test = @"^(circle)\(([a-zA-Z]+[0-9]*)\)$";
            string paraLine = @"^((drawLine)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)| love)$";
            string rectanglePattern = @"^(rectangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)$";
            String text = txtCommandArea.Text;
            Regex reg = new Regex(rectanglePattern);
            if (reg.IsMatch(text))
            {
                MessageBox.Show("matched");
            }
            else {
                MessageBox.Show("notMatched");
            }
        }
    }
}
