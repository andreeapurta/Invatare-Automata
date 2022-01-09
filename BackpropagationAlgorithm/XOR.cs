namespace BackpropagationAlgorithm
{
    public class XOR
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Result { get; set; }

        public XOR(double x1, double x2, double result)
        {
            X1 = x1;
            X2 = x2;
            Result = result;
        }
    }
}