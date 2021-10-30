using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KMeansAlgorithm
{
    public partial class MainForm : Form
    {
        private readonly Random random;
        private int numberOfCentroids;
        private Centroid[] centroids;
        private List<Point> points;
        private Graphics graph;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            graph = mainPanel.CreateGraphics();

            //Pas 1: generare nr de centroizi [2,10]
            numberOfCentroids = random.Next(2, 11);
            centroids = new Centroid[numberOfCentroids];
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\generatedPoints.txt");
            points = GetThePoints(reader);
        }

        private List<Point> GetThePoints(StreamReader reader)
        {
            points = new List<Point>();
            string[] line = new string[4];
            for (int i = 0; i < 5000; i++)
            {
                line = reader.ReadLine().Split(' ');
                var point = new Point(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]));
                points.Add(point);
            }
            return points;
        }

        //private double GenerateDistance(int kx, int x, int ky, int y)
        //{
        //    double distanta = 0;
        //    switch (metodaSimilaritate)
        //    {
        //        case "Euclidian":
        //            {
        //                distanta = Math.Sqrt(Math.Pow(Math.Abs(centroidCenter.X - point.X), 2) + Math.Pow(Math.Abs(centroidCenter.Y - point.Y), 2));
        //                break;
        //            }
        //        case "Manhattan":
        //            {
        //                distanta = Math.Abs(centroidCenter.X - point.X) + Math.Abs(centroidCenter.Y - point.Y)
        //                break;
        //            }
        //    }
        //    return distanta;
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            int epochNumber = 1;
            int cost = 0;
            costLbl.Text = "Cost: " + cost;
            InitializeGraph(graph);
            DrawCentroids(graph);
        }

        private void DrawCentroids(Graphics graph)
        {
            for (int i = 0; i < numberOfCentroids; i++)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                centroids[i] = new Centroid(random.Next(-300, 301), random.Next(-300, 301), "Centroid " + (i + 1), randomColor);
                Brush brush = new SolidBrush(centroids[i].Color);
                graph.FillEllipse(brush, centroids[i].Center.X + 300, 300 - centroids[i].Center.Y, 10, 10);
            }
        }

        private void InitializeGraph(Graphics graph)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;

            //x
            graph.DrawLine(pen, 0, 300, 600, 300);

            //x
            graph.DrawLine(pen, 300, 600, 300, 0);

            //draw points
            DrawPoints(graph, pen);
        }

        private void DrawPoints(Graphics graph, Pen pen)
        {
            foreach (var point in points)
            {
                graph.DrawRectangle(pen, point.X + 300, 300 - point.Y, 1, 1);
            }
        }
    }
}