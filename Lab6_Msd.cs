using System;
using System.Diagnostics;

namespace SubstringSearch
{
    class Program
    {
        public class StringMatcher
        {
            public int NativeStringMatching(string str, string substring)
            {
                int index = -1;
                if (substring.Length > str.Length)
                    return index;
                else
                {
                    for (int i = 0; i <= str.Length - substring.Length; i++)
                    {
                        if (str.Length <= 15)
                        {
                            Console.WriteLine(str);
                            for (int k = 0; k < i; k++)
                                Console.Write(" ");
                            Console.Write("^");
                            Console.WriteLine();
                        }
                        if (str[i] == substring[0])
                        {
                            for (int j = 0; j < substring.Length; j++)
                            {
                                if (str.Length <= 15)
                                {
                                    Console.WriteLine(str);
                                    for (int k = 0; k < i + j; k++)
                                        Console.Write(" ");
                                    Console.Write("^");
                                    Console.WriteLine();
                                }
                                if (str[j + i] != substring[j])
                                    break;
                                if (j == substring.Length - 1)
                                    index = i;
                            }
                        }
                    }
                    return index;
                }
            }

            public int ShiftAndSearch(string Text, string Sample)
            {
                int SampleLen = Sample.Length;
                int TextLen = Text.Length;
                if (SampleLen > TextLen)
                {
                    return -1;
                }
                int[,] matrixs = new int[SampleLen, TextLen + 1];
                int[,] vectors = new int[SampleLen, TextLen];
                for (int i = 0; i < TextLen; i++)
                {
                    for (int j = 0; j < SampleLen; j++)
                    {
                        if (Text[i] == Sample[j])
                        {
                            vectors[j, i] = 1;
                        }
                        else
                        {
                            vectors[j, i] = 0;
                        }
                    }
                }
                for (int i = 0; i < TextLen;)
                {
                    int j = SampleLen - 1;
                    for (; j > 0; j--)
                    {
                        matrixs[j, i + 1] = matrixs[j - 1, i];
                    }
                    matrixs[j, i + 1] = 1;
                    i++;
                    for (int k = 0; k < SampleLen; k++)
                    {
                        matrixs[k, i] = matrixs[k, i] & vectors[k, i - 1];
                    }
                }
                int position = 0;
                for (int i = SampleLen - 1; i > 0; i--)
                {
                    bool ok = false;
                    for (int j = TextLen; j > j - i; j--)
                    {
                        if (matrixs[i, j] == 1 && matrixs[i - 1, j - 1] == 1)
                        {
                            position = j - 1;
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        return -1;
                    }
                }
                return position - 1;
            }
        static int max(int a, int b) { return (a > b) ? a : b; }
            static void badCharHeuristic(char[] str, int size, int[] badchar)
            {
                int i;
                for (i = 0; i < 256; i++)
                    badchar[i] = -1; 
                for (i = 0; i < size; i++)
                    badchar[(int)str[i]] = i;
            }
            public int BM_Search(char[] txt, char[] pat)
            {
                int m = pat.Length;
                int n = txt.Length;
                int[] badchar = new int[256];
                badCharHeuristic(pat, m, badchar);
                int s = 0; 
                while (s <= (n - m))
                {
                    if (txt.Length <= 15)
                    {
                        Console.WriteLine(txt);
                        for (int k = 0; k < s; k++)
                            Console.Write(" ");
                        Console.Write("^");
                        Console.WriteLine();
                    }
                    int j = m - 1;
                    while (j >= 0 && pat[j] == txt[s + j])
                    {
                        if (txt.Length <= 15)
                        {
                            Console.WriteLine(txt);
                            for (int k = 0; k < s + j; k++)
                                Console.Write(" ");
                            Console.Write("^");
                            Console.WriteLine();
                        }
                        j--;
                    }
                    if (j < 0)
                    {
                        return s;
                        s += (s + m < n) ? m - badchar[txt[s + m]] : 1;

                    }

                    else
                        s += max(1, j - badchar[txt[s + j]]);
                }
                return -1;
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\nКоманды: ");
            Console.WriteLine("1) Прямой поиск\n2) Shift-And-поиск");
            Console.WriteLine("3) БМ поиск\n4) Встроенный метод C#");
            Console.WriteLine("\nВведите команду: ");
        }

        static void HandleInput(string text, string pattern, string option)
        {
            StringMatcher s = new StringMatcher();
            Stopwatch sw = new Stopwatch();

            if (option == "1")
            {
                sw.Start();
                int index = s.NativeStringMatching(text, pattern);
                sw.Stop();
                if (index == -1)
                    Console.WriteLine("Данной подстроки не существует");
                else
                    Console.WriteLine($"Индекс начала подстроки: {index}");
            }

            if (option == "2")
            {
                sw.Start();
                int index = s.ShiftAndSearch(text, pattern);
                sw.Start();
                if (index == -1)
                    Console.WriteLine("Данной подстроки не существует");
                else
                    Console.WriteLine($"Индекс начала подстроки: {index}");
            }

            if (option == "3")
            {
                sw.Start();
                int index = s.BM_Search(text.ToCharArray(), pattern.ToCharArray());
                sw.Stop();
                if (index == -1)
                    Console.WriteLine("Данной подстроки не существует");
                else
                    Console.WriteLine($"Индекс начала подстроки: {index}");
            }

            if (option == "4")
            {
                sw.Start();
                int index = text.IndexOf(pattern);
                sw.Stop();
                if (index == -1)
                    Console.WriteLine("Данной подстроки не существует");
                else
                    Console.WriteLine($"Индекс начала подстроки: {index}");
            }

            TimeSpan duration = sw.Elapsed;
            Console.WriteLine("Время выполнения : {0}", duration.ToString());
        }

        static void Main(string[] args)
        {
            string text, pattern, option;
            for (; ; )
            {
                Console.WriteLine("Ввод выполняется на английском");
                Console.WriteLine("Введите текст:");
                text = Console.ReadLine();
                Console.WriteLine("Введите подстроку:");
                pattern = Console.ReadLine();
                PrintMenu();
                option = Console.ReadLine();
                HandleInput(text, pattern, option);
            }
        }
    }
}