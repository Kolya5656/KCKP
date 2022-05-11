using System;


namespace KCKP
{
    class Program
    {
        static void Main(string[] args)
        {


            //int n = int.Parse(Console.ReadLine());
            int n = 0;
            double[,] a = new double[n, n];
            double[] b = new double[n];
            double[] x = new double[n]; //нулевые приближения

            void ClearX()
            {
                for (int i = 0; i < n; i++)
                {
                    x[i] = 0;
                }
            }

            //ClearX();

            //Console.WriteLine("===========================================================\nTo enter data from the keyboard - press 1\nTo enter random data - press 2");

            int key = int.Parse(Console.ReadLine());


            void ArrayFilling(double[,] array)
            {
                for (int i = 0; i < n; i++) //ввод коэффицентов
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Enter the element from position [" + (i + 1) + "," + (j + 1) + "]:");
                        a[i, j] = double.Parse(Console.ReadLine());
                    }
                }

                for (int j = 0; j < n; j++) //ввод значений
                {
                    Console.WriteLine("Enter the value from position [" + (j + 1) + "]:");
                    b[j] = double.Parse(Console.ReadLine());
                }
            };
            //ArrayFilling();

            GaussZeidel test = new(a, b, 500, n, x);
            bool IsDiagonal = test.DiagonallyDominant();
            if (IsDiagonal == true)
            {
                Console.WriteLine("The matrix has the property of diagonal dominance\n===========================================================");
            }
            else
            {
                Console.WriteLine("The matrix does not have the property of diagonal dominance\n===========================================================");
            }
            test.algoritm();
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine("X" + (j + 1) + " = " + test.roots[j]);
            }
            Console.WriteLine("The number of iterations: " + test.iteratnionNumber + "\n===========================================================\nPress Esc to exit or any key to continue");


        }
    }
}
