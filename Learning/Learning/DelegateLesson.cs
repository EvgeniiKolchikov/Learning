using System.Net.Sockets;

namespace Learning;


public class DelegateLesson
{
    public delegate void Message();
    public void Run()
    {
        Message mes;
        mes = Hello;
        mes();
        mes = Print;
        mes();
        mes = Display;
        mes();
    }

    void Hello() => Console.WriteLine("Hello");

    public static void Print() => Console.WriteLine("Printing");
    public static void Display() => Console.WriteLine("Display");

}

//Применение Делегатов

public delegate void AccountHandler(string message);
public class Account
{
    private int sum;
    private AccountHandler? taken;

    public void RegisterHandler(AccountHandler del)
    {
        taken += del;
    }

    public void UnregisterHandler(AccountHandler del)
    {
        taken -= del;
    }
    public Account(int value) => sum = value;

    public void Add(int value) => sum += value;

    public void Take(int value)
    {
        if (sum >= value)
        {
            sum -= value;
            taken?.Invoke($"Списано {value}. Остаток: {sum}");
            return;
        }
        taken?.Invoke($"Недостаточно средств. Баланс: {sum}");
    }
    

}