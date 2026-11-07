using System.Globalization;

NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
{
    NumberDecimalSeparator = ".",
};
double a, b, result;
char operation;
Console.WriteLine("Введите первое число:");
a = double.Parse(Console.ReadLine(), numberFormatInfo);
Console.WriteLine("Введите действие(+, -, *, /):");
operation = char.Parse(Console.ReadLine());
Console.WriteLine("Введите второе число:");
b = double.Parse(Console.ReadLine(), numberFormatInfo);
if (operation == '+')
{
    result = a + b;
    Console.WriteLine("Сумма чисел: " + result);
}
if (operation == '-')
{
    result = a - b;
    Console.WriteLine("Разность чисел: " + result);
}
if (operation == '*')
{
    result = a * b;
    Console.WriteLine("Произведение чисел: " + result);
}
if (operation == '/')
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
else
{
    Console.WriteLine("Такого действия не существует");
}