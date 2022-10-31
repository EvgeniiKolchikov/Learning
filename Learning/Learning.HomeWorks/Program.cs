using System.Text;
using Learning.HomeWorks;

var addresses = new List<string> { "googe.com", "192.168.1.1", "metanit.ru", "ya.ru" };
var cts = new CancellationTokenSource();
var token = cts.Token;
var siteReq = new ThreadSiteRequesHomeWork();

siteReq.RunAsync(addresses, token);

TokenWaiter();

void TokenWaiter()
{
    var input = Console.ReadLine();
    if(input != null) cts.Cancel();
}



