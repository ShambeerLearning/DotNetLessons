using System;
using System.Globalization;

namespace lesson6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string str = "5";
            string str2 = "2";
            Console.WriteLine(str + str2);

            int a = 5;
            int b = 2;
            Console.WriteLine(a + b);
            
            string str3 = "5";
            int f = Convert.ToInt16(str3);
            int g = 5;
            Console.WriteLine(f + g);
            
            Console.WriteLine("Введите число 1");
            string str4 = Console.ReadLine();
            int srtint1 = Convert.ToInt16(str4);
            Console.WriteLine("Введите число 2");
            string str5 = Console.ReadLine();
            int srtint2 = Convert.ToInt16(str5);
            int result = srtint1 + srtint2;
            Console.WriteLine("Сумма чисел = " + result);

            string str7 = "1,9";
            Console.WriteLine(str7);

            string str6 = "1.9";
            NumberFormatInfo numberFormat = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };
            double dbl1 = Convert.ToDouble(str6, numberFormat);
            Console.WriteLine(dbl1);
        }
    }
}