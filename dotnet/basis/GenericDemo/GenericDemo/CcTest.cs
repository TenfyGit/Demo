using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDemo
{
    public class CcTest
    {
        public static void Show()
        {
            //协变
            ICustomerListOut<Bird> customerList1 = new CustomerListOut<Bird>();
            ICustomerListOut<Bird> customerList2 = new CustomerListOut<Sparrow>();
            //逆变
            ICustomerListIn<Sparrow> customerList3 = new CustomerListIn<Sparrow>();
            ICustomerListIn<Sparrow> customerList4 = new CustomerListIn<Bird>();
        }
    }
    public class Bird
    {
        public int Id { get; set; }
    }
    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// out 协变 只能是返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T>
    {
        T Get();
    }
    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }
    }
    /// <summary>
    /// in 逆变 只能是参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListIn<in T>
    {
        void Show(T t);
    }
    public class CustomerListIn<T> : ICustomerListIn<T>
    {
        public void Show(T t)
        {
        }
    }
}
