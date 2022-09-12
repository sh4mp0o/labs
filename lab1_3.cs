using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static List<int> puti = new List<int>();
        static int max = 0, min = int.MaxValue;
        static int aboba = 0;
        static void Proverka_putei(int[,] mass, int[] maxm, int[] minm, int i = 0, int j = 0)
        {
            if (i + 1 < mass.GetLength(0))
            {
                if (puti.Count == 0)
                {
                    puti.Add(i);
                    puti.Add(j);
                }
                else
                {
                    if (!(puti[puti.Count - 1] == j && puti[puti.Count - 2] == i))
                    {
                        puti.Add(i);
                        puti.Add(j);
                    }
                }
                Proverka_putei(mass, maxm, minm, i + 1, j);
                puti.RemoveAt(puti.Count - 1);
                puti.RemoveAt(puti.Count - 1);
            }
            if (j + 1 < mass.GetLength(1))
            {
                if (puti.Count == 0)
                {
                    puti.Add(i);
                    puti.Add(j);
                }
                else
                {
                    if (!(puti[puti.Count - 1] == j && puti[puti.Count - 2] == i))
                    {
                        puti.Add(i);
                        puti.Add(j);
                    }
                }
                Proverka_putei(mass, maxm, minm, i, j + 1);
                puti.RemoveAt(puti.Count - 1);
                puti.RemoveAt(puti.Count - 1);
            }
            if (i == (mass.GetLength(0) - 1) && j == (mass.GetLength(1) - 1))
            {
                puti.Add(i);
                puti.Add(j);
                int currmax = 0, count = 0;
                aboba++;
                Console.WriteLine(aboba);
                for (int c = 0; c < puti.Count - 2; c += 2)
                {
                    currmax += mass[puti[c], puti[c + 1]];
                    if (mass[puti[c], puti[c + 1]] == 0) count++;
                }
                if (count == 2)
                {
                    if (max < currmax)
                    {
                        max = currmax;
                        for (int x = 0; x < maxm.Length - 1; x++)
                        {
                            maxm[x] = 0;
                        }
                        for (int x = 0; x < maxm.Length - 1; x++)
                        {
                            maxm[x] = puti[x];
                        }
                    }
                    if (currmax < min)
                    {
                        min = currmax;
                        for (int x = 0; x < minm.Length - 1; x++)
                        {
                            minm[x] = 0;
                        }
                        for (int x = 0; x < minm.Length - 1; x++)
                        {
                            minm[x] = puti[x];
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int n = Convert.ToInt32(sr.ReadLine());
                int[,] mass = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] line = sr.ReadLine().Split();
                    for (int j = 0; j < n; j++)
                    {
                        mass[i, j] = Convert.ToInt32(line[j]);
                    }
                }
                int[] maxm = new int[(n + n - 1) * 2];
                int[] minm = new int[(n + n - 1) * 2];
                Proverka_putei(mass, maxm, minm);
                Console.WriteLine($"Максимальное количество: {max}");
                for (int i = 0; i < maxm.Length - 2; i += 2)
                {
                    Console.Write($"({maxm[i]}; {maxm[i + 1]})\n");
                }
                Console.WriteLine($"Минимальное количество: {min}");
                for (int i = 0; i < minm.Length - 2; i += 2)
                {
                    Console.Write($"({minm[i]}; {minm[i + 1]})\n");
                }
            }
            Console.ReadKey();
        }
    }
}
