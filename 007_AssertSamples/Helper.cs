namespace _007_AssertSamples
{
    public class Helper
    {
        public static double GetSqrt(double value)
        {
            return Math.Sqrt(value);
        }

        public string SayHello(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Parameter name cannot be null!");
            }

            return "Hello " + name;
        }
    }
}
