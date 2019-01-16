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
            String varMethod = @"^(circle|(circle)\(([a-zA-Z]+[0-9]*)\)|triangle|rectangle|polygon|drawLine|(drawLine)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(rectangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(triangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(polygon)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|([a-zA-Z]+[0-9]*)\+[0-9]+)$";
            Regex varReg = new Regex(variablePattern);
            Regex varPointReg = new Regex(varPointText);
            Regex varMethodReg = new Regex(varMethod);
            // creating list to hold variables
            Dictionary<String, int> normalVarHolder = new Dictionary<string, int>();
            Dictionary<String, Point> pointVariableHolder = new Dictionary<string, Point>();

            //check if command contains loop statement.
            Boolean loopStartCommand=false;
            Boolean loopEndCommand=false;
            String loopStartText = @"^(loop)\s[0-9]+$";
            String loopEndText = @"^(endLoop)$";

            Regex loopStartReg = new Regex(loopStartText);
            Regex loopEndReg = new Regex(loopEndText);

            foreach (var c in commands) {
                if (loopStartReg.IsMatch(c))
                    loopStartCommand = true;
                else if (loopEndReg.IsMatch(c))
                    loopEndCommand = true;
          
            }

            if ((loopStartCommand) && (loopEndCommand))
            {
                MessageBox.Show("loop detected");
                int loopUntill = 0;
             
                foreach (String s in commands) {
                    //create variable
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

                    } else if (loopStartReg.IsMatch(s)) {

                        String[] splitedCommand = s.Split(' ');
                        loopUntill =Convert.ToInt32(splitedCommand[1]);

                    }

                }
                List<String> loopCommands = filterLoopCommand(commands);

                //regex for parameterized command
                String parameterizedCommand = @"^((circle)\(([a-zA-Z]+[0-9]*)\)|(drawLine)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(rectangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\))$";
                Regex parameterizedVarReg = new Regex(parameterizedCommand);

                //regex for pointBased parameterized command

                String pointParameterizedCommand = @"^((triangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(polygon)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\))$";
                Regex pointParaReg = new Regex(pointParameterizedCommand);

                //regex for value changing command
                String valueChangingCommand = @"^([a-zA-Z]+[0-9]*)\+[0-9]+$";
                Regex valueChangeReg = new Regex(valueChangingCommand);
                for (int i = 0; i< loopUntill; i++) {
                    foreach (var ss in loopCommands) {
                        
                        if (varMethodReg.IsMatch(ss))
                        {
                            if (parameterizedVarReg.IsMatch(ss))
                            {
                                //if parameterized variable is declared run this section of code.
                                MessageBox.Show("parameterized command matched");

                                Bitmap b = f.createShape(ss, drawArea, normalVarHolder);
                                drawArea = b;

                            }
                            else if (pointParaReg.IsMatch(ss))
                            {
                                //if point based parameterized command is matched run this section of code.
                                MessageBox.Show("point parameterized command matched");
                                Bitmap b = f.createShape(ss, drawArea, pointVariableHolder);
                                drawArea = b;

                            } else if (valueChangeReg.IsMatch(ss)) {
                             //   MessageBox.Show("variable changed eheh");


                                  string[] splitedCommand = ss.Split('+');
                                   String incrementVariableName = splitedCommand[0];
                                 int incrementWith = Convert.ToInt32(splitedCommand[1]);
                                 normalVarHolder[incrementVariableName] = normalVarHolder[incrementVariableName] + incrementWith;
                                 MessageBox.Show("variable changed");

                            }





                        }



                    }
                 


                }









            }
            else {
                MessageBox.Show("statement without loop");
                foreach (String s in commands)
                {
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

                        String pointParameterizedCommand = @"^((triangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)|(polygon)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\))$";
                        Regex pointParaReg = new Regex(pointParameterizedCommand);

                        //compare command
                        if (simpleVarReg.IsMatch(s))
                        {
                            // if simple command matched run this section of code.
                            MessageBox.Show("normal command matched");
                            Bitmap b = f.createShape(s, drawArea);
                            drawArea = b;

                        }
                        else if (parameterizedVarReg.IsMatch(s))
                        {
                            //if parameterized variable is declared run this section of code.
                            MessageBox.Show("parameterized command matched");

                            Bitmap b = f.createShape(s, drawArea, normalVarHolder);
                            drawArea = b;

                        }
                        else if (pointParaReg.IsMatch(s))
                        {
                            //if point based parameterized command is matched run this section of code.
                            MessageBox.Show("point parameterized command matched");
                            Bitmap b = f.createShape(s, drawArea, pointVariableHolder);
                            drawArea = b;

                        }

                    }

                    else
                    {
                        MessageBox.Show("Command not matched");

                    }

                }

               
            }

            drawingCanvas.Image = drawArea;
        }

        // seperate loop command
        public List<String> filterLoopCommand(String[] command) {
            String loopCommad = " ";
            String loopEndCommad = " ";
            String loopStartText = @"^(loop)\s[0-9]+$";
            String loopEndText = @"^(endLoop)$";

            Regex loopStartReg = new Regex(loopStartText);
            Regex loopEndReg = new Regex(loopEndText);
            String[] commands = command;

            //counter for index.


            // get loop exact cmmand
            foreach (var v in commands) {
                //for start loop
                if (loopStartReg.IsMatch(v)) {
                    loopCommad = v;

                }

                // for End loop
                if (loopEndReg.IsMatch(v)) {

                    loopEndCommad = v;
                }
             }
            int loopIndex = Array.FindIndex(commands, x => x == loopCommad);
            int endLoopIndex= Array.FindIndex(commands, x => x == loopEndCommad);
            List<String> loopCommands = new List<string>();
            for (int i = loopIndex+1; i < endLoopIndex; i++) {
                loopCommands.Add(commands[i]);

            }

            return loopCommands;
        }
       

           






        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  String[] command = txtCommandArea.Text.Split('\n');
            // String variableText = @"^[a-zA_Z0-9]=[0-9]$";
            // string varPointText = @"^[a-zA-Z0-9]=[0-9],[0-9]";
            // string test = @"^(circle)\(([a-zA-Z]+[0-9]*)\)$";
            // string paraLine = @"^((drawLine)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)| love)$";
            // string rectanglePattern = @"^(rectangle)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)$";
            // String polyText = @"^(polygon)\(([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*),([a-zA-Z]+[0-9]*)\)$";
             String loopStartText = @"^(loop)\s[0-9]+$";
             String loopEndText = @"^(endLoop)$";
            String valueChangingCommand = @"^([a-zA-Z]+[0-9]*)\+[0-9]+$";
            String text = txtCommandArea.Text;
            Regex reg = new Regex(valueChangingCommand);
           if (reg.IsMatch(text))
             {
               MessageBox.Show("matched");
                }
             else {
                  MessageBox.Show("notMatched");
              }
         //   String[] commands = txtCommandArea.Text.Split('\n');

           // filterLoopCommand(commands);
        }
    }
}
