using System;

namespace GenericDemo
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印个int值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }

        /// <summary>
        /// 打印个string值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);
        }

        /// <summary>
        /// 打印个object值
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter);
        }
    }
}
