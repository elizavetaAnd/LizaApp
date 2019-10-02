using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LizaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int rowCount;
            int columnsCount;
            Console.WriteLine("Введите количество строк (целое число)");
            string rowCountString = Console.ReadLine();

            if (Int32.TryParse(rowCountString, out rowCount))
            {
                if (rowCount > 0)
                {
                    Console.WriteLine("Введите количество столбцов (целое число)");
                    string columnsCountString = Console.ReadLine();
                    if (Int32.TryParse(columnsCountString, out columnsCount))
                    {
                        if (columnsCount > 0)
                        {
                            //Создаем матрицу
                            int[,] matr = new int[rowCount, columnsCount];

                            //Инициализируем матрицу
                            matrInit(matr, rowCount, columnsCount);

                            //Вывод получившейся матрицы
                            Console.WriteLine("Исходная матрица");
                            matrOutput(matr, rowCount, columnsCount);

                            int[] sum = new int[columnsCount];
                            for (int i = 0; i < columnsCount; i++)
                            {
                                for (int j = 0; j < rowCount; j++)
                                {
                                    if ((matr[j, i] < 0) && (matr[j, i] % 2 != 0))
                                    {
                                        sum[i] += Math.Abs(matr[j, i]);
                                    } 
                                }
                            }

                            //мы сравниваем элементы в массиве sum. Если sum[i] (текущий элемент) > sum[j] (следующий элемент, т.к. j = i+1), то мы переставляем столбцы в матрице
                            for (int i = 0; i < rowCount; i++)
                            {
                                for (int j = i + 1; j < sum.Length; j++)
                                {
                                    //Наше условие, описанное в предудущем комментарии
                                    if (sum[i] > sum[j])
                                    {
                                        //Переставляем столбцы в матрице
                                        for (int m = 0; m < rowCount; m++)
                                        {
                                            int buffer = matr[m, i];
                                            matr[m, i] = matr[m, j];
                                            matr[m, j] = buffer;
                                        }

                                    }
                                }
                            }

                            Console.WriteLine("Новая матрица");
                            matrOutput(matr, rowCount, columnsCount);

                            //Считаем сумму, если в столбце есть хотя бы 1 отрицательный элемиент
                            bool[] sumIsHasOtr = new bool[rowCount];
                            for (int i = 0; i < columnsCount; i++)
                            {
                                for (int j = 0; j < rowCount; j++)
                                {
                                    
                                    if (matr[j, i] < 0)
                                    {
                                        sumIsHasOtr[j] = true;
                                    }
                                }
                            }
                           
                            int[] sum2 = new int[columnsCount];
                            for (int i = 0; i < rowCount; i++)
                            {
                                for (int j = 0; j < columnsCount; j++)
                                {
                                    if (sumIsHasOtr[j] == true)
                                    {
                                       
                                        sum2[j] += matr[i, j];
                                    }
                                }
                            }

                            //Вывод сумм
                            Console.WriteLine("Сумма элементов в тех столбцах, где есть отрицательные элементы");

                            foreach (int el in sum2)
                            {
                                Console.WriteLine(el);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Не может быть отрицательным");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }
                else
                {
                    Console.WriteLine("Не может быть отрицательным");

                }

            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
            Console.ReadLine();
        }

        static  void  matrInit(int[,]matr, int rowCount, int columnsCount)
        {
            Random random = new Random();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    matr[i, j] = random.Next(-10, 10);
                }
            }
        }

        static void matrOutput(int[,] matr, int rowCount, int columnsCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    Console.Write("{0}\t", matr[i, j]); 
                }
                Console.WriteLine();
            }
        }
    }
}
