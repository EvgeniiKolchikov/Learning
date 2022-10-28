using System.Diagnostics;
using System.Net;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Net.NetworkInformation;


namespace Learning.HomeWorks;

public class ThreadSiteRequesHomeWork
{
    public int RequestInterval { get; set; } = 10000;
    private bool PingStatus { get; set; }
    private Stopwatch _stopwatch;
    private TimeSpan _timeSpan;


    public void Run(IEnumerable<string> addresses)
    {
        _stopwatch = new Stopwatch();
        while (true)
        {
            var tasks = new Task[addresses.Count()];
            for (var i = 0; i < tasks.Length; i++)
            {
                var i1 = i;
            
                tasks[i] = Task.Factory.StartNew(() => SiteRequest(addresses.ElementAt(i1)));
            
            }
            _stopwatch.Start();
            Thread.Sleep(RequestInterval);
            _stopwatch.Stop();
            _timeSpan = _stopwatch.Elapsed;
            ShowTime();
        }
        
    }
    
    private void SiteRequest(string address)
    {
        PingStatus = false; 
        try
        {
            var ping = new Ping();
                var reply = ping.Send(address,1000);
                if (reply.Status == IPStatus.Success) PingStatus = true;
        }
        catch (Exception e) 
        {
                // ignored
        }
        ShowResultRequest(address);
    }

    private void ShowTime()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('#', 50));
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Интервал - {_timeSpan.Minutes}:{_timeSpan.Seconds}:{_timeSpan.Milliseconds/10} ");
        Console.WriteLine($"Текущее время: {DateTime.Now}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('#', 50));
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void ShowResultRequest(string req)
    {
        if (PingStatus)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Результат запроса {req} - Success");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Результат запроса {req} - Failed");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    
}