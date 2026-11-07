bool isInfected = true;
if (!isInfected)
{
    Console.WriteLine("Персонаж здоров!");
}

bool isInfected1 = false;
if (!isInfected1)
{
    Console.WriteLine("Персонаж здоров!1");
}

bool isHighTemperature = true;
bool hasNoCooling = true;
if (isHighTemperature && hasNoCooling)
{
    Console.WriteLine("Угроза повреждения процессора");
}

bool isHighTemperature1 = true;
bool hasNoCooling1 = false;
if (isHighTemperature1 && hasNoCooling1)
{
    Console.WriteLine("Угроза повреждения процессора1");
}

bool isHighTemperature2 = true;
bool hasNoCooling2 = false;
if (isHighTemperature2 || hasNoCooling2)
{
    Console.WriteLine("Угроза повреждения процессора2");
}

bool isHighTemperature3 = false;
bool hasNoCooling3 = false;
if (isHighTemperature3 || hasNoCooling3)
{
    Console.WriteLine("Угроза повреждения процессора3");
}

int highTemperature = 60;
int fanSpeed = 3000;
bool isHighTemperature4 = highTemperature >= 80;
bool hasNoCooling4 = fanSpeed <= 0;
if (isHighTemperature4 || hasNoCooling4)
{
    Console.WriteLine("Угроза повреждения процессора4");
}

bool isHighTemperature5 = true;
bool hasNoCooling5 = false;
if (isHighTemperature5 | hasNoCooling5)
{
    Console.WriteLine("Угроза повреждения процессора");
}

bool isHighTemperature6 = true;
bool hasNoCooling6 = true;
if (isHighTemperature6 & hasNoCooling6)
{
    Console.WriteLine("Угроаз повреждения процессора");
}