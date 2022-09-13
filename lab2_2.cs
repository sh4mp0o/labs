using System;
using System.Collections.Generic;
using System.IO;

//В заданной линейной программе удалить первый оператор каждой пары следующих
//друг за другом операторов в случае, если их левые части совпадают, а правая
//часть второго оператора не содержит вхождений переменной, совпадающей с его левой частью.

namespace lab
{
    internal class Program
    {
        static List<List<string>> strings = new List<List<string>>();
        static void Delete()
        {
            int length = strings.Count;
            int last = length + 1;
            while (length != last) 
            {
                for (int i = 1; i < strings.Count; i++)
                {
                    bool flag = false;
                    string s = strings[i][0];
                    int n = s.IndexOf(':');
                    string sub = s.Substring(0, n);
                    s = s.Remove(0, n - 1);
                    if (s.Contains(sub))
                        flag = true;
                    s.Insert(0, sub);
                    if (!flag)
                    {
                        s = strings[i - 1][0];
                        n = s.IndexOf(':');
                        if (sub == s.Substring(0, n))
                        {
                            strings.RemoveAt(i - 1);
                            last--;
                            i--;
                        }
                    }
                }
                length = strings.Count;
                last--;
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int u = 0;
                string s = sr.ReadToEnd();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ';') i += 2;
                    else
                    {
                        string str = ""; int j = 0;
                        strings.Add(new List<string>());
                        while (s[j + i] != ';')
                        {
                            str += s[j + i];
                            j++;
                        }
                        strings[u].Add(str);
                        i += j - 1;
                        u++;
                    }
                }
                Delete();
                for (int i = 0; i < strings.Count; i++)
                {
                    Console.WriteLine(strings[i][0]);
                }
            }
            Console.ReadKey();
        }
    }
}
