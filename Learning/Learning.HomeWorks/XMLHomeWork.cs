using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Learning.HomeWorks;


    public class XMLHomeWork
{
    public string Ip { get; set; }
    private const string RegexPattern = "^((?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
    public void ShowXMLFromFile(string path)
    {
        var xmlSerializer = new XmlSerializer(typeof(NetSettingsXML));
        try
        { 
            using (var fs = new FileStream(path,FileMode.OpenOrCreate))
            {
                var netSettigs = xmlSerializer.Deserialize(fs) as NetSettingsXML;
                if (netSettigs != null)
                {
                Console.WriteLine(netSettigs);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public bool DHCPOnCheck(string path)
    {
        NetSettingsXML netSettingsXml;
        var xmlSerializer = new XmlSerializer(typeof(NetSettingsXML));
        using (var fs = new FileStream(path,FileMode.OpenOrCreate))
        {
            netSettingsXml = xmlSerializer.Deserialize(fs) as NetSettingsXML;
        }
        var check = netSettingsXml.NetworkXml.Address == "DHCP=ipv4";
        return check;
    }
    public void DHCPWriteToXML(string path, bool DHCPOn)
    {
        var netSettings = new NetSettingsXML
        {
            ClientNameXml = new ClientNameXML(),
            NetworkXml = new NetworkXML()
        };

        var xmlSerializer = new XmlSerializer(typeof(NetSettingsXML));
        if (DHCPOn)
        {
            netSettings.ClientNameXml.Name = "MyName";
            netSettings.NetworkXml.Address = "DHCP=ipv4";
            using (var fs = new FileStream(path,FileMode.Create))
            {
                xmlSerializer.Serialize(fs, netSettings);
                return;
            }
        }
        netSettings.ClientNameXml.Name = "MyName";
        netSettings.NetworkXml.Address = $"{Ip}";
        
        using (var fs = new FileStream(path,FileMode.Create))
        {
            xmlSerializer.Serialize(fs, netSettings);
        }
    }
    public bool IPAddressFormatCheck(string input)
    {
        return Regex.IsMatch(input, RegexPattern);
    }
}

public class NetSettingsXML
{
    public ClientNameXML ClientNameXml { get; set; }
    public NetworkXML NetworkXml { get; set; }

    public override string ToString()
    {
        return $"{ClientNameXml.Name} {NetworkXml.Address}";
    }
}

public class ClientNameXML
{
    public string Name { get; set; }
}

public class NetworkXML
{
    public string Address { get; set; }
}
