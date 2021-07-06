using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static byte colIncome = 0; // Доход
        static byte colRate = 1; // Расход
        static byte colDetla = 2; // Колонка дельта (высчитываем)


        static public int[][] compare(int[] arrayIncoming, int[] arrayTax)
        {
            int[][] ret = new int[12][];

            for (int i = 0; i < 12; i++)
            {
                ret[i][colIncome] = arrayIncoming[i];
                ret[i][colRate] = arrayTax[i];

            }

            return ret;
        }
        public static void showMessage(string msg)
        {
            Console.WriteLine($"\n----------------------{msg}----------------");
        }
        static public void showFinanceStatics(int[][] ar) // высчитываем тут дельту потому что заказчик возможно захочет изменить какие-то суммы
                                                          // но возможно дельту расчитывать сразу при вводе
        {
            var delta = 0;
            // Колонки

            int[] newArray = new int[ar.Length];

            showMessage("Сортировка");
            // делаю строковые переменные, и за один проход заполняю список хороших/плохих месяцев продаж, сразу в строки, чтоб потом не обходить лишний раз массив
            string goodMonths = "";
            string badMonth = "";
            for (int i =0; i < ar.Length; i ++) // for (int i =0; i < 12; i ++)  - PS if array.lenght < 12 - execption
            {
                delta = ar[i][colIncome] - ar[i][colRate];
                ar[i][colDetla] = delta;
                if (delta > 0)
                {
                    goodMonths += goodMonths == "" ? "" : ",";
                    goodMonths += (i+1).ToString();
                }
                else
                {
                    badMonth += badMonth == "" ? "" : ",";
                    badMonth += (i+1).ToString();
                }
                newArray[i] = delta;
            }

            /* показ минимальной дельты */
            Array.Sort(newArray);
            var cnt = 3;
            var minDelta = newArray[newArray.Length - 1]; // Берем максимум для отсева
            for(int i= 0; i < newArray.Length; i ++)
            {
                if (cnt < 1) break;

                Console.WriteLine($"month №{i + 1}: \tПрибыль {newArray[i]}");
                

                if (newArray[i] == minDelta)
                {
                    continue;
                }
                else
                {
                    minDelta = Math.Min(newArray[i], minDelta);
                }
                cnt--;
            }

            showMessage("Продажи с положительной прибылью (месяцы):");
            Console.WriteLine($"{goodMonths}");
            showMessage("Продажи с отрицательной прибылью (месяцы):");
            Console.WriteLine($"{badMonth}");
            


            Console.ReadLine();
        }

        static public int[][] demoFinanceStatics()
        {
            
            int minSum = 10000;
            int maxSum = 1000000;

            int[][] demo = new int[12][];


            showMessage("Заполенение демо данными");

            Random rand = new Random();

            for (int month = 0; month < 12; month++)
            {

                demo[month] = new int[3]{  rand.Next(minSum, maxSum) ,  rand.Next(minSum, maxSum) ,0};
            }
            return demo;
        }

        static public void showStatics(int[][] data)
        {
            showMessage("Показ демо данных");
            for (int month = 0; month < 12; month++)
            {
                Console.WriteLine($"Месяц №{month+1} \tДоход: {data[month][0]}\tРасход: {data[month][1]}\tПрибыль: {data[month][0]- data[month][1]}");
            }
        }

        static void Main(string[] args)
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10

            var demo = demoFinanceStatics();
            // compare(arr1, arr2); Вызываем для объединения двух массивов, если нужно организовать ввод по отдельности массива прибыли и отдельно расходов
            showStatics(demo);
            showFinanceStatics(demo);

            // * Задание 2
            // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
            // 
            // При N = 9. Треугольник выглядит следующим образом:
            //                                 1
            //                             1       1
            //                         1       2       1
            //                     1       3       3       1
            //                 1       4       6       4       1
            //             1       5      10      10       5       1
            //         1       6      15      20      15       6       1
            //     1       7      21      35      35       21      7       1
            //                                                              
            //                                                              
            // Простое решение:                                                             
            // 1
            // 1       1
            // 1       2       1
            // 1       3       3       1
            // 1       4       6       4       1
            // 1       5      10      10       5       1
            // 1       6      15      20      15       6       1
            // 1       7      21      35      35       21      7       1
            // 
            // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля
            showMessage("Задача 2");
            Console.WriteLine("Введи число N");
            int n = 0;
            int.TryParse(Console.ReadLine(), out n);
            int[][] outArray = new int[n][];
            outArray[0] = new int[] { 1 };
            for (int i = 1; i < n; i ++)
            {
                outArray[i] = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        outArray[i][j] = 1;
                    }
                    else
                    {
                        outArray[i][j] = outArray[i - 1][j - 1] + outArray[i-1][j];
                    }
                }
            }
            for (int i = 0; i < outArray.Length; i++)
            {
                for (int j = 0; j < outArray[i].Length; j++)
                {
                    Console.Write("{0,-3} ", outArray[i][j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            // 
            // * Задание 3.1
            // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
            // Добавить возможность ввода количество строк и столцов матрицы и число,
            // на которое будет производиться умножение.
            // Матрицы заполняются автоматически. 
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //
            //      |  1  3  5  |   |  5  15  25  |
            //  5 х |  4  5  7  | = | 20  25  35  |
            //      |  5  3  1  |   | 25  15   5  |
            //
            //


            // ** Задание 3.2
            // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
            //  
            //  
            //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
            //
            // *** Задание 3.3
            // Заказчику требуется приложение позволяющщее перемножать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
            //  
            //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            //
            //  
            //                  | 4 |   
            //  |  1  2  3  | х | 5 | = | 32 |
            //                  | 6 |  
            //
        }
    }
}
