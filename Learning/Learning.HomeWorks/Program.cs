using Learning.HomeWorks;

var addresses = new List<string>
{
    "google.com", "msn.com", "metanit.ru", "ya.ru"
};

var siteReq = new ThreadSiteRequesHomeWork();
await siteReq.RunAsync(addresses);
