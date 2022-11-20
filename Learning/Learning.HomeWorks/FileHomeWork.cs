using System.Text;
using System.Text.RegularExpressions;

namespace Learning.HomeWorks;

public class FileHomeWork
{
    public string IP { get; set; }
    private const string PATTERN = "^((?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
    public async Task ShowTextFromFile(string path)
    {
        using (var reader = new StreamReader(File.Open(path,FileMode.OpenOrCreate),Encoding.Default))
        {
            var text = await reader.ReadToEndAsync();
            Console.WriteLine(text);
        }
    }
    public async Task<bool> DHCPOnCheckAsync(string path)
    {
        var text = "";
        using (var reader = new StreamReader(File.Open(path,FileMode.OpenOrCreate),Encoding.Default))
        { 
            text = await reader.ReadToEndAsync();
        }
        var check = text.Contains("DHCP=ipv4");
        return check;
    }
    public async Task DHCPWriteToFileAsync(string path, bool DHCPOn)
    {
        if (DHCPOn)
        {
            using (var writer = new StreamWriter(path,false,Encoding.Default))
            {
                await writer.WriteLineAsync("[Name]\nClientName=MyName\n[Network]\nDHCP=ipv4");
                return;
            }
        }
        using (var writer = new StreamWriter(path,false,Encoding.Default))
        {
            await writer.WriteLineAsync($"[Name]\nClientName=MyName\n[Network]\nAddress={IP}");
        }
    }
    public bool IPAddressFormatCheck(string input)
    {
        return Regex.IsMatch(input, PATTERN);
    }
}