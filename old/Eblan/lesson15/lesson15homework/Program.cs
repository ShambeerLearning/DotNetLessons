using System.Globalization;

NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
{
    NumberDecimalSeparator = "."
};
double a, b, result;
char operation;
Console.WriteLine("Введите первое число");
a = double.Parse(Console.ReadLine(), numberFormatInfo);
Console.WriteLine("Введите операцию(+, -, *, /)");
operation = char.Parse(Console.ReadLine());
Console.WriteLine("Введите второе число");
b = double.Parse(Console.ReadLine(), numberFormatInfo);

switch (operation)
{
    case '+':
        {
            result = a + b;
            Console.WriteLine("Сумма чисел: " + result);
        }
        break;

    case '-':
        {
            result = a - b;
            Console.WriteLine("Разность чисел: " + result);
        }
        break;

    case '*':
        {
            result = a * b;
            Console.WriteLine("Произведение чисел: " + result);
        }
        break;

    case '/':
        {
            if (b == 0)
            {
                Console.WriteLine("На ноль делить нельзя!");
            }
            else
            {
                result = a / b;
                Console.WriteLine("Частное чисел: " + result);
            }
        }
        break;

    default:
        {
            Console.WriteLine("Такого действия не существует");
        }
        break;
}