using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab1
{
    class Vector
    {
        /// <summary>
        /// Коэффициенты вектора
        /// </summary>
        public double[] Coeff
        {
            get;
            private set;
        }

        /// <summary>
        /// Длина вектора
        /// </summary>
        public readonly int N;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coeff">Коэффициенты</param>
        /// <param name="n">Размерность</param>
        public Vector(double[] coeff, int n)
        {
            Coeff = coeff;
            N = n;
        }

        /// <summary>
        /// Загрузка вектора из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="n">Размерность</param>
        /// <returns>Вектор</returns>
        public static Vector Load(string path, int n)
        {
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("windows-1251"));

            double[] coeff = new double[n];
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();
                if (line.Length > 0)
                {
                    string[] parts = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < n; i++)
                    {
                        coeff[i] = double.Parse(parts[i]);
                    }
                }
            }
            sr.Close();

            return new Vector(coeff, n);
        }

        /// <summary>
        /// Вывод на экране значений вектора
        /// </summary>
        /// <param name="eps">Точность</param>
        public void Print(double eps)
        {
            string outeps = "";
            for (; eps != 1; eps *= 10)
                outeps += "#";

            for (int i = 0; i < this.N; i++)
            {
                Console.WriteLine("{0:0." + outeps +"}", this.Coeff[i]);
            }
            Console.WriteLine();
        }
    }
}
