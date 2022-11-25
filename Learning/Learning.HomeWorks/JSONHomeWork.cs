using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Learning.HomeWorks;

public class JSONHomeWork
{
    public string Ip { get; set; }
    private const string RegexPattern = "^((?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
    public async Task ShowJsonFromFile(string path)
    {
        try
        { 
            using (var fs = new FileStream(path,FileMode.OpenOrCreate))
            {
               var netSettigs = await JsonSerializer.DeserializeAsync<NetSettings>(fs);
                Console.WriteLine(netSettigs);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public async Task<bool> DHCPOnCheckAsync(string path)
    {
        NetSettings netSettings;
        await using (var fs = new FileStream(path,FileMode.OpenOrCreate))
        {
            netSettings = await JsonSerializer.DeserializeAsync<NetSettings>(fs);
        }
        var check = netSettings.Network.Address == "DHCP=ipv4";
        return check;
    }
    public async Task DHCPWriteToJsonAsync(string path, bool DHCPOn)
    {
        var netSettings = new NetSettings
        {
            ClientName = new ClientName(),
            Network = new Network()
        };
        if (DHCPOn)
        {
            netSettings.ClientName.Name = "MyName";
            netSettings.Network.Address = "DHCP=ipv4";
            using (var fs = new FileStream(path,FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, netSettings);
                return;
            }
        }
        netSettings.ClientName.Name = "MyName";
        netSettings.Network.Address = $"{Ip}";
        
        using (var fs = new FileStream(path,FileMode.Create))
        {
           await JsonSerializer.SerializeAsync(fs, netSettings);
        }
    }
    public bool IPAddressFormatCheck(string input)
    {
        return Regex.IsMatch(input, RegexPattern);
    }
}

public class NetSettings
{
    public ClientName ClientName { get; set; }
    public Network Network { get; set; }

    public override string ToString()
    {
        return $"{ClientName.Name} {Network.Address}";
    }
}

public class ClientName
{
    public string Name { get; set; }
}

public class Network
{
    public string Address { get; set; }
}