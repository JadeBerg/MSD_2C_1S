using System;
using System.Collections.Generic;

namespace Hashing
{
    class Program
    {
        // генерирует массив заданного размера с числами в заданных границах
        public static int[] GenerateArray(int size, int min, int max)
        {
            Random r = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
                arr[i] = r.Next(min, max);
            return arr;
        }

        // отображает таблицу
        void PrintDictionary(ref Dictionary<int, int> dictionary)
        {
            foreach (KeyValuePair<int, int> kvp in dictionary)
            {
                Console.WriteLine("Ключ = {0},\tЗначение = {1}", kvp.Key, kvp.Value);
            }
        }

        // разрешает коллизии с помощью линейного зондирования
        void LinearProbing(ref Dictionary<int, int> dictionary, int value)
        {
            // подсчитывает количество обращений к таблице
            int access_count = 1;
            // инициализация ключа
            int k = value % 151;
            if (dictionary.ContainsKey(k))
            {
                int tmp = k;
                while (dictionary.ContainsKey(k))
                {
                    access_count++;
                    k = (tmp + 1) % 151;
                    tmp++;
                }
            }
            dictionary.Add(k, value);
            Console.WriteLine($"Значение добавлено по индексу {k}");
            Console.WriteLine($"Обращение к таблице было совершено {access_count} раз(а)");
        }

        // находит значение, если при хешировании использовалось линейное зондирование
        void LinearProbingSearch(ref Dictionary<int, int> dictionary, int value)
        {
            // подсчитывает количество обращений к таблице
            int access_count = 1;
            // инициализация ключа
            int k = value % 151;
            if (dictionary.ContainsKey(k) && dictionary[k] == value)
            {
                Console.WriteLine($"Значение найдено по индексу {k}");
            }
            if (dictionary.ContainsKey(k) && dictionary[k] != value)
            {
                int tmp = k;
                while (dictionary.ContainsKey(k))
                {
                    access_count++;
                    if (dictionary[k] == value)
                        break;
                    k = (tmp + 1) % 151;
                    tmp++;

                }
                if (dictionary[k] == value)
                    Console.WriteLine($"Значение найдено по индексу {k}");
            }
            if (!dictionary.ContainsKey(k))
            {
                Console.WriteLine("Значение отсутствует в таблице ");
            }
            Console.WriteLine($"Обращение к таблице было совершено {access_count} раз(а)");
        }

        // разрешает коллизии с помощью двойного хеширования
        void DoubleHashing(ref Dictionary<int, int> dictionary, int value)
        {
            // подсчитывает количество обращений к таблице
            int access_count = 1;
            // инициализация ключа
            int k = value % 151;
            int tmp = k;
            if (dictionary.ContainsKey(k))
            {
                int i = 1;
                while (dictionary.ContainsKey(k))
                {
                    access_count++;
                    k = (tmp + i * (value % 901)) % 151;
                    i++;
                }
            }
            dictionary.Add(k, value);
            Console.WriteLine($"Значение добавлено по индексу {k}");
            Console.WriteLine($"Обращение к таблице было совершено {access_count} раз(а)");
        }

        // находит значение, если при двойном хешировании 
        void DoubleHashingSearch(ref Dictionary<int, int> dictionary, int value)
        {
            // подсчитывает количество обращений к таблице
            int access_count = 1;
            // инициализация ключа
            int k = value % 151;
            int tmp = k;
            if (dictionary.ContainsKey(k) && dictionary[k] == value)
            {
                Console.WriteLine($"Значение найдено по индексу {k}");
            }
            if (dictionary.ContainsKey(k) && dictionary[k] != value)
            {
                int i = 1;
                while (dictionary.ContainsKey(k))
                {
                    access_count++;
                    if (dictionary[k] == value)
                        break;
                    k = (tmp + i * (value % 901)) % 151;
                    i++;

                }
                if (dictionary[k] == value)
                    Console.WriteLine($"Значение найдено по индексу {k}");
            }
            if (!dictionary.ContainsKey(k))
            {
                Console.WriteLine("Значение отсутствует в таблице ");
            }
            Console.WriteLine($"Обращение к таблице было совершено {access_count} раз(а)");
        }

        // разрешает коллизии с двойным хешированием аргументов
        void DualArguments(ref Dictionary<int, int> dictionary, int value)
        {
            // подсчитывает количество обращений к таблице
            int access_count = 1;
            // инициализация ключа
            int k = value % 151;
            int tmp = k;
            if (dictionary.ContainsKey(tmp))
            {
                int i = 1;
                while (dictionary.ContainsKey(tmp))
                {
                    access_count++;
                    tmp = k;
                    tmp = (tmp + i) % 151;
                    k = tmp + i;
                    i++;
                }
            }
            dictionary.Add(tmp, value);
            Console.WriteLine($"Значение добавлено по индексу {tmp}");
            Console.WriteLine($"Обращение к таблице было совершено {access_count} раз(а)");
        }

        // находит значение, если использовалось хеширование с двумя аргументами
        void DualArgumentSearch(ref Dictionary<int, int> dictionary, int value)
        {
            // подсчитывает количество обращений к таблице
            int access_count = 1;
            // инициализация ключа
            int k = value % 151;
            int tmp = k;
            if (dictionary.ContainsKey(tmp) && dictionary[tmp] == value)
            {
                Console.WriteLine($"Значение найдено по индексу {k}");
            }
            if (dictionary.ContainsKey(tmp) && dictionary[tmp] != value)
            {
                int i = 1;
                while (dictionary.ContainsKey(tmp))
                {
                    access_count++;
                    if (dictionary[tmp] == value)
                        break;
                    tmp = k;
                    tmp = (tmp + i) % 151;
                    k = tmp + i;
                    i++;

                }
                if (dictionary[tmp] == value)
                    Console.WriteLine($"Значение найдено по индексу {tmp}");
            }
            if (!dictionary.ContainsKey(tmp))
            {
                Console.WriteLine("Значение отсутствует в таблице ");
            }
            Console.WriteLine($"Обращение к таблице было совершено {access_count} раз(а)");
        }

        // хеширует значение в таблицу
        void Hash(ref Dictionary<int, int> dictionary, int option, int value)
        {
            // выдает исключение, если таблица заполнена
            if (dictionary.Count > 151)
                throw new IndexOutOfRangeException("В таблице не может быть более 151 элемента.");
            else
            {
                if (option == 1)
                    LinearProbing(ref dictionary, value);
                if (option == 2)
                    DoubleHashing(ref dictionary, value);
                if (option == 3)
                    DualArguments(ref dictionary, value);
            }
        }

        // отображает меню
        void PrintMenu()
        {
            Console.WriteLine("Команды: ");
            Console.WriteLine("'0' - выход                           '1' - вывод таблицы");
            Console.WriteLine("'2' - смена метода открытой адресации '3' - ввод числа");
            Console.WriteLine("'4' - поиск числа                     '5' - заполнение таблицы случайными числами");
            Console.WriteLine("'6' - удаление числа");
            Console.WriteLine("Введите команду: ");
        }

        // обрабатывает ввод
        void HandleInput(string input, ref Dictionary<int, int> dictionary, ref int option)
        {
            // отображает таблицу
            if (input == "1")
                PrintDictionary(ref dictionary);

            // меняет метод разрешения коллизий
            if (input == "2")
            {
                Console.WriteLine("Методы открытой адресации:");
                Console.WriteLine("1)Метод линейных проб\n2)Метод двойного хеширования\n3)Метод двух аргументов");
                Console.WriteLine("Выберите метод открытой адресации:");
                int.TryParse(Console.ReadLine(), out option);
            }

            // добавление к хешу нового элемента
            if (input == "3")
            {
                if (dictionary.Count > 151)
                    Console.WriteLine("Максимальное количество элеементов в таблице");
                else
                {
                    int value;
                    Console.WriteLine("Введите число: ");
                    int.TryParse(Console.ReadLine(), out value);
                    Hash(ref dictionary, option, value);
                }
            }

            // используется для поиска элемента в таблице
            if (input == "4")
            {
                int value;
                Console.WriteLine("Введите число: ");
                int.TryParse(Console.ReadLine(), out value);
                if (option == 1)
                    LinearProbingSearch(ref dictionary, value);
                if (option == 2)
                    DoubleHashingSearch(ref dictionary, value);
                if (option == 3)
                    DualArgumentSearch(ref dictionary, value);
            }

            // хеширует случайные числа в таблице
            if (input == "5")
            {
                Console.WriteLine("Введите процент заполнения таблицы: ");
                int percentage;
                int.TryParse(Console.ReadLine(), out percentage);
                int size = (151 * percentage) / 100;
                if (size == 0)
                    size++;
                int[] randarr = GenerateArray(size, 100, 900);
                for (int i = 0; i < randarr.Length; i++)
                {
                    Hash(ref dictionary, option, randarr[i]);
                }
                Console.Clear();
                PrintMenu();
                string crutch = Console.ReadLine();
                HandleInput(crutch, ref dictionary, ref option);
            }

            // удаляет указанный элемент
            if (input == "6")
            {
                int index;
                Console.WriteLine("Введите индекс элемента: ");
                int.TryParse(Console.ReadLine(), out index);
                if (dictionary.ContainsKey(index))
                {
                    dictionary.Remove(index);
                    Console.WriteLine("Элемент успешно удалён");
                }
                else
                    Console.WriteLine("Данного элемента не существует");
            }
        }

        static void Main(string[] args)
        {
            // хеширование = int% N (N - размер таблицы)
            Program p = new Program();
            int option;
            Dictionary<int, int> hash = new Dictionary<int, int>();
            // инициализация таблицы
            Console.WriteLine("Методы открытой адресации:");
            Console.WriteLine("1)Метод линейных проб\n2)Метод двойного хеширования\n3)Метод двух аргументов");
            Console.WriteLine("Выберите метод открытой адресации:");
            int.TryParse(Console.ReadLine(), out option);
            // цикл главного меню
            for (; ; )
            {
                string input;
                p.PrintMenu();
                input = Console.ReadLine();
                if (input == "0")
                    break;
                else
                    p.HandleInput(input, ref hash, ref option);
            }
        }
    }
}