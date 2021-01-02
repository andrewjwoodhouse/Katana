#Katana

This is a simple learning project (for me!) that uses Silk (https://github.com/SoftCircuits/Silk) to provide a simple programming language with graphical and text components.

Implemented functions are:

	    "Print"
             "Debug"
             "Println"
             "TextFormat"
             "uiMsg"
             "DrawLine"
             "DrawPixel"
             "DrawCircle"
             "DrawEllipse"
             "DrawFilledCircle"
             "DrawCurve"
             "DrawPolygon"
             "DrawFilledPolygon"
             "DrawText"
             "TextColor"
             "SetFont"
             "ClearText"
             "ClearCanvas"
             "Sleep"


An example script:

main()
{
	println "Drawing Katana supported graphics primitives on graphic canvas"
	uiMsg "This is a UI Message from Katana. Press OK to continue","Katana uiMsg"
	println "Primitives are: Line, Text, Circle, FilledCircle, Ellipse, Polygon, Filled Polygon, Curve, Pixel"
	DrawLine "Black",1,100,50,200,50
	DrawText "Black","Consolas, 10",150,30,"Line"
	DrawCircle "Green",10,250,400,30
	DrawEllipse "Blue",2,50,100,200,400
	DrawFilledCircle "Red",400,400,50
	DrawText "Blue","Arial, 10",150,250,"Ellipse"
	DrawFilledPolygon "Red",600,500,600,600,700,500,600,500
	DrawPolygon "Magenta",5,300,400,500,500,600,400,500,400
	DrawCurve "Yellow",5,400,500,400,550,450,600,450,650,470,700,500,750
	for x = 0 to 1024 step 20
	{
	 DrawPixel "Black",1,x,600
	}
	println "Sleeping 10 seconds..."
	sleep 10
	println "Clearing everything in 5 seconds..."
	sleep 5
	ClearCanvas
	ClearText
	println "Done!"
}

