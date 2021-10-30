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
        private readonly List<double> pointToCentroidDistance;
        private Color[] centroidsColors;
        private readonly Graphics graph;
        private const Distance distanceMethod = Distance.Euclidian;
        private int epochNumber;
        private double cost;

        public MainForm()
        {
            //initializing
            InitializeComponent();
            random = new Random();
            pointToCentroidDistance = new List<double>();
            graph = mainPanel.CreateGraphics();
            GenerateCentroidsColors();
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\generatedPoints.txt");
            points = GetThePoints(reader);
        }

        /// <summary>
        /// //Step 1: Generating a ranom number of centroids[2,10]
        /// </summary>
        private void GetTheNumberOfCentroids(Random random)
        {
            numberOfCentroids = random.Next(2, 11);
            centroids = new Centroid[numberOfCentroids];
            kLbl.Text = "K: " + numberOfCentroids.ToString();
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

        private double GetDistance(int centroidCenterX, int x, int centroidCenterY, int y)
        {
            double distance = 0;
            switch (distanceMethod)
            {
                case Distance.Manhattan:
                    {
                        distance = Math.Abs(centroidCenterX - x) + Math.Abs(centroidCenterY - y);
                        break;
                    }
                case Distance.Euclidian:
                    {
                        distance = Math.Sqrt(Math.Pow(Math.Abs(centroidCenterX - x), 2) + Math.Pow(Math.Abs(centroidCenterY - y), 2));
                        break;
                    }
            }
            return distance;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            GetTheNumberOfCentroids(random);
            centroidsColors = new Color[numberOfCentroids];
            GenerateCentroidsColors();
            mainPanel.Refresh();
            costLbl.Text = "Cost: " + cost;
            Pen pen = new Pen(Color.Black);
            InitializeGraph(graph, pen);
            DrawPoints(graph);
            DrawCentroids(graph);
        }

        private void GenerateCentroidsColors()
        {
            Color randomColor;
            for (int i = 0; i < numberOfCentroids; i++)
            {
                randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                centroidsColors[i] = randomColor;
            }
        }

        /// <summary>
        /// //Step 2: draw centroids in random places in the defined space
        /// </summary>
        private void DrawCentroids(Graphics graph)
        {
            for (int i = 0; i < numberOfCentroids; i++)
            {
                //Color randomColor = Color.FromArgb((int)(0xFF000000 + (random.Next(0xFFFFFF) & 0x7F7F7F))); //only dark colors
                centroids[i] = new Centroid(random.Next(-300, 301), random.Next(-300, 301), "Centroid " + (i + 1), centroidsColors[i]);
                Brush brush = new SolidBrush(centroids[i].Color);
                graph.FillEllipse(brush, centroids[i].Center.X + 300, 300 - centroids[i].Center.Y, 10, 10);
            }
        }

        private void InitializeGraph(Graphics graph, Pen pen)
        {
            pen.Width = 1;

            //x
            graph.DrawLine(pen, 0, 300, 600, 300);

            //x
            graph.DrawLine(pen, 300, 600, 300, 0);
        }

        private void DrawPoints(Graphics graph)
        {
            Pen pen = new Pen(Color.Black);
            foreach (var point in points)
            {
                graph.DrawRectangle(pen, point.X + 300, 300 - point.Y, 1, 1);
            }
        }

        private void ComputeSimilarity()
        {
            double distance;
            foreach (var point in points)
            {
                double min = Double.MaxValue;
                int centroidNr = 0;
                for (int j = 0; j < numberOfCentroids; j++)
                {
                    distance = GetDistance(centroids[j].Center.X, point.X, centroids[j].Center.X, point.Y);
                    if (min > distance)
                    {
                        min = distance;
                        centroidNr = j;
                    }
                }
                centroids[centroidNr].AssignedPoints.Add(point); //punctul point apartine centroidului cu distanta cea mai mica
                pointToCentroidDistance.Add(min);  //retin distanta fiecarui punct fata de centroid
            }
        }

        private void DrawCentroidsAndTreirAssignPoints(Pen pen)
        {
            for (int i = 0; i < numberOfCentroids; i++)
            {
                Brush brush = new SolidBrush(centroids[i].Color);
                graph.FillEllipse(brush, centroids[i].Center.X + 300, 300 - centroids[i].Center.Y, 10, 10);
                foreach (var assignedPoint in centroids[i].AssignedPoints)
                {
                    pen = new Pen(centroids[i].Color);
                    graph.DrawRectangle(pen, assignedPoint.X + 300, 300 - assignedPoint.Y, 1, 1);
                }
            }
        }

        private void SimilarityBtn_Click(object sender, EventArgs e)
        {
            epochNumber = 0;
            mainPanel.Refresh();
            ComputeSimilarity();
            Pen pen = new Pen(Color.Black);
            InitializeGraph(graph, pen);
            DrawCentroidsAndTreirAssignPoints(pen);
        }

        private void ComputeCost()
        {
            epociLbl.Text = "Epoca: " + epochNumber.ToString();
            double costCopy = cost;
            cost = 0;
            for (int i = 0; i < points.Count; i++)
            {
                cost += pointToCentroidDistance[i];
            }
            costLbl.Text = "Cost: " + cost.ToString();
            if (cost != costCopy)
            {
                epochNumber++;
            }
            else
            {
                MessageBox.Show("Finish");
            }
        }

        private void CentruDeGreutate_Click(object sender, EventArgs e)
        {
            long sumX, sumY;
            mainPanel.Refresh();
            Pen pen = new Pen(Color.Black);
            InitializeGraph(graph, pen);
            for (int i = 0; i < numberOfCentroids; i++)
            {
                sumX = 0;
                sumY = 0;
                foreach (var assignedPoint in centroids[i].AssignedPoints)
                {
                    pen = new Pen(centroids[i].Color);
                    graph.DrawRectangle(pen, assignedPoint.X + 300, 300 - assignedPoint.Y, 1, 1);
                    sumX += assignedPoint.X;
                    sumY += assignedPoint.Y;
                }

                centroids[i].Center.X = (int)(sumX / centroids[i].AssignedPoints.Count);
                centroids[i].Center.Y = (int)(sumY / centroids[i].AssignedPoints.Count);
            }
            ComputeSimilarity();
            for (int i = 0; i < numberOfCentroids; i++)
            {
                Brush brush = new SolidBrush(centroids[i].Color);
                graph.FillEllipse(brush, centroids[i].Center.X + 300, 300 - centroids[i].Center.Y, 10, 10);
            }
            ComputeCost();
        }
    }
}