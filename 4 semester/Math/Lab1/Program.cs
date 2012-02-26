using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int K = 5;
            Matrix A = Matrix.LoadSpecial("D:\\C.txt", "D:\\D.txt", K);
            Vector b = Vector.Load("D:\\vector.txt", A.N);
            Vector x = new Vector(new double[A.N], A.N);
            SLAE slae1 = new SLAE(A, b, x);
            SLAE slae2 = new SLAE(A, b, x);
            SLAE slae3 = new SLAE(A, b, x);
            SLAE slae4 = new SLAE(A, b, x);
            double eps = 0.0001;
            Gauss gauss = new Gauss();
            Jordan jordan = new Jordan();

            DateTime time1before = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                 new Gauss().Solve(new SLAE(A, b, x), eps, false);
            }
            DateTime time1after = DateTime.Now;

            DateTime time2before = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                new Gauss().Solve(new SLAE(A, b, x), eps, true);
            }
            DateTime time2after = DateTime.Now;

            DateTime time3before = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                new Jordan().SolveWithoutInvertible(new SLAE(A, b, x), eps);
            }
            DateTime time3after = DateTime.Now;

            DateTime time4before = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                new Jordan().SolveWithInvertible(new SLAE(A, b, x), eps);
            }
            DateTime time4after = DateTime.Now;

            Console.WriteLine("1) Решение СЛАУ методом Гаусса с выбором первого элемента");
            double det = gauss.Solve(slae1, eps, false);
            Console.WriteLine("Матрица А:");
            slae1.A.Print(eps);
            Console.WriteLine("Вектор X:");
            slae1.X.Print(eps);
            Console.WriteLine("Определитель = {0}\n", det);

            Console.WriteLine("2) Решение СЛАУ методом Гаусса с выбором элемента по матрице");
            gauss.Solve(slae2, eps, true);
            Console.WriteLine("Матрица А:");
            slae2.A.Print(eps);
            Console.WriteLine("Вектор X:");
            slae2.X.Print(eps);

            Console.WriteLine("3) Решение СЛАУ методом Гаусса-Жордана без нахождения обратной матрицы");
            jordan.SolveWithoutInvertible(slae3, eps);
            Console.WriteLine("Матрица А:");
            slae3.A.Print(eps);
            Console.WriteLine("Вектор X:");
            slae3.X.Print(eps);

            if (det != 0)
            {
                Console.WriteLine("4) Решение СЛАУ методом Гаусса-Жордана с нахождением обратной матрицы");
                Matrix inverse = jordan.SolveWithInvertible(slae4, eps);
                Console.WriteLine("Матрица А:");
                slae4.A.Print(eps);
                Console.WriteLine("Вектор X:");
                slae4.X.Print(eps);
                Console.WriteLine("Обратная матрица:");
                inverse.Print(eps);
            }

            Console.WriteLine("Время выполнения методов (повторено 100000 раз):");
            Console.WriteLine("Time 1 : {0}", time1after - time1before);
            Console.WriteLine("Time 2 : {0}", time2after - time2before);
            Console.WriteLine("Time 3 : {0}", time3after - time3before);
            Console.WriteLine("Time 4 : {0}", time4after - time4before);
            Console.ReadKey();
        }
    }
}
