del *.csv
cd src\ShapeGenerator\bin\Debug
 rem line in x coordinate
 shapegenerator.exe -s line   --x1 10 --z1 10  --y1 4  --x2 50  --y2 4 --z2  10 --block wool
 rem line in z coordinate
 shapegenerator.exe -s line   --x1 10 --z1 10  --y1 4  --x2 10  --y2 4 --z2  50
 rem line in y coordinate
 shapegenerator.exe -s line   --x1 10 --z1 10  --y1 4  --x2 10  --y2 50 --z2  10 --block wool
 
 shapegenerator.exe -s line   --x1 100 --z1 100  --y1 10  --x2 150  --y2 40 --z2  50
 shapegenerator.exe -s line   --x1 100 --z1 100  --y1 10  --x2 150  --y2 40 --z2  150
 shapegenerator.exe -s line   --x1 100 --z1 100  --y1 10  --x2 50   --y2 40 --z2  50
 
 shapegenerator.exe -s circle   --cx 0 --cz 20  --cy 4  -h 30    --r 5 --block wool
 shapegenerator.exe -s circle   --cx 0 --cz 40  --cy 4  -h 30    --r 5  -f
 
 shapegenerator.exe -s sphere --cx 0 --cz 60  --cy 15  --r 5 --block glass
 
 shapegenerator.exe -s sphere --cx 0 --cz 90  --cy 15  --r 8 --block stone -f
 
shapegenerator.exe -s square --cx 60 --cz 0 --h 10  --cy 15  --width 30 --block stone -f

shapegenerator.exe -s square --cx 60 --cz 0 --h 10  --cy 40  --width 30 --block wool 

