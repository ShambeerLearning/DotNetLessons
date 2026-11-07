namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите стороны: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());
            double d = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            SearchAndCheck(a, b, c);
            SearchAndCheck(a, b, d);
            SearchAndCheck(a, c, d);
            SearchAndCheck(b, c, d);

            Console.WriteLine();
            Console.ReadLine();
        }

        static bool isTriangle(double a, double b, double c)
        {
            if ((a < b + c) && (b < a + c) && (c < a + b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static double SearchSquare(double a, double b, double c)
        {
            double p = (a + b + c) / 2.0;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }

        static void SearchAndCheck(double a, double b, double c)
        {
            if (isTriangle(a, b, c))
            {
                Console.WriteLine("Площадь треугольника со сторонами: " + a + "; " + b + "; " + c + "; равняется: " + SearchSquare(a, b, c));
            } else
            {
                Console.WriteLine("Площадь треугольника со сторонами: " + a + "; " + b + "; " + c + "; не существует");
            }
        }
    }
}
