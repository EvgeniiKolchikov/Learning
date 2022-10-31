using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Learning.HomeWorks;

public class ThreadSiteRequesHomeWork
{
    public int RequestInterval { get; set; } = 10000;
    private Stopwatch _stopwatch;
    private TimeSpan _timeSpan;
    private List<string> _list;

    public ThreadSiteRequesHomeWork()
    {
        _list = new List<string>();
        _stopwatch = new Stopwatch();
    }
    
    public async void RunAsync(IEnumerable<string> addresses, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            ListClear(_list);
            foreach (var address in addresses)
            {
               var res = await SiteRequestAsync(address);
               SendToCollection(address,res);
            }
            ShowCollection();
            _stopwatch.Start();
            await Task.Delay(RequestInterval);
            _stopwatch.Stop();
            ShowTime();
        }
    }
    
    private async Task<bool> SiteRequestAsync(string address)
    {
        return await Task.Run(() => SiteRequest(address));
    }
    
    private bool SiteRequest(string address)
    {
        try
        {
            var ping = new Ping();
                var reply = ping.Send(address,1000);
                if (reply.Status == IPStatus.Success)
                {
                    //SendToCollection(address, true);
                    return true;
                }
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
        //SendToCollection(address, false);
        return false;
    }

    private void SendToCollection(string address,bool res)
    {
        lock (_list)
        {
            _list.Add($"Результат запроса {address} - {res}");
        }
    }

    private void ShowCollection()
    {
        foreach (var el in _list)
        {
            Console.WriteLine(el);
        }
    }

    private void ListClear(List<string> list)
    {
        list.Clear();
    }
    private void ShowTime()
    {
        _timeSpan = _stopwatch.Elapsed;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('#', 50));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Интервал - {_timeSpan.Minutes}:{_timeSpan.Seconds}:{_timeSpan.Milliseconds/10} ");
        Console.WriteLine($"Текущее время: {DateTime.Now}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('#', 50));
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    
}