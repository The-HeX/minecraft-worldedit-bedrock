del *.csv
cd src\ShapeGenerator\bin\Debug
shapegenerator.exe -s line   --x1 0 --z1 0  --y1 10  --x2 50  --y2 40 --z2 -50
shapegenerator.exe -s line   --x1 0 --z1 0  --y1 10  --x2 50  --y2 40 --z2  50
shapegenerator.exe -s line   --x1 0 --z1 0  --y1 10  --x2 -50 --y2 40 --z2 -50
shapegenerator.exe -s circle   -x 20 -z 20  -y 4  -h 30    --r 5
shapegenerator.exe -s circle   -x 40 -z 40  -y 4  -h 30    --r 5  -f
shapegenerator.exe -s sphere --x1 0 --z1 0  --y1 10  --x2 -50 --y2 40 --z2 -50

