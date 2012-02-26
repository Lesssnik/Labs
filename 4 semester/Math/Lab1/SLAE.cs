using System;

namespace Lab1
{
    class SLAE
    {
        public Matrix A;
        public Vector X;
        public Vector B;

        public SLAE(Matrix a, Vector b, Vector x)
        {
            double[,] a_temp = new double[a.N, a.N];
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < a.N; j++)
                    a_temp[i, j] = a.Coeff[i, j];
            A = new Matrix(a_temp, a.N);

            double[] b_temp = new double[b.N];
            for (int i = 0; i < b.N; i++)
                    b_temp[i] = b.Coeff[i];
            B = new Vector(b_temp, b.N);

            double[] x_temp = new double[x.N];
            for (int i = 0; i < x.N; i++)
                x_temp[i] = x.Coeff[i];
            X = new Vector(x_temp, x.N);
        }
    }
}
