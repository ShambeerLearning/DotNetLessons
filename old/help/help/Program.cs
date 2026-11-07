using System;

public delegate void Zalupka();

internal class Program
{
    private static Zalupka onAutist;

    internal static void Main(string[] args)
    {
        onAutist += ZovDauna.Chmo;
        onAutist += ZovDauna.Onaninst;
        onAutist += ZovDauna.UdvaivanieDaunov;
        onAutist += ZovDauna.Pokakal;
        Console.WriteLine("Нажмите любую клавишу");
        Console.ReadKey();
        onAutist?.Invoke();
    }
}