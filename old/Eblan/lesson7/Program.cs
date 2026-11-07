using System;

namespace lesson7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string str = "5";
            int a = int.Parse(str);
            Console.WriteLine(a + 1);

            /*
             * string str = "5fwfwwef";
             * int a = int.Parse(str);
            */

            string str1 = "1";
            try
            {
                int b = int.Parse(str1);
                Console.WriteLine("Конвертация прошла успешно: " + b);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при конвертации");
            }

            string str2 = "2";
            int c;
            int.TryParse(str2, out c);
            Console.WriteLine(c);

            string str3 = "3";
            int d;
            bool result = int.TryParse(str3, out d);
            Console.WriteLine(result);
            if (result)
            {
                Console.WriteLine("Операция выполнена успешно, число = " + d);
            }
            else
            {
                Console.WriteLine("Ошибка при выполнении операции");
            }
        }
    }
}