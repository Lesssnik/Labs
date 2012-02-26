using System;
using System.Collections.Generic;

namespace Lab1
{
    class Gauss
    {
        private Matrix a_matrix;            // матрица коэффициентов A
        private Vector x_vector;            // вектор неизвестных x
        private Vector b_vector;            // вектор B
        private double eps;                 // точность 
        private int size;                   // размерность 
        public double det                   // определитель
        {
            get;
            private set;
        }

        /// <summary>
        /// Решение
        /// </summary>
        /// <param name="slae">СЛАУ</param>
        /// <param name="eps">Точность</param>
        /// <param name="isMax">Использовать ли поиск по всей матрице?</param>
        /// <returns>Определитель матрицы</returns>
        public double Solve(SLAE slae, double eps, bool isMax)
        {
            double result = 0;
            a_matrix = slae.A;
            x_vector = slae.X;
            b_vector = slae.B;
            this.eps = eps;
            this.size = b_vector.N;
            int[] index = InitIndex();

            int isOk = GaussSolve(index, isMax);
            if (isOk != -1)
            {
                det = FindDeterminant();
                result = det;
            }

            return result;
        }

        /// <summary>
        /// Инициализация массива индексов столбцов
        /// </summary>
        /// <returns>Массив индексов</returns>
        private int[] InitIndex()
        {
            int[] index = new int[size];
            for (int i = 0; i < index.Length; ++i)
                index[i] = i;
            return index;
        }

        /// <summary>
        /// Поиск главного элемента
        /// </summary>
        /// <param name="row">Номер текущей строки</param>
        /// <param name="index">Массив индексов</param>
        /// <returns>Элемент</returns>
        private double FindStart(int row, int[] index)
        {
            double max = a_matrix.Coeff[row, index[row]];
            int max_index = row;

            while (max_index < size)
            {
                if (max != 0)
                {
                    try
                    {
                        if (Math.Abs(max) < eps)
                        {
                            if (Math.Abs(b_vector.Coeff[row]) > eps)
                                throw new Exception("Система уравнений не имеет решений");
                            else
                                throw new Exception("Система уравнений имеет множество решений");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    int temp = index[row];
                    index[row] = index[max_index];
                    index[max_index] = temp;
                    return max;
                }
                else
                {
                    max = a_matrix.Coeff[max_index, index[row]];
                    max_index++;
                }
            }
            return 0;
        }

        /// <summary>
        /// Поиск главного элемента в матрице
        /// </summary>
        /// <param name="row">Номер строки, в которой будем вести поиск</param>
        /// <param name="index">Массив индексов элементов</param>
        /// <returns>Элемент</returns>
        private double FindMax(int row, int[] index)
        {
            int max_index = row;
            double max = a_matrix.Coeff[row, index[max_index]];
            double max_abs = Math.Abs(max);
            for (int current_index = row + 1; current_index < size; ++current_index)
            {
                double cur = a_matrix.Coeff[row, index[current_index]];
                double cur_abs = Math.Abs(cur);
                if (cur_abs > max_abs)
                {
                    max_index = current_index;
                    max = cur;
                    max_abs = cur_abs;
                }
            }
            try
            {
                if (max_abs < eps)
                {
                    if (Math.Abs(b_vector.Coeff[row]) > eps)
                        throw new Exception("Система уравнений не имеет решений");
                    else
                        throw new Exception("Система уравнений имеет множество решений");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            int temp = index[row];
            index[row] = index[max_index];
            index[max_index] = temp;

            return max;
        }

        /// <summary>
        /// Прямой ход
        /// </summary>
        /// <param name="index">Массив индексов</param>
        private int GaussSolve(int[] index, bool isMax)
        {
            for (int i = 0; i < size - 1; ++i)
            {
                double r = 0;
                try
                {
                    if (isMax == true)
                        r = FindMax(i, index); // Находим главный элемент
                    else r = FindStart(i, index);
                    if (r == 0)
                        throw new Exception("Система уравнений не имеет решений");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }

                for (int k = i + 1; k < size; ++k)  // Вычитаем текущую строку из следующих далее
                {
                    double p = a_matrix.Coeff[k, index[i]];
                    for (int j = i; j < size; ++j)
                        a_matrix.Coeff[k, index[j]] -= a_matrix.Coeff[i, index[j]] * (p / r); // Получаем элемент матрицы А
                    b_vector.Coeff[k] -= b_vector.Coeff[i] * (p / r); // Получаем элемент вектора В
                }
            }

            for (int i = size - 1; i >= 0; --i)
            {
                double x_temp = b_vector.Coeff[i]; // Задаем начальное значение
                for (int j = i + 1; j < size; ++j)  // Получаем результат 
                    x_temp -= x_vector.Coeff[index[j]] * a_matrix.Coeff[i, index[j]];
                x_temp /= a_matrix.Coeff[i, i];
                x_vector.Coeff[index[i]] = x_temp; // Сохраняем результат в вектор Х
            }
            return 0;
        }

        /// <summary>
        /// Вычисление определителя матрицы после приведения ее к диагональному виду
        /// </summary>
        /// <returns>Определитель</returns>
        private double FindDeterminant()
        {
            double det = a_matrix.Coeff[0, 0];
            for (int i = 1; i < size; i++)
            {
                det *= a_matrix.Coeff[i, i];
            }
            return det;
        }
    }
}