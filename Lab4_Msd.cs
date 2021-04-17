using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSD_4
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                int[] arr = new int[6] { 2, 3, 4, 5, 6, 8 };
                string n1;
                int num;
                int cmp = 0;
                Console.Write("Введите количество элементов массива:");
                n1 = Console.ReadLine();
                int n = Convert.ToInt32(n1);
                int[] mass = new int[n];
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    mass[i] = rnd.Next(10, 999);
                    Console.Write($"{mass[i]} ");
                }
                Console.Write("\nВведите число для поиска:");
                num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"\nЭлемент для поиска:{num}");
                Console.WriteLine("Выберите алгоритм поиска:\n0--Линейный поиск\n1--m-блочный поиск\n2--Поиск встроенным методом c#(Binary Search)");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 0:
                        if (SearchLin(num, ref cmp, mass) == -1)
                        {
                            Console.WriteLine("Элемент не найден");
                            Console.WriteLine($"Количество сравнений:{mass.Length}");
                            Console.WriteLine("Количество присваиваний:0");
                            Console.WriteLine($"Сумма операций:{mass.Length}");
                        }
                        else
                        {
                            Console.WriteLine($"Элемент найден.Индекс элемента:{SearchLin(num, ref cmp, mass)}");
                            Console.WriteLine($"Количество сравнений:{cmp + 1}");
                            Console.WriteLine("Количество присваиваний:1");
                            Console.WriteLine($"Сумма операций:{cmp + 2}");
                        }
                        break;

                    case 1:
                        Block_Search(num, mass, n);
                        break;
                    case 2:
                        //встроенный метод бинарного поиска
                        Array.Sort(mass);
                        Console.WriteLine("Вывод отсортированного массива:\n");
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"{mass[i]} ");
                        }
                        int res = Array.BinarySearch(mass, num);

                        if (res < 0)
                        {
                            Console.WriteLine("\nЭлемент для поиска " + "({0}) не найден." , num);
                        }
                        else
                        {
                            Console.WriteLine("\nИндекс элемента " + "({0}): {1}.", num, res);
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный код операции!");
                        break;

                }
            }

        }
        /// <param name="a">элемент для поиска</param>
        ///  <paramname="compear"> число сравнений</param>
        ///  <returns>возвращает индекс найденного элемента, в противном случае -(-1)</returns>
        public static int SearchLin(int a, ref int compear, int[] X)
        {
            compear = 0;// счетчик сравнений
            int i = 0;
            while ((i < X.Length) && (X[i] != a))
            {
                ++compear;
                ++i;
            }
            if (i < X.Length)
                return i;
            else return -1;
        }


        /// <param name="x">число для поиска</param>
        /// <param name="a">массив в котором ищем нужное нам число</param>
        public static void Block_Search(int x, int[] a, int n)
        {
            int cmp = 0;
            int s = 0, k, j, z;
            int[] b = new int[a.Length];
            Array.Sort(a);
            Console.WriteLine("Вывод отсортированного массива:\n");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{a[i]} ");
            }
            // определение длинн подмассивов
            for (j = 0; ; j++)
            {
                b[j] = (int)Math.Sqrt(a.Length);
                if ((s += b[j]) >= a.Length)
                    break;
            }

            j = 0;
            for (k = b[j++] - 1; (a[k] < x) && (k <= a.Length); k += b[j++]) ;
            if (k > a.Length)
            {
                Console.WriteLine("Ошибка!");
                return;
            }
            for (z = k - b[j - 1]; (z <= k) && (z <= a.Length); z++)
            {
                cmp++;
                if (a[z] == x)
                {
                    Console.WriteLine("Число:%d\n", z);
                    break;
                }
            }
            if (z >= k)
                Console.WriteLine("Не найдено\n");
            Console.WriteLine($"Количество сравнений:{(cmp - 1)}");
        }
    }
}
