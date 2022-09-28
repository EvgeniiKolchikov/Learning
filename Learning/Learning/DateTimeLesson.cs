namespace Learning;

public class DateTimeLesson
{
    public void Run()
    {
        
        var date1 = new DateTime();
        Console.WriteLine(date1);

        Console.WriteLine(DateTime.MinValue);

        var date2 = new DateTime(2020,9,28);
        Console.WriteLine(date2);

        var date3 = new DateTime(2020,9,28,16,17,58);
        Console.WriteLine(date3);

        Console.WriteLine(DateTime.Now);
        Console.WriteLine(DateTime.UtcNow);
        Console.WriteLine(DateTime.Today);

        var bd = new DateTime(1991,10,13);
        Console.WriteLine(bd.DayOfWeek);

        var date4 = new DateTime(2020,12,12,18,58,1);
        Console.WriteLine(date4.AddMinutes(40));

        Console.WriteLine(date4.ToLocalTime());
        Console.WriteLine(date4.ToUniversalTime());
        Console.WriteLine(date4.ToLongDateString());
        Console.WriteLine(date4.ToShortDateString());
        Console.WriteLine(date4.ToLongTimeString());
        Console.WriteLine(date4.ToShortTimeString());

    }
}