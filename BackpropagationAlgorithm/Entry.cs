namespace BackpropagationAlgorithm
{
    public class Entry<T>
    {
        public T Value { get; set; }
        public double[] Weights { get; set; }

        public Entry(T value, double[] weights)
        {
            Value = value;
            Weights = new double[weights.Length];
            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }
    }
}