using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SOMAlgorithm
{
    public partial class MainForm : Form
    {
        private List<Point> points;
        private readonly Graphics graph;
        private Neuron[,] neurons; //w
        private int epochNumber;
        private double alpha;
        private double v; //vecinatate
        private double epoch;

        public MainForm()
        {
            InitializeComponent();
            graph = mainPanel.CreateGraphics();
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\generatedPoints.txt");
            points = GetThePoints(reader);
            neurons = new Neuron[10, 10];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void InitializeNeurons()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    neurons[i, j] = new Neuron(-300 + i * 60 + 30, -300 + j * 60 + 30);
                }
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

        private void DrawPoints(Graphics graph)
        {
            Pen pen = new Pen(Color.Black);
            foreach (var point in points)
            {
                graph.DrawRectangle(pen, point.X + 300, 300 - point.Y, 1, 1);
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            InitializeGraph(graph, pen);
            DrawPoints(graph);
            InitializeNeurons();
            alpha = 1;
            v = 1;
            epoch = 0;
        }

        private void DrawLinks(Pen pen)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (j + 1 < 10)
                    {
                        graph.DrawLine(pen, 300 + (int)neurons[i, j].X, 300 - (int)neurons[i, j].Y, 300 + (int)neurons[i, j + 1].X, 300 - (int)neurons[i, j + 1].Y);
                    }
                    if (i + 1 < 10)
                    {
                        graph.DrawLine(pen, 300 + (int)neurons[i, j].X, 300 - (int)neurons[i, j].Y, 300 + (int)neurons[i + 1, j].X, 300 - (int)neurons[i + 1, j].Y);
                    }
                    if (j - 1 >= 0)
                    {
                        graph.DrawLine(pen, 300 + (int)neurons[i, j].X, 300 - (int)neurons[i, j].Y, 300 + (int)neurons[i, j - 1].X, 300 - (int)neurons[i, j - 1].Y);
                    }
                    if (i - 1 >= 0)
                    {
                        graph.DrawLine(pen, 300 + (int)neurons[i, j].X, 300 - (int)neurons[i, j].Y, 300 + (int)neurons[i - 1, j].X, 300 - (int)neurons[i - 1, j].Y);
                    }
                }
            }
        }

        private void ComputeBtn_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Purple);
            Pen pen1 = new Pen(Color.Black);
            epochNumber = 10;
            while (alpha > 0.0001)
            {
                epoch++;
                mainPanel.Refresh();
                InitializeGraph(graph, pen);
                DrawLinks(pen);
                for (int i = 0; i < 5000; i++)
                {
                    graph.DrawEllipse(pen1, points[i].X + 300, 300 - points[i].Y, 1, 1);
                    double max = Int32.MaxValue, dist;
                    int indexInvingatorX = -1, indexInvingatorY = -1;

                    //matricea neuronilor
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            dist = Math.Sqrt(Math.Pow(points[i].X - neurons[j, k].X, 2) + Math.Pow(points[i].Y - neurons[j, k].Y, 2));
                            if (dist < max)
                            {
                                max = dist;
                                indexInvingatorX = j;
                                indexInvingatorY = k;
                            }
                        }
                    }

                    v = 6.1 * Math.Pow(Math.E, -(epoch / epochNumber));
                    alpha = 0.7 * Math.Pow(Math.E, -(epoch / epochNumber));

                    int vec = Convert.ToInt32(v), minX, maxX, minY, maxY;
                    //limitele intervalului care e considerata vecinatatea neuronului invingator
                    minX = indexInvingatorX - vec;
                    maxX = indexInvingatorX + vec;
                    minY = indexInvingatorY - vec;
                    maxY = indexInvingatorY + vec;

                    if (minX < 0) minX = 0;
                    if (minY < 0) minY = 0;
                    if (maxX > 9) maxX = 9;
                    if (maxY > 9) maxY = 9;

                    for (int j = minY; j <= maxY; j++)
                    {
                        for (int k = minX; k <= maxX; k++)
                        {
                            if (j != neurons[indexInvingatorY, indexInvingatorX].Y && k != neurons[indexInvingatorY, indexInvingatorX].X)
                                neurons[j, k].X = neurons[j, k].X + alpha * (points[i].X - neurons[j, k].X);
                            neurons[j, k].Y = neurons[j, k].Y + alpha * (points[i].Y - neurons[j, k].Y);
                        }
                    }
                }
                epochNumberLbl.Text = epoch.ToString();
                epochNumberLbl.Refresh();
                AlphaNumberLbl.Text = alpha.ToString();
                AlphaNumberLbl.Refresh();
                VNumberLbl.Text = v.ToString();
                VNumberLbl.Refresh();
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void totalEpochNumberLbl_Click(object sender, EventArgs e)
        {
        }
    }
}