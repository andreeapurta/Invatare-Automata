using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KMeansAlgorithm
{
    /// <summary>
    /// Descriere algoritm.
    /// Similaritatea elementelor dintr-un cluster Ci se calculează raportat la centrul de
    /// greutate al clusterului.Algoritmul de clustering se bazează pe ideea că se poziționează în spațiul de
    /// reprezentarea al datelor de antrenament un număr de centroizi, iar aceștia în procesul de învățare vor
    ///încerca să-și găsească pozițiile optime care vor caracteriza cel mai bine toate datele de antrenament.
    /// Etape:
    ///1. Generăm un număr de centre de clase(centroizi) aleator k ∈ [2,10]
    ///2. ”Așezăm” centroizii aleator în spațiul de reprezentare al datelor de intrare
    ///3. Grupăm toate exemplele de intrare la câte un centroid astfel:
    ///Calculăm similaritate între un exemplu de intrare și toți centroizii
    ///Grupăm exemplul de intrare la centroidul cu care este cel mai similar
    ///4. Calculăm centrul de greutate al tuturor exemplelor atribuite la un centriod(toate exemplele atribuite
    ///la un centroid formează un cluster)
    ///5. Mutăm centroidul în centrul de greutate calculat
    ///6. Calculăm funcția de convergență(unde p este un exemplu iar Ci este centrul de greutate)
    /// </summary>
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
                        distance = Math.Sqrt(Math.Pow(centroidCenterX - x, 2) + Math.Pow(centroidCenterY - y, 2));
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
            epochNumber = 0;
            cost = 0;
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

        /// <summary>
        /// //Step 3 : Compute similarity between points and centroids
        /// </summary>
        private void ComputeSimilarity()
        {
            //just in case
            foreach (var centroid in centroids)
            {
                centroid.AssignedPoints.Clear();
            }

            double distance;
            foreach (var point in points)
            {
                double min = Double.MaxValue;
                int centroidNr = 0; // to keep the index of the selected centroid
                for (int j = 0; j < numberOfCentroids; j++)
                {
                    distance = GetDistance(centroids[j].Center.X, point.X, centroids[j].Center.Y, point.Y); //euclidian
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

        /// <summary>
        /// //Step 6 - functia de convergenta /Dacă funcția de convergență nu se mai modifică putem
        /// spune că algoritmul s-a încheiat.///
        /// </summary>
        private void ComputeCost()
        {
            double costCopy = cost;
            cost = 0;
            costLbl.Text = "Cost: " + cost.ToString();

            for (int i = 0; i < pointToCentroidDistance.Count; i++)
            {
                cost += pointToCentroidDistance[i];
            }
            int centroidsWithPoints = 0;
            foreach (var centroid in centroids)
            {
                if (centroid.AssignedPoints.Count > 0)
                {
                    centroidsWithPoints++;
                }
            }
            //si toti centroizii au puncte
            if ((cost != costCopy) || (centroidsWithPoints == centroids.Length))
            {
                epochNumber++;
            }
            else
            {
                MessageBox.Show("Finish");
            }
            epociLbl.Text = "Epoca: " + epochNumber.ToString();
            costLbl.Text = "Cost: " + cost.ToString();
        }

        /// <summary>
        /// //Step 4 , 5 ///
        /// </summary>
        private void ComputeZonesBtn_Click(object sender, EventArgs e)
        {
            ComputeSimilarity();
            long sumX, sumY;
            mainPanel.Refresh();
            Pen pen = new Pen(Color.Black);
            InitializeGraph(graph, pen);
            for (int i = 0; i < numberOfCentroids; i++)
            {
                sumX = 0;
                sumY = 0;
                if (!centroids[i].AssignedPoints.Count.Equals(0)) //ca sa nu crepe la impartirea cu 0
                {
                    //calcul centru de greutate
                    foreach (var assignedPoint in centroids[i].AssignedPoints)
                    {
                        pen = new Pen(centroids[i].Color);
                        graph.DrawRectangle(pen, assignedPoint.X + 300, 300 - assignedPoint.Y, 1, 1);
                        sumX += assignedPoint.X;
                        sumY += assignedPoint.Y;
                    }
                    //mut centroidul în centrul de greutate calculat
                    centroids[i].Center.X = (int)(sumX / centroids[i].AssignedPoints.Count);
                    centroids[i].Center.Y = (int)(sumY / centroids[i].AssignedPoints.Count);
                }
                else
                {
                    centroids[i].Center.X = random.Next(-300, 300);
                    centroids[i].Center.Y = random.Next(-300, 300);
                }
            }
            //redraw centroids
            for (int i = 0; i < numberOfCentroids; i++)
            {
                Brush brush = new SolidBrush(centroids[i].Color);
                graph.FillEllipse(brush, centroids[i].Center.X + 300, 300 - centroids[i].Center.Y, 10, 10);
                graph.DrawEllipse(new Pen(Color.Black, 2), centroids[i].Center.X + 300, 300 - centroids[i].Center.Y, 10, 10);
            }
            ComputeCost();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}