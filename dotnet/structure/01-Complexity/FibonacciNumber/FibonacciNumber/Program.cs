using System;

namespace FibonacciNumber
{
    class Program
    {
        /// <summary>
        /// 斐波那契数列
        /// 0 1 1 2 3 5 8 13..
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = 45;
            Timing("递归",()=> {
                Console.WriteLine($"第{n}个斐波那契数:{Fib1(n)}");
            });
            Timing("循环", () => {
                Console.WriteLine($"第{n}个斐波那契数:{Fib2(n)}");
            });
            Console.ReadKey();
        }
        /// <summary>
        /// 使用递归
        /// 缺点:当n变大时，性能直线下降
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fib1(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return Fib1(n - 1) + Fib1(n - 2);
        }
        /// <summary>
        /// 使用循环
        /// 优点:计算速度快
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fib2(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            long first = 0;
            long second = 1;
            for (int i = 0; i < n-1; i++)
            {
                long sum = first + second;
                first = second;
                second = sum;
            }
            return second;
        }
        public delegate void Calculate();
        public static void Timing(string title, Calculate calculate)
        {
            if (calculate == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(title))
            {
                title = "";
            }
            Console.WriteLine(title);
            Console.WriteLine($"开始:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            DateTime begin = DateTime.Now;
            calculate.Invoke();
            DateTime end = DateTime.Now;
            Console.WriteLine($"结束:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            double consume = (end - begin).TotalSeconds;
            Console.WriteLine($"耗时：{consume}秒");
            Console.WriteLine("---------------------------");
        }
    }
}
