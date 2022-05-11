using System;


namespace KCKP
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("-----------------------------------------------------------\nSolving systems of linear equations by Gauss-Seidel method\n-----------------------------------------------------------\nEnter dimension of the matrix:");
                    int n = int.Parse(Console.ReadLine());
                    double[,] a = new double[n, n];
                    double[] b = new double[n];
                    double[] x = new double[n]; //нулевые приближения
                    for (int i = 0; i < n; i++)
                    {
                        x[i] = 0;
                    }

                    Console.WriteLine("===========================================================\nTo enter data from the keyboard - press 1\nTo enter random data - press 2");
                    int key = int.Parse(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
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
                            }
                            break;
                        case 2:
                            {
                                Random r = new Random();
                                for (int i = 0; i < n; i++) //ввод коэффицентов
                                {
                                    for (int j = 0; j < n; j++)
                                    {
                                        a[i, j] = r.Next(-50, 50);
                                        Console.WriteLine("The element from position [" + (i + 1) + "," + (j + 1) + "]: " + a[i, j]);
                                    }
                                }

                                for (int j = 0; j < n; j++) //ввод значений
                                {
                                    b[j] = r.Next(-50, 50);
                                    Console.WriteLine("The value from position [" + (j + 1) + "]: " + b[j]);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Input error.\n===========================================================");
                            break;
                    }
                    Console.WriteLine("===========================================================");
                    GaussZeidel test = new GaussZeidel(a, b, 500, n, x);
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
                    Console.WriteLine("The number of iterations: " + test.k + "\n===========================================================\nPress Esc to exit or any key to continue");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
