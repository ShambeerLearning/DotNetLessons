using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int a;
            a = 5;
            int b = 0;
            int c, d;
            c = 100;
            d = 10;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);

            bool variable = false;
            //bool variable = true; два раз низя ик
            bool Variable = true;
            //так тоже нинадо бля
            Console.WriteLine(variable);
            Console.WriteLine(Variable);

            double f = 1.33;
            Console.WriteLine(f);

            char g = 'a';
            //char cha = "aaaa"; так низя "" - строка, '' - символ
            Console.WriteLine(g);

            string aaa = "bla bla bla 2424237 &&&8 9(((( /']";
            Console.WriteLine(aaa);

            int value = 5;
            Console.WriteLine(value);
            value = 3;
            Console.WriteLine(value);
            value = 4;
            Console.WriteLine(value);
        }
    }
}