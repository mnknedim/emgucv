rm -rf Assets/Emgu.CV/Emgu.CV.Demo
mkdir Assets\Emgu.CV\Emgu.CV.Demo
mkdir Assets\Emgu.CV\Emgu.CV.Demo\Resources

cp ../opencv/samples/cpp/lena.jpg Assets/Emgu.CV/Emgu.CV.Demo/Resources
cp lena.jpg.meta Assets/Emgu.CV/Emgu.CV.Demo/Resources
cp ../opencv/data/haarcascades/haarcascade_frontalface_alt2.xml Assets/Emgu.CV/Emgu.CV.Demo/Resources
cp haarcascade_frontalface_alt2.xml.meta Assets/Emgu.CV/Emgu.CV.Demo/Resources
cp demo/* Assets/Emgu.CV/Emgu.CV.Demo
cp unityStoreIcons/EmguCVLogo_128x128.png Assets/Emgu.CV/Emgu.CV.Demo/EmguCVLogo.png