
using Learning.HomeWorks;

var sites = new []{"google.com", "metanit.ru"};

var linqHW = new LINQSiteRequestCollectionHomeWork();

await linqHW.PingSitesAsync(sites);

var myList = linqHW.MyList;

var linq1 = myList.Select(p => new NewPing
{
    Address = p.Address,
    AddressExist = p.AddressExist,
    MyDateTime = DateTime.Now
});

foreach (var el in linq1)
    Console.WriteLine($"{el.Address} - {el.AddressExist} - {el.MyDateTime}");
