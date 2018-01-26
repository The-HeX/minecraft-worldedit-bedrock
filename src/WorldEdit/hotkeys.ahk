#IfWinActive Minecraft
#InstallKeybdHook

global prt

F11::
	 DllCall( ptr , "Str", "1")
return
F12::
	 DllCall( ptr , "Str", "2")
return
^s::
	 DllCall( ptr , "Str", "3")
return
^k::
	 DllCall( ptr , "Str", "4")
return
^l::
	 DllCall( ptr , "Str", "5")
return


