//task1
Console.WriteLine("Введите число 1");
string a = Console.ReadLine();
int a1 = Convert.ToInt32(a);
Console.WriteLine("Введите число 2");
string b = Console.ReadLine();
int b1 = Convert.ToInt32(b);

int sum = a1 + b1;
double result = (double)sum / 2;

Console.WriteLine("Результат: " + result);

//task2
Console.WriteLine("Введите число 1");
string aa = Console.ReadLine();
int aa1 = Convert.ToInt32(aa);
Console.WriteLine("Введите число 2");
string bb = Console.ReadLine();
int bb1 = Convert.ToInt32(bb);
Console.WriteLine("Введите число 3");
string cc = Console.ReadLine();
int cc1 = Convert.ToInt32(cc);

int sumtask2 = aa1 + bb1 + cc1;
int proiztask2 = aa1 * bb1 * cc1;

Console.WriteLine("Сумма: " + sumtask2);
Console.WriteLine("Произведение: " + proiztask2);

//task3
Console.WriteLine("Введите количество рублей: ");
string interrubles = Console.ReadLine();
double rubles = Convert.ToDouble(interrubles);
double dollars = 3;

double convert = rubles / dollars;
Console.WriteLine("Долларов: " + convert);