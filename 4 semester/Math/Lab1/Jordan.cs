using System;
using System.Collections.Generic;

namespace Lab1
{
    class Jordan
    {
        private Matrix a_matrix;            // матрица коэффициентов A
        private Matrix a_inverse;           // матрица коэффициентов A
        private Vector x_vector;            // вектор неизвестных x
        private Vector b_vector;            // вектор B
        private double eps;                 // точность 
        private int size;                   // размерность 

        /// <summary>
        /// Решение
        /// </summary>
        /// <param name="slae">СЛАУ</param>
        /// <param name="eps">Точность</param>
        public void SolveWithoutInvertible(SLAE slae, double eps)
        {
            a_matrix = slae.A;
            x_vector = slae.X;
            b_vector = slae.B;
            this.eps = eps;
            this.size = b_vector.N;
            int[] index = InitIndex();
            JordanWithoutInvertible(index);
        }

        /// <summary>
        /// Решение
        /// </summary>
        /// <param name="slae">СЛАУ</param>
        /// <param name="eps">Точность</param>
        public Matrix SolveWithInvertible(SLAE slae, double eps)
        {
            a_matrix = slae.A;
            x_vector = slae.X;
            b_vector = slae.B;
            this.eps = eps;
            this.size = b_vector.N;
            int[] index = InitIndex();

            JordanWithInvertible(index);
            slae.X = x_vector;
            return a_inverse;
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
        /// Прямой ход
        /// </summary>
        /// <param name="index">Массив индексов</param>
        private int JordanWithInvertible(int[] index)
        {
            double[,] inverse_matrix = new double[size, size];
            for (int i = 0; i < size; i++)
                inverse_matrix[i, i] = 1;

            for (int i = 0; i < size; ++i)
            {
                double r = 0;
                try
                {
                    r = FindStart(i, index);
                    if (r == 0)
                        throw new Exception("Система уравнений не имеет решений");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }

                // Делим главную строку на разрешающий элемент
                for (int j = 0; j < size; ++j)
                {
                    a_matrix.Coeff[i, j] /= r;
                    inverse_matrix[i, j] /= r;
                }

                // Отнимаем строку из всех строк выше главной
                for (int k = 0; k < i; ++k)
                {
                    double p = a_matrix.Coeff[k, index[i]];
                    for (int j = 0; j < size; ++j)
                    {
                        a_matrix.Coeff[k, index[j]] -= a_matrix.Coeff[i, index[j]] * p;
                        inverse_matrix[k, index[j]] -= inverse_matrix[i, index[j]] * p;
                    }
                }

                // Отнимаем строку из всех строк ниже главной
                for (int k = i + 1; k < size; ++k)
                {
                    double p = a_matrix.Coeff[k, index[i]];
                    for (int j = 0; j < size; ++j)
                    {
                        a_matrix.Coeff[k, index[j]] -= a_matrix.Coeff[i, index[j]] * p;
                        inverse_matrix[k, index[j]] -= inverse_matrix[i, index[j]] * p;
                    }
                    a_matrix.Coeff[k, index[i]] = 0.0;
                }
            }
            a_inverse = new Matrix(inverse_matrix, a_matrix.N);

            // Матричный метод
            double[] result = new double[size];
            for (int i = 0; i < size; i++)
            {
                double temp = 0;
                for (int j = 0; j < size; j++)
                {
                    temp += a_inverse.Coeff[i, j] * b_vector.Coeff[j];
                }
                result[i] = temp;
            }
            x_vector = new Vector(result, size);

            return 0;
        }

        /// <summary>
        /// Прямой ход методом Гаусса-Жордана без нахождения обратной матрицы
        /// </summary>
        /// <param name="index">Массив индексов</param>
        private void JordanWithoutInvertible(int[] index)
        {
            for (int i = 0; i < size; ++i)
            {
                double r = FindStart(i, index);

                for (int j = 0; j < size; ++j)
                    a_matrix.Coeff[i, j] /= r;

                b_vector.Coeff[i] /= r;

                for (int k = 0; k < i; ++k)
                {
                    double p = a_matrix.Coeff[k, index[i]];
                    for (int j = i; j < size; ++j)
                        a_matrix.Coeff[k, index[j]] -= a_matrix.Coeff[i, index[j]] * p;
                    b_vector.Coeff[k] -= b_vector.Coeff[i] * p;
                    a_matrix.Coeff[k, index[i]] = 0.0;
                }

                for (int k = i + 1; k < size; ++k)
                {
                    double p = a_matrix.Coeff[k, index[i]];
                    for (int j = i; j < size; ++j)
                        a_matrix.Coeff[k, index[j]] -= a_matrix.Coeff[i, index[j]] * p;
                    b_vector.Coeff[k] -= b_vector.Coeff[i] * p;
                    a_matrix.Coeff[k, index[i]] = 0.0;
                }
            }

            for (int i = size - 1; i >= 0; --i)
            {
                double x_i = b_vector.Coeff[i];

                for (int j = i + 1; j < size; ++j)
                    x_i -= x_vector.Coeff[index[j]] * a_matrix.Coeff[i, index[j]];
                x_vector.Coeff[index[i]] = x_i;
            }
        }
    }
}