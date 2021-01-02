#Katana

This is a simple learning project (for me!) that uses Silk (https://github.com/SoftCircuits/Silk) to provide a simple programming language with graphical and text components.

Implemented functions are:

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
