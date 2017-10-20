#ifwinactive Minecraft

FileCreateDir, processed
global run:=true

^s::
run:=false
return

^f::

Loop Files, *.csv, 
{
Loop, read,  %A_LoopFileFullPath%
{
	if(run=false){
		return
	}
	if (A_index >= 2)
	{
	    LineNumber = %A_Index%
	    Loop, parse, A_LoopReadLine, CSV
	    {
		if(a_index=1){
			x:=A_LoopField
		}

		if(a_index=2){
			y:=A_LoopField
		}        

		if(a_index=3){
			z:=A_LoopField
		}        
		if(a_index=4){
			x2:=A_LoopField
		}        

		if(a_index=5){
			y2:=A_LoopField
		}        
		if(a_index=6){
			z2:=A_LoopField
		}        
		if(a_index=7){
			block:=A_LoopField
		}        
		if(a_index=8){
			data:=A_LoopField
		}        
	    }
		h:= y2 +2
		send {enter}
		sleep 200
		send /tp @p %x% %h% %z%
		sleep 200
		send {enter}
		sleep 200
		send {enter}
		sleep 200
		send /fill %x% %y% %z% %x2% %y2% %z2% %block% %data%
		sleep 200
		send {enter}
		sleep 200
	}	
}
FileMove, %A_LoopFileFullPath%, processed
}
return


^t::

Loop Files, *.fill, 
{
	Loop, read,  %A_LoopFileFullPath%
	{
		if(run=false){
			return
		}
		LineNumber = %A_Index%		
		send /
		sleep 200
		send %A_LoopReadLine%
		sleep 200
		send {enter}
		sleep 200
	}
	FileMove, %A_LoopFileFullPath%, processed
}
return
