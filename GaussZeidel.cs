using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCKP
{
    public class GaussZeidel
    {
        private static double epsilon = 0.01; //точность вычисления
        public int matrixSize, iteratnionNumber, N; //N -допустимое число итераций, matrixSize - размерность квадратной матрицы коэффицентов, iteratnionNumber-количество итераций
        public double s, Xi, diff = 1; //s - сумма, величина погрешности
        public double[,] matrix; //матрица коэффицентов
        public double[] value; //матрица значений
        public double[] roots; //матрица корней
        public bool diagonal;

        public static double Epsilon { get => epsilon; set => epsilon = value; }

        public GaussZeidel(double[,] matrix, double[] value, int N, int n, double[] roots)
        {
            this.matrix = matrix;
            this.N = N;
            this.value = value;
            this.matrixSize = n;
            this.roots = roots;
        }

        public bool DiagonallyDominant()
        {
            for (int i = 0; i < matrixSize; i++)
            {
                double sum = 0;
                for (int j = 0; j < matrixSize; j++)
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
            iteratnionNumber = 0;
            while ((iteratnionNumber <= N) && (diff >= Epsilon))
            {
                iteratnionNumber = iteratnionNumber + 1;
                for (int i = 0; i < matrixSize; i++)
                {
                    s = 0;
                    for (int j = 0; j < matrixSize; j++)
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
