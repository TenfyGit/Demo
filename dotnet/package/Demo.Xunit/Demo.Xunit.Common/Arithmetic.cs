using System;

namespace Demo.Xunit.Common
{
    public class Arithmetic
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }
        public int Divide(int n1, int n2)
        {
            if (n2 == 0)
            {
                throw new Exception("除数不能为零");
            }
            return n1 / n2;
        }
    }
}
