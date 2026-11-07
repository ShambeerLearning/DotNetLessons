int limitStart = 0, limitEnd = 0, countChet = 0, countNeChet = 0;
uint countChet2 = 0, countNeChet2 = 0;
Console.WriteLine("Введите первое число диапазона");
try
{
    limitStart = int.Parse(Console.ReadLine());
}
catch (Exception)
{
    Console.WriteLine("Ошибка при введении первого числа лимита");
}
Console.WriteLine("Введите второе число диапазона");
try
{
    limitEnd = int.Parse(Console.ReadLine());
}
catch (Exception)
{
    Console.WriteLine("Ошибка при введении второго числа лимита");
}
while (limitStart <= limitEnd)
{
    limitStart++;
    if (limitStart % 2 == 0)
    {
        countChet2++;
        countChet += limitStart; //countChet = countChet + limitStart
    }
    else if (limitStart % 2 != 0)
    {
        countNeChet2++;
        countNeChet = countNeChet + limitStart;
    }
}
Console.WriteLine("Количество четных чисел в выбранном промежутке: " + countChet2);
Console.WriteLine("Сумма всех чётных чисел: " + countChet);
Console.WriteLine("Количество нечетных чисел в выбранном промежутке: " + countNeChet2);
Console.WriteLine("Сумма всех нечётных чисел: " + countNeChet);
Console.WriteLine("\nНажмите Enter для продолжения");
Console.ReadLine();