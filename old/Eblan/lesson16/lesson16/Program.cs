int a = 0;
while (true)
{
    try
    {
        a = int.Parse(Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Ошибка при введении числа");
    }
    Console.WriteLine(a + a);
}

while (true)
{
    Console.WriteLine("Действие");
}

int count = 0;
while (true)
{
    count++;
    Console.WriteLine(count);
}

int count2 = 0;
while (count2 < 5)
{
    count2++;
    Console.WriteLine(count2);
}

int count3 = 0;
int limit = 0;
try
{
    limit = int.Parse(Console.ReadLine());
}
catch (Exception)
{
    Console.WriteLine("Ошибка при введении числа");
}
while (count3 < limit)
{
    count3++;
    Console.WriteLine(count3);
}