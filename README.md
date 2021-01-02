#Katana

This is a simple project that uses Silk (https://github.com/SoftCircuits/Silk) to provide a simple 
scripting in a c# windows forms application. Katana supports primtive graphics in addition to the Silk functions documented at https://github.com/SoftCircuits/Silk/blob/master/docs/InternalFunctions.md

Implemented functions are:

"Print" - print text to the (text) output window. 
usage: Print "text"
Example: 
for i = 48 to 126
        print chr(i)
    println
    
"Debug" - print text to the Console (only useful in Visual Studio?)

"Println" - print text to the (text) output window (with a newline). 
Example:
println "Hello, World!"

"SetFont" - specify the font for the output window. 
Example:
SetFont "Consolas, 10"

"uiMsg" - display a simple dialog box with OK button. 
usage: uiMsg "Text to display in dialog", "Dialog title"
Example:
uiMsg "This is a UI Message from Katana. Press OK to continue","Katana uiMsg"

"DrawLine" - draw a line. Example:
DrawLine "Black",1,100,50,200,50

"DrawPixel" - draw a pixel on the screen. 
Example:
DrawPixel "Black",1,600,600

"DrawCircle" - draw a circle. 
usage: DrawCircle "Color", line width (px), X, Y, Radius
Example:
DrawCircle "Green",10,250,400,30

"DrawEllipse" - draw an elipse.
usage: DrawEllipse "Color", line width (px), x1,y1, x2, y2
Example:
DrawEllipse "Blue",2,50,100,200,400

"DrawFilledCircle" - draw a filled circle. 
usage: DrawCircle "Color", X, Y, Radius
Example:
DrawFilledCircle "Red",400,400,50

"DrawCurve" - draw a curve between the specified points. 
usage: DrawCurve "Color",line width (px), x1,y1,x2,y2.....
Example:
DrawCurve "Yellow",5,400,500,400,550,450,600,450,650,470,700,500,750

"DrawPolygon" - draw a polygon. 
usage: DrawPolygon "Color", line width (px), x1,y1,x2,y2,x3,y3...
Example:
DrawPolygon "Magenta",5,300,400,500,500,600,400,500,400

"DrawFilledPolygon" - draw a filled polygon. 
usage: DrawFilledPolygon "Color", x1,y1,x2,y2,x3,y3...
Example:
DrawFilledPolygon "Red",600,500,600,600,700,500,600,500

"DrawText" - draw text on the graphics canvas. 
usage: DrawText "Color", "Font, Size", x,y, text
Example:
DrawText "Blue","Arial, 10",150,250,"Ellipse"

"TextColor" - specify the text foreground/background color for the output window. 
usage: TextColor "Foreground color", "Background color"
Example:
TextColor "Green","Black"

"ClearText" - clear the output window

"ClearCanvas" - clear the graphic canvas

"CanvasBackgroundColor" - set the graphic canvas background color to that specified. 
usage: CanvasBackgroundColor("Background color")

Example:
CanvasBackgroundColor "Black"

"Sleep" - sleep for the period specified 
usage: Sleep (time to sleep, in milliseconds)
Example:
Sleep 5000


See examples for some sample scripts.

