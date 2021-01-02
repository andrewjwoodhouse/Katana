using SoftCircuits.Silk;
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

// TODO:
// ADD print function (no newline)


// Katana uses the c# silk 
namespace Katana
{
    public partial class Form2 : Form
    {
        internal static Form2 form2;
        internal static Form1 form1;
        internal static Form3 form3;

        // public static CompiledProgram program;
        public static string mySourceFile;
        public static bool canvasRequired = false;

        public Form2(string sourcefile)
        {
            InitializeComponent();
            mySourceFile = sourcefile;
            
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }


        public static void Compile()
        {
            Compiler compiler = new Compiler();
           
            string sourceCode = System.IO.File.ReadAllText(mySourceFile);
            
            

            Console.WriteLine("debug - program: " + sourceCode);
            // Register intrinsic functions - NOTE that silk internal functions are also available
            // as per https://github.com/SoftCircuits/Silk/blob/master/docs/InternalFunctions.md
            Console.WriteLine("Registering functions...");
            compiler.RegisterFunction("Print", 0, Function.NoParameterLimit);
            compiler.RegisterFunction("Debug", 0, Function.NoParameterLimit);
            compiler.RegisterFunction("Println", 0, Function.NoParameterLimit);
            compiler.RegisterFunction("TextFormat", 1, 1);
            compiler.RegisterFunction("uiMsg", 2, 2);
            compiler.RegisterFunction("DrawLine", 3, 6);
            compiler.RegisterFunction("DrawPixel", 4, 4);
            compiler.RegisterFunction("DrawCircle", 5, 5);
            compiler.RegisterFunction("DrawEllipse", 6, 6);
            compiler.RegisterFunction("DrawFilledCircle", 4, 4);
            compiler.RegisterFunction("DrawCurve", 3, Function.NoParameterLimit);
            compiler.RegisterFunction("DrawPolygon", 3, Function.NoParameterLimit);
            compiler.RegisterFunction("DrawFilledPolygon", 3, Function.NoParameterLimit);
            compiler.RegisterFunction("DrawText", 5, 5);
            compiler.RegisterFunction("TextColor", 2, 2);
            compiler.RegisterFunction("SetFont", 1, 1);
            compiler.RegisterFunction("ClearText", 0, 0);
            compiler.RegisterFunction("ClearCanvas", 0, 0);
            compiler.RegisterFunction("Sleep", 1, 1);

            Console.WriteLine("Functions registered!");

            if (compiler.Compile(mySourceFile, out CompiledProgram program))
            {
                Console.WriteLine("Compilation successful!");

                RunProgram(program);
            }
            else
            {
                Console.WriteLine("Compile failed!");
            }
        }



        public static void RunProgram(CompiledProgram program)
        {
            Runtime runtime = new Runtime();
            
                KatanaForm.form2 = new Form2(mySourceFile);
                KatanaForm.form2.Show();
            
                KatanaForm.form3 = new Form3();
                KatanaForm.form3.Show();
            



            runtime.Begin += Runtime_Begin;
            runtime.Function += Runtime_Function;
            runtime.End += Runtime_End;

            Variable result = runtime.Execute(program);

            // Console.WriteLine(source + " ran successfully with exit code {0}.", result);


        }

        public static void Runtime_Begin(object sender, BeginEventArgs e)
        {
            string data = "";
            e.UserData = data;
        }



        public static void DrawLine(string color, int width, PointF[] myPoints)
        // DrawLine(string color, int width, PointF[] myPoints)
        {
            Color myLineColor = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;            
            Pen myPen = new Pen(myLineColor);
            myPen.Width = width;
            PointF[] points = myPoints;
            g.DrawLines(myPen, points);
        }

        public static void ClearCanvas()        
        {
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.Clear(Color.White);            
        }

        public static void DrawText(string color, string fontString, float x, float y, string textToDraw)
        {
            Color myTextColor = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;            
            SolidBrush myTextBrush = new SolidBrush(myTextColor);
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
            Font myFont = (Font) converter.ConvertFromString(fontString);            
            g.DrawString(textToDraw, myFont, myTextBrush, x, y);

        }

        public static void SetFont(string fontString1)
        {            
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
            Font myFont1 = (Font)converter.ConvertFromString(fontString1);
            KatanaForm.form3.programOutputText.Font = myFont1;
        }

        public static void TextColor(string fgcolor, string bgcolor)
        {
            Color myTextColor = System.Drawing.ColorTranslator.FromHtml(fgcolor);
            Color myBackgroundColor = System.Drawing.ColorTranslator.FromHtml(bgcolor);
            KatanaForm.form3.programOutputText.ForeColor = myTextColor;
            KatanaForm.form3.programOutputText.BackColor = myBackgroundColor;
        }

        
        //draw curve
        public static void DrawCurve(string color, int width, List<PointF> myPointList)
        {
            Color myPixelColor = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen myPen = new Pen(myPixelColor);
            myPen.Width = width;            
            PointF[] curvePoints = myPointList.ToArray();
            g.DrawCurve(myPen, curvePoints);


        } // end DrawCurve

        //draw polygon
        public static void DrawPolygon(string color, int width, List<PointF> myPolyPointList)
        {
            Color myPixelColor = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;                        
            Pen myPen = new Pen(myPixelColor);                        
            PointF[] polyP = myPolyPointList.ToArray();
            g.DrawPolygon(myPen, polyP);
            g.ResetTransform();
        } // end DrawPolygon

        public static void DrawFilledPolygon(string color, List<PointF> myPolyPointList)
        {
            Color myPixelColor = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush myPolyBrush = new SolidBrush(myPixelColor);
            PointF[] polyP = myPolyPointList.ToArray();
            g.FillPolygon(myPolyBrush, polyP); 
            g.ResetTransform();
        } // end DrawPolygon


        //
        public static void DrawCircle(string color, int width, int centerX, int centerY, int radius)
        {
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Color myPixelColor = System.Drawing.ColorTranslator.FromHtml(color);
            Pen myPen = new Pen(myPixelColor);
            myPen.Width = width;
            g.DrawEllipse(myPen, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        public static void DrawEllipse(string color, int width, int x1, int y1, int x2, int y2)
        {
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Color myEllipseColor = System.Drawing.ColorTranslator.FromHtml(color);
            Pen myEllipsePen = new Pen(myEllipseColor);
            myEllipsePen.Width = width;
            Rectangle rect = new Rectangle(x1, y1, x2, y2);
            g.DrawEllipse(myEllipsePen, rect);
        }

        public static void DrawFilledCircle(string color, int centerX, int centerY, int radius)
        {
            Graphics g = KatanaForm.form2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color myPixelColor = System.Drawing.ColorTranslator.FromHtml(color);
            SolidBrush myCircleBrush = new SolidBrush(myPixelColor);
            g.FillEllipse(myCircleBrush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        public static void DrawPixel(string color, int size, int x, int y)
        {
            Color myPixelColor = System.Drawing.ColorTranslator.FromHtml(color);
            SolidBrush pixelBrush = new SolidBrush(myPixelColor);
            Graphics g = KatanaForm.form2.CreateGraphics();
            // g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;                            
            g.FillRectangle(pixelBrush, x, y,size,size);

        }// end DrawPixel

        public static void Sleep(int sleepTime)
        {
            DateTime now = DateTime.Now;
            do
            {
                Application.DoEvents();
            } while (now.AddSeconds(5) > DateTime.Now);
        }



        public static void Runtime_Function(object sender, FunctionEventArgs e)
        {

            switch (e.Name)
            {
                case "Print":                    
                    string resultText = string.Join("", e.Parameters.Select(p => p.ToString()));                    
                    KatanaForm.form3.programOutputText.AppendText(resultText);
                    break;
                case "Debug":
                    string consoleText = string.Join("", e.Parameters.Select(p => p.ToString()));
                    Console.WriteLine(consoleText);
                    break;
                case "Println":
                    string resultText1 = string.Join("", e.Parameters.Select(p => p.ToString()));
                    KatanaForm.form3.programOutputText.AppendText(resultText1 + "\n");
                    
                    break;
                case "TextColor": // set fg/bg for our text output
                    string foreColorStr = e.Parameters[0].ToString();
                    string backColorStr = e.Parameters[1].ToString();
                    TextColor(foreColorStr, backColorStr);
                    break;
                case "SetFont":
                    string fontString1 = e.Parameters[0].ToString();                    
                    SetFont(fontString1);
                    break;
                case "ClearText":
                    KatanaForm.form3.programOutputText.Clear();
                    break;
                case "ClearCanvas":
                    ClearCanvas();
                    break;
                case "Sleep":
                    int sleepTime = e.Parameters[0].ToInteger();
                    Sleep(sleepTime);
                    break;
                case "uiMsg":
                    string uiBoxText = e.Parameters[0].ToString();
                    string uiBoxCaption = e.Parameters[1].ToString();
                    MessageBoxButtons uiBoxButtons = MessageBoxButtons.OK;
                    DialogResult uiResult;
                    uiResult = MessageBox.Show(uiBoxText, uiBoxCaption, uiBoxButtons);
                    break;
                case "DrawLine":
                    string colorStr = e.Parameters[0].ToString();                    
                    int swidth = e.Parameters[1].ToInteger();                                       
                    double sx1 = e.Parameters[2].ToFloat();
                    float x1 = (float)sx1;
                    double sy1 = e.Parameters[3].ToFloat();
                    float y1 = (float)sy1;
                    double sx2 = e.Parameters[4].ToFloat();
                    float x2 = (float)sx2;
                    double sy2 = e.Parameters[5].ToFloat();
                    float y2 = (float)sy2;
                    PointF[] points =
                        {
                            new PointF(x1,y1),
                            new PointF(x2,y2)
                    };
                    DrawLine(colorStr, swidth, points);
                    break;
                case "DrawPixel":                    
                    string pixelColor = e.Parameters[0].ToString();
                    int size = e.Parameters[1].ToInteger();
                    int pixelx = e.Parameters[2].ToInteger();
                    int pixely = e.Parameters[3].ToInteger();                    
                    DrawPixel(pixelColor, size,pixelx, pixely);
                    break;
                case "DrawCircle":
                    string colorStrCircle = e.Parameters[0].ToString();
                    int width = e.Parameters[1].ToInteger();
                    int centerx = e.Parameters[2].ToInteger();
                    int centery = e.Parameters[3].ToInteger();
                    int radius = e.Parameters[4].ToInteger();
                    DrawCircle(colorStrCircle, width, centerx, centery, radius);
                    break;
                case "DrawEllipse":
                    string colorStrEllipse = e.Parameters[0].ToString();
                    int ewidth = e.Parameters[1].ToInteger();
                    int ex1 = e.Parameters[2].ToInteger();
                    int ey1 = e.Parameters[3].ToInteger();
                    int ex2 = e.Parameters[4].ToInteger();
                    int ey2 = e.Parameters[5].ToInteger();                    
                    DrawEllipse(colorStrEllipse, ewidth,ex1,ey1,ex2,ey2);
                    break;
                case "DrawFilledCircle":
                    string colorFillCircle = e.Parameters[0].ToString();                   
                    int centerx1 = e.Parameters[1].ToInteger();
                    int centery2 = e.Parameters[2].ToInteger();
                    int radius1 = e.Parameters[3].ToInteger();
                    DrawFilledCircle(colorFillCircle, centerx1, centery2, radius1);
                    break;
                case "DrawCurve":                    
                    if (e.Parameters.Length % 4 -2  != 0)
                    { 
                        Console.WriteLine("Invalid number of curve points. Ensure there are a multiple of 4! Aborting..."); 
                        Application.Exit(); 
                    }
                    string colorStrCurve = e.Parameters[0].ToString();
                    int curvewidth = e.Parameters[1].ToInteger();                    
                    int numPoints = e.Parameters.Length;                     
                    List<PointF> curvePointList = new List<PointF>();
                    for (int i = 2; i < numPoints; i=i+2)
                    {
                        double pointx = e.Parameters[i].ToFloat();
                        float fpointx = (float)pointx;
                        double pointy = e.Parameters[i+1].ToFloat();
                        float fpointy = (float)pointy;                                                
                        curvePointList.Add(new PointF( fpointx, fpointy ));                        
                    } 
                    DrawCurve(colorStrCurve, curvewidth, curvePointList);
                    break;
                case "DrawPolygon":
                    string colorStrPoly = e.Parameters[0].ToString();
                    int polywidth = e.Parameters[1].ToInteger();                   
                    int numPolyPoints = e.Parameters.Length;
                    List<PointF> polyPointList = new List<PointF>();
                    for (int i = 2; i < numPolyPoints; i = i + 2)
                    {
                        double pointx = e.Parameters[i].ToFloat();                        
                        float fpointx = (float)pointx;
                        Console.WriteLine("x: " + fpointx.ToString());
                        double pointy = e.Parameters[i + 1].ToFloat();
                        float fpointy = (float)pointy;
                        Console.WriteLine("y: " + fpointy.ToString());
                        polyPointList.Add(new PointF(fpointx, fpointy));
                    }
                    DrawPolygon(colorStrPoly, polywidth, polyPointList);
                    break;
                case "DrawFilledPolygon":
                    string colorStrPoly1 = e.Parameters[0].ToString();
                    int numPolyPoints1 = e.Parameters.Length;
                    List<PointF> polyPointList1 = new List<PointF>();
                    for (int i = 1; i < numPolyPoints1; i = i + 2)
                    {
                        double apointx = e.Parameters[i].ToFloat();
                        float afpointx = (float)apointx;
                        double apointy = e.Parameters[i + 1].ToFloat();
                        float afpointy = (float)apointy;
                        polyPointList1.Add(new PointF(afpointx, afpointy));
                    }
                    DrawFilledPolygon(colorStrPoly1, polyPointList1);
                    break;
                case "DrawText":
                    string colorStrText = e.Parameters[0].ToString();
                    string fontString = e.Parameters[1].ToString();
                    double textxd = e.Parameters[2].ToFloat();
                    double textyd= e.Parameters[3].ToFloat();
                    float textx = (float)textxd;
                    float texty = (float)textyd;
                    string txt = e.Parameters[4].ToString();
                    DrawText(colorStrText, fontString, textx, texty, txt);
                    break;
                default:
                    //Debug.Assert(false);
                    break;
            }
        }

        

        private static void Runtime_End(object sender, EndEventArgs e)
        {
        }

        

    } // end Form1 class
} // end namespace
