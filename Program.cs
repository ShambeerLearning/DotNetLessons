namespace DotNetLessons;

class Program
{
    private record class User
    {
        public string Name { get; set; } = String.Empty;
        public int Age { get; set; }
    }

    private User userSet(User user)
    {
        user.Name = user.Name + " " + user.Age;
        return user;
    }
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