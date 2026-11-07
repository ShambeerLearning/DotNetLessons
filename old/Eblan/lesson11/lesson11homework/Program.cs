Console.WriteLine("Введите число для проверки на чётность");
int a = int.Parse(Console.ReadLine());
if (a % 2 == 0)
{
    Console.WriteLine("Число чётное");
}
else
{
    Console.WriteLine("Число нечётное");
}

Console.WriteLine("Введите число 2 для проверки на чётность");
int a1, temp;
bool result;
a1 = int.Parse(Console.ReadLine());
temp = a % 2;
result = temp == 0;
if (result)
{
    Console.WriteLine("Число чётное");
}
else
{
    Console.WriteLine("Число нечётное");
}