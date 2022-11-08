using System.Net.NetworkInformation;

namespace Learning.HomeWorks;

public class LINQSiteRequestCollectionHomeWork
{
    public List<MyPing> MyList { get; }
    public LINQSiteRequestCollectionHomeWork()
    {
        MyList = new List<MyPing>();
    }

    public async Task Run()
    {
        
        
    }
    
    public async Task PingSitesAsync(IEnumerable<string> addresses)
    {
        foreach (var address in addresses)
        {
            var myPing = await SiteRequestAsync(address);
            SendToCollection(myPing);
        }
    }
    private void SendToCollection(MyPing myPing)
    {
        lock (MyList)
        {
            MyList.Add(myPing);
        }
    }
    private async Task<MyPing> SiteRequestAsync(string address)
    {
        return await Task.Run(() => SiteRequest(address));
    }
    private MyPing SiteRequest(string address)
    {
        var ping = new Ping();
        var myPing = new MyPing();
        myPing.Address = address;
        try
        {
            var reply = ping.Send(address,1000);
            if (reply.Status == IPStatus.Success)
            {
                myPing.AddressExist = true;
                return myPing;
            }
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
        myPing.AddressExist = false;
        return myPing;
    }
}

public class MyPing
{
    public string Address { get; set; }
    public bool AddressExist { get; set; }

    public override string ToString()
    {
        return $"{Address} - {AddressExist}";
    }
}

public class NewPing
{
    public string Address { get; set; }
    public bool AddressExist { get; set; }
    public DateTime MyDateTime;
    
}








