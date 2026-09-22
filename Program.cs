namespace DotNetLessons;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(sum(6,7));
        Console.ReadLine();
    }

    private static int sum(int a, int b)
    {
        return a + b;
    }
}