using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDemo
{
    public class GenericDelegate
    {
        public delegate void SayHi<T>(T t);
    }
}
