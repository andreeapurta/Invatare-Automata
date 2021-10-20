using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Invatare_Automata
{
    public partial class MainForm : Form
    {
        private const int numberOfPoints = 5000;
        private readonly Random random;

        public List<Area> Areas { get; set; }
        public List<Tuple<int, int, Color>> Points { get; set; }

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            Points = new List<Tuple<int, int, Color>>();
            GenerateRandomZones();
            Compute();
        }

        public void Compute()
        {
            File.Delete(Directory.GetCurrentDirectory() + @"\generatedPoints.txt");
            StreamWriter writer =
                new StreamWriter(Directory.GetCurrentDirectory() + @"\generatedPoints.txt", true);

            for (int i = 1; i <= numberOfPoints; i++)
            {
                //Pas 0 - alegem o zona random
                int randomZoneNumber = random.Next(0, 4);
                var selectedArea = Areas[randomZoneNumber];

                int coordX = GenerateCoordinate(selectedArea.X, selectedArea.SigmaX);
                int coordY = GenerateCoordinate(selectedArea.Y, selectedArea.SigmaY);

                var point = Tuple.Create(coordX, coordY, selectedArea.Color);
                Points.Add(point);

                WriteToFile(writer, coordX, coordY, selectedArea.Color, selectedArea.Name);
            }
            writer.Close();
        }

        private void drawGraphMenuItem_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black);

            pen.Width = 1;
            Graphics graph = graphPanel.CreateGraphics();

            // x
            graph.DrawLine(pen, 0, 300, 600, 300);

            // y
            graph.DrawLine(pen, 300, 600, 300, 0);

            //draw points
            DrawPoints(graph, pen);
        }

        private void DrawPoints(Graphics graph, Pen pen)
        {
            foreach (var point in Points)
            {
                pen.Color = point.Item3;
                graph.DrawRectangle(pen, point.Item1 + 300, 300 - point.Item2, 1, 1);
            }
        }

        private int GenerateCoordinate(int coordinate, int sigma)
        {
            double p; //Prag
            double gauss;
            int generatedCoordinate;
            do
            {
                //Pas1: alegem aleator x in intervalul [-300, 300]
                generatedCoordinate = random.Next(-300, 300);
                //Pas2: gauss

                gauss = GetGaussPorbability(coordinate, sigma, generatedCoordinate);
                if (gauss == 0)
                {
                    labelZero.Text = "Gaus e 0";
                }
                //Pas3: alegem aleator p din intervalul [0, 1]
                p = Math.Round(random.NextDouble(), 3);
            } while (gauss < p); //daca G(x) > p, acceptam x, altfel se reia de la pasul 2.

            return generatedCoordinate;
        }

        private void GenerateRandomZones()
        {
            Areas = new List<Area>() {
                new Area("Area 1", 250, 150, 30,10, Color.Red),
                new Area("Area 2", -200, -200, 15, 10,Color.Orange),
                new Area("Area 3",-220, 20, 20, 5, Color.MediumPurple),
                new Area("Area 4", 50, -200, 15, 50, Color.Blue),
            };
        }

        /// <summary>
        /// //G(X) = e ^ -(((m-x)^2)/2*deviation^2), G(x) apartine intervalului (0, 1]
        /// </summary>
        private double GetGaussPorbability(int m, int sigma, int x)
        {
            double gauss;
            double impartitor = Math.Pow(m - x, 2); //(m-x)^2)
            double deImpartit = 2 * Math.Pow(sigma, 2); //2*deviation^2
            double fraction = impartitor / deImpartit;
            fraction = fraction * -1;
            gauss = Math.Exp(fraction);
            return gauss;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void WriteToFile(StreamWriter writer, int coordX, int coordY, Color color, string selectedArea)
        {
            writer.WriteLine(coordX.ToString() + "  " + coordY + "  " + color.Name + "  " + selectedArea);
        }
    }
}