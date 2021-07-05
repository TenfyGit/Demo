using Demo.Xunit.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Xunit.Test.Common
{
    public class ArithmeticTest
    {
        [Fact]//需要在测试方法上加上特性Fact
        public void Add_NotInput_True()
        {
            //Arrange
            Arithmetic arithmetic = new Arithmetic();
            //Act
            int sum = arithmetic.Add(1, 2);
            //Assert
            Assert.True(sum == 3);
        }
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(2, 4, 6)]
        [InlineData(2, 5, 7)]
        public void Add_InputTwoNumber_True(int n1, int n2, int result)
        {
            //Arrange
            Arithmetic arithmetic = new Arithmetic();
            //Act
            int sum = arithmetic.Add(n1, n2);
            //Assert
            Assert.True(sum == result);
        }
        [Theory]
        [InlineData(2,0)]
        public void Divide_InputZero_ThrowException(int n1, int n2)
        {
            //Arrange
            Arithmetic arithmetic = new Arithmetic();
            //Act,Assert
            Assert.Throws<Exception>(() => {
                arithmetic.Divide(n1, n2);    
            });
        }
    }
}
