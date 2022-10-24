using System.Net;
using System.Timers;
using Timer = System.Timers.Timer;


namespace Learning.HomeWorks;

public class ThreadSiteRequesHomeWork
{
    private const string localhost = "localhost";
    private const string vvcard = "https://vvcard.ru/";
    private const string vk = "https://vk.ru";
    private const string sayTo = "https://saytkotorogo.net";
    private const string google = "https://google.ru";
    private const string facebook = "https://facebook.com";
    private const string linkedin = "https://linkedin.com";
    private const string modem = "192.168.0.1";

    private static int count;
    private static Timer aTimer = new Timer(1000);
    public void SetTimer()
    {
        aTimer.Elapsed += ATimerOnElapsed;
        aTimer.Enabled = true;
        aTimer.AutoReset = true;
        aTimer.Start();
        
    }

    private void ATimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        count++;
        Console.WriteLine(count);
        if (count < 10) return;
        aTimer.Stop();
        count = 0;
        RunTasks();
        SetTimer();
    }


    public void RunTasks()
    {
        var tasks = new Task[]
        {
            new Task(() => SiteRequest(localhost)),
            new Task(() => SiteRequest(vvcard)),
            new Task(() => SiteRequest(vk)),
            new Task(() => SiteRequest(sayTo)),
            new Task(() => SiteRequest(google)),
            new Task(() => SiteRequest(facebook)),
            new Task(() => SiteRequest(linkedin)),
            new Task(() => SiteRequest(modem))
        };
        
        foreach (var t in tasks)
        {
            t.RunSynchronously();
        }
    }
    private void SiteRequest(string req)
    {
        try
        {
            using (var client = new WebClient())
            using (client.OpenRead(req))
            {
                Console.WriteLine($"Результат запроса: {req} - " + true);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Результат запроса: {req} - " + false);
        }
    }
}