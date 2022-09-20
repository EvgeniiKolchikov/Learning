namespace Learning;

public class AdditionalFeaturesLesson { }

//Определение операторов
public class Counter
{
    public int Value { get; set; }

    public static Counter operator + (Counter c1, Counter c2)
    {
        return new Counter() { Value = c1.Value + c2.Value };
    }

    public static int operator +(Counter c1, int value)
    {
        return c1.Value + value;
    }

    public static bool operator > (Counter c1, Counter c2)
    {
        return c1.Value > c2.Value;
    }
    public static bool operator < (Counter c1, Counter c2)
    {
        return c1.Value < c2.Value;;
    }
    
    //Определение инкремента и декремента 
    public static Counter operator ++(Counter c)
    {
        return new Counter() { Value = c.Value + 10 };
    }
}

//Перегрузка операций преобразования типов

public class CCounter
{
    public int Seconds { get; set; }

    public static implicit operator CCounter(int x)
    {
        return new CCounter() { Seconds = x };
    }

    public static explicit operator int(CCounter c)
    {
        return c.Seconds;
    }

    public static explicit operator CCounter(MyTimer myTimer)
    {
        var h = myTimer.Hours * 3600;
        var m = myTimer.Minutes * 60;
        return new CCounter() { Seconds = h + m + myTimer.Seconds };
    }
    
    public static implicit operator MyTimer(CCounter counter)
    {
        int h = counter.Seconds / 3600;
        int m = (counter.Seconds % 3600) / 60;
        int s = counter.Seconds % 60;
        return new MyTimer { Hours = h, Minutes = m, Seconds = s };
    }
    
}

public class MyTimer
{
    public int Hours { get; set; }
    public int Minutes { get; set; }    
    public int Seconds { get; set; }
}


public class Clock
{
    public int Hours { get; set; }
    
    public static  implicit operator Clock(int value)
    {
        return new Clock() { Hours = value % 24 };
    }

    public static explicit operator int(Clock clock)
    {
        return clock.Hours;
    }
}

class Celcius
{
    public double Gradus { get; set; }

    public static implicit operator Celcius(int value)
    {
        return new Celcius() { Gradus = value };
    }

    public static explicit operator double(Celcius cels)
    {
        return cels.Gradus;
    }

    public static explicit operator Celcius(Fahrenheit fahrenheit)
    {
        return new Celcius() { Gradus = 5/9 * (fahrenheit.Gradus - 32)};
    }
    
}
class Fahrenheit
{
    public double Gradus { get; set; }
    
    public static explicit operator Fahrenheit(Celcius celcius)
    {
        return new Fahrenheit() { Gradus = 9/5 * celcius.Gradus + 32};
    }
}

//Методы расширения
public static class StringExtension
{
    public static int CharCount(this string s, char c)
    {
        var counter = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == c)
            {
                counter++;
            }
        }

        return counter;
    }
    
}

//Частичные классы и методы
public partial class Man
{
    public void Alive()
    {
        Console.WriteLine("I'm alive");
    }

    partial void Read();

    public void DoSomething()
    {
        Read();
    }
}

public partial class Man
{
    public void Dead()
    {
        Console.WriteLine("I'm dead");
    }

    partial void Read()
    {
        Console.WriteLine("I'm reading");
    }
}




