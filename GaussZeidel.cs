using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCKP
{
    public class GaussZeidel
    {
        public static double epsilon = 0.01; //точность вычисления
        public int n, k, N; //N -допустимое число итераций, n - размерность квадратной матрицы коэффицентов, k-количество итераций
        public double s, Xi, diff = 1; //s - сумма, величина погрешности
        public double[,] matrix; //матрица коэффицентов
        public double[] value; //матрица значений
        public double[] roots; //матрица корней
        public bool diagonal;

        public GaussZeidel(double[,] matrix, double[] value, int N, int n, double[] roots)
        {
            this.matrix = matrix;
            this.N = N;
            this.value = value;
            this.n = n;
            this.roots = roots;
        }

        public bool DiagonallyDominant()
        {
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(matrix[i, j]);
                    }
                }
                if (Math.Abs(matrix[i, i]) >= sum)
                {
                    diagonal = true;
                    break;
                }
                else
                {
                    diagonal = false;
                }
            }
            return diagonal;
        }

        public void algoritm()
        {
            k = 0;
            while ((k <= N) && (diff >= epsilon))
            {
                k = k + 1;
                for (int i = 0; i < n; i++)
                {
                    s = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            s += matrix[i, j] * roots[j];
                        }
                    }
                    Xi = (value[i] - s) / matrix[i, i];
                    diff = Math.Abs(Xi - roots[i]);
                    roots[i] = Xi;
                }
            }
        }
    }
}
