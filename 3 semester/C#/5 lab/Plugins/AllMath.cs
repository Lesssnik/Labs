using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Runtime.InteropServices;
using PluginHelper;

namespace LesnikPlugins
{
    [PluginHelper("AllMath", "Lesnik")]
    public class AllMath : IPlugin
    {
        private BigInteger a;
        private BigInteger b;
        private BigInteger Result;

        public AllMath()
        {
            a = 0;
            b = 0;
            Result = 0;
        }

        public AllMath(BigInteger a, BigInteger b)
        {
            this.a = a;
            this.b = b;
            Result = 0;
        }

        public void ChangeNumbers(BigInteger a, BigInteger b)
        {
            this.a = a;
            this.b = b;
            Result = 0;
        }

        public void Add()
        {
            Result = a + b;
        }

        public void Sub()
        {
            Result = a - b;
        }

        public void Mul()
        {
            Result = a * b;
        }

        public void Div()
        {
            Result = a / b;
        }

        public void Ost()
        {
            Result = a % b;
        }

        public void Pow(BigInteger n)
        {
            Result = n * n;
        }

        public string WriteResult()
        {
            return Result.ToString();
        }
    }
}