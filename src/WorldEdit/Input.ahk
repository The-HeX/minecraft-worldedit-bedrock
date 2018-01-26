#InstallKeybdHook

global prt

^s::
	 DllCall( ptr , "Str", "crtl-s was pressed")
return
