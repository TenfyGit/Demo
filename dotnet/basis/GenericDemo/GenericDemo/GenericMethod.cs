using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDemo
{
    /// <summary>
    /// 泛型方法
    /// </summary>
    public class GenericMethod
    {
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), tParameter.GetType().Name, tParameter.ToString());
        }
    }
}
