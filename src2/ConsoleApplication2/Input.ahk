#InstallKeybdHook

global prt

::/schematic::
     send schematic{space}
     input userInput , V, {enter}          
	 DllCall( ptr , "Str", "schematic " . userInput)
return


::/create::
     send create{space}
     input userInput , V, {enter}          
	 DllCall( ptr , "Str", "create " . userInput)       
return

::/pos::
     send pos{space}
     input userInput , V, {enter}          
	 DllCall( ptr , "Str", "pos " . userInput)                 
return

^s::
	 DllCall( ptr , "Str", "crtl-s was pressed")
return
