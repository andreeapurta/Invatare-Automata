using System.Drawing;

namespace GeneratePoints
{
    public class Area
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int SigmaX { get; set; }
        public int SigmaY { get; set; }
        public Color Color { get; set; }

        public Area(string name, int x, int y, int sigmaX, int sigmaY, Color color)
        {
            Name = name;
            X = x;
            Y = y;
            SigmaX = sigmaX;
            SigmaY = sigmaY;
            Color = color;
        }
    }
}