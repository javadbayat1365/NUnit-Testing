namespace CustomerPro
{
    public class Calculator
    {
        public int Discount = 10;
        private List<int> ListOdd = new List<int>() {3,5,7 };
        public int AddNumbers(int a,int b)
        {
            return a + b;
        }
        public bool IsOddNumber(int a)
        {
            return a % 2 != 0;
        }
        public bool IsEvenNumber(int a)
        {
            return a % 2 == 0;
        }

        public double SumDoubles(double a,double b)
        {
            return a + b;
        }

        public List<int> GetRangeOfOddNumbers(int min,int max)
        {
            ListOdd.Clear();
            for (int i = min; i <= max; i++)
            {
                if (i % 2 != 0)
                {
                    ListOdd.Add(i);
                }
            }
            return ListOdd;
        }
    }
}