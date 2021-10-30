using System;
using System.Collections.Generic;
using System.Drawing;

namespace KMeansAlgorithm
{
    public class Centroid
    {
        public string Name { get; set; }
        public Point Center { get; set; }
        public List<Point> AssignedPoints { get; set; }
        public Color Color { get; set; }

        public Centroid(int centerX, int centerY, string name, Color color)
        {
            if (centerX > 300 || centerX < -300)
            {
                throw new ArgumentOutOfRangeException(nameof(centerX), "All coordinates have to be in [-300, 300] interval");
            }
            if (centerY > 300 || centerY < -300)
            {
                throw new ArgumentOutOfRangeException(nameof(centerY), "All coordinates have to be in [-300, 300] interval");
            }

            Center = new Point(centerX, centerY);
            Name = name;
            AssignedPoints = new List<Point>();
            Color = color;
        }
    }
}