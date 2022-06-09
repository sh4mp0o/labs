using System;
using System.IO;

//На шахматной доске (8x8) стоит одна белая шашка. Сколькими способами она может пройти в
//дамки?
//(Белая шашка ходит по диагонали. на одну клетку вверх-вправо или вверх-влево. Шашка проходит
//в дамки, если попадает на верхнюю горизонталь.)
//Входные данные
//Вводятся два числа от 1 до 8: номер номер столбца (считая слева) и строки(считая снизу), где
//изначально стоит шашка.
//Выходные данные
//Вывести одно число - количество путей в дамки.

//Примеры
//входные данные
//3 7
//выходные данные
//2
//входные данные
//1 8
//выходные данные
//1
//входные данные
//3 6
//выходные данные
//4

namespace lab01._03._22_2_
{
    internal class Program
    {
        static int alg(int x, int y, int N)
        {
            if (y == 8) return N;
            if (x == 1) return alg(2, y + 1, N);
            if (x == 8) return alg(7, y + 1, N);
            return alg(x + 1, y + 1, N) + alg(x - 1, y + 1, N);
        }
        static void Main(string[] args)
        {
            int x, y;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] line = sr.ReadLine().Split();
                x = int.Parse(line[0]); y = int.Parse(line[1]);
            }
            Console.WriteLine(alg(x, y, 1));
            Console.ReadLine();
        }
    }
}
