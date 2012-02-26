using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab1
{
    class Matrix
    {
        /// <summary>
        /// Коэффициенты матрицы
        /// </summary>
        public readonly double[,] Coeff;

        /// <summary>
        /// Количество строк и столбцов матрицы
        /// </summary>
        public readonly int N;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coeff">Коэффициенты</param>
        /// <param name="n">Размерность</param>
        public Matrix(double[,] coeff, int n)
        {
            Coeff = coeff;
            N = n;
        }

        /// <summary>
        /// Загрузка матрицы из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Матрица</returns>
        public static Matrix Load(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("windows-1251"));

            string first_line = sr.ReadLine().Trim();
            int n = int.Parse(first_line);
            double[,] coeff = new double[n, n];
            int j = 0;

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();
                if (line.Length > 0)
                {
                    string[] parts = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < parts.Length; i++)
                    {
                        coeff[j, i] = double.Parse(parts[i]);
                    }
                    j++;
                }
            }
            sr.Close();

            return new Matrix(coeff, n);
        }

        /// <summary>
        /// Загружает две матрицы и преобразует их в матрицу A
        /// </summary>
        /// <param name="path1">Путь к файлу с первой матрицей</param>
        /// <param name="path2">Путь к файлу со второй матрицей</param>
        /// <returns>Нужная матрица</returns>
        public static Matrix LoadSpecial(string path1, string path2, int k)
        {
            // Загрузка матрицы C
            StreamReader sr1 = new StreamReader(path1, Encoding.GetEncoding("windows-1251"));
            string first_line1 = sr1.ReadLine().Trim();
            int n1 = int.Parse(first_line1);
            double[,] C= new double[n1, n1];
            int j = 0;

            while (sr1.Peek() != -1)
            {
                string line = sr1.ReadLine().Trim();
                if (line.Length > 0)
                {
                    string[] parts = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < parts.Length; i++)
                    {
                        C[j, i] = double.Parse(parts[i]);
                    }
                    j++;
                }
            }
            sr1.Close();

            // Загрузка матрицы D
            StreamReader sr2 = new StreamReader(path2, Encoding.GetEncoding("windows-1251"));
            string first_line2 = sr2.ReadLine().Trim();
            int n2 = int.Parse(first_line2);
            double[,] D = new double[n2, n2];
            j = 0;
            while (sr2.Peek() != -1)
            {
                string line = sr2.ReadLine().Trim();
                if (line.Length > 0)
                {
                    string[] parts = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < parts.Length; i++)
                    {
                        D[j, i] = double.Parse(parts[i]);
                    }
                    j++;
                }
            }
            sr2.Close();

            // A = k*C + D
            double[,] A = new double[n1, n1];
            for (int i = 0; i < n1; i++)
                for (int p = 0; p < n1; p++)
                {
                    C[i, p] = C[i, p] * k;
                    A[i, p] = C[i, p] + D[i, p];
                }

            return new Matrix(A, n1);
        }

        /// <summary>
        /// Вывод матрицы на экран
        /// </summary>
        /// <param name="eps">Точность</param>
        public void Print(double eps)
        {
            string outeps = "";
            for (; eps != 1; eps *= 10)
                outeps += "#";

            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.N; j++)
                {
                    Console.Write("{0:0." + outeps +"}", this.Coeff[i, j]);
                    Console.Write('\t');
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }
    }
}
