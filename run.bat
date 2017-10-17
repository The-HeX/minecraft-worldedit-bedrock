del *.csv
cd src\ShapeGenerator\bin\Debug
rem  rem line in x coordinate
rem  shapegenerator.exe -s line   --x1 10 --z1 10  --y1 4  --x2 50  --y2 4 --z2  10 --block wool
rem  rem line in z coordinate
rem  shapegenerator.exe -s line   --x1 10 --z1 10  --y1 4  --x2 10  --y2 4 --z2  50
rem  rem line in y coordinate
rem  shapegenerator.exe -s line   --x1 10 --z1 10  --y1 4  --x2 10  --y2 50 --z2  10 --block wool
rem  
rem  shapegenerator.exe -s line   --x1 100 --z1 100  --y1 10  --x2 150  --y2 40 --z2  50
rem  shapegenerator.exe -s line   --x1 100 --z1 100  --y1 10  --x2 150  --y2 40 --z2  150
rem  shapegenerator.exe -s line   --x1 100 --z1 100  --y1 10  --x2 50   --y2 40 --z2  50
rem  
rem  shapegenerator.exe -s circle   --cx 0 --cz 20  --cy 4  -h 30    --r 5 --block wool
rem  shapegenerator.exe -s circle   --cx 0 --cz 40  --cy 4  -h 30    --r 5  -f
rem  
rem  shapegenerator.exe -s sphere --cx 0 --cz 60  --cy 15  --r 5 --block glass
rem  
rem  shapegenerator.exe -s sphere --cx 0 --cz 90  --cy 15  --r 8 --block stone -f
rem  
rem shapegenerator.exe -s square --cx 60 --cz 0 --h 10  --cy 15  --width 30 --block stone -f
rem 
rem shapegenerator.exe -s square --cx 60 --cz 0 --h 10  --cy 40  --width 30 --block wool 
rem 
rem shapegenerator.exe -s box --cx 60 --cz 60 --h 10  --cy 40  --width 30 --block wool 



rem shapegenerator.exe -s square --cx 6256 --cz -1181  --cy 65  -h 40   --width 300 --block stone
rem shapegenerator.exe -s square --cx 6256 --cz -1181  --cy 65  -h 20   --width 298 --block air -f

rem shapegenerator.exe -s circle   --cx 6752 --cz -1240  --cy 60  -h 30    --r 5  -f
rem shapegenerator.exe -s circle   --cx 6755 --cz -1210  --cy 60  -h 30    --r 5  -f

rem shapegenerator.exe -s circle   --cx 6256 --cz -1181  --cy 65  -h 20  --r 500 --block stone
rem shapegenerator.exe -s circle   --cx 6256 --cz -1181  --cy 85  -h 1  --r 501 --block stone
shapegenerator.exe -s circle   --cx 6256 --cz -1181  --cy 86  -h 0  --r 502 --block stone

