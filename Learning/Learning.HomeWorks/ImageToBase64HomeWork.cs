using System.Net.Mime;
using System.Text;
using System.Drawing;
using System;

namespace Learning.HomeWorks;

public class ImageToBase64HomeWork
{
    public static string ConvertFromImageToBase64(string path)
    {
        var fileByte = File.ReadAllBytes(path);
        return Convert.ToBase64String(fileByte);
    }

    public static async Task ConvertFromBase63ToImageAsync(string base64String,string path)
    {
        var fileByte = Convert.FromBase64String(base64String);
        using (var fileSteam = new FileStream(path,FileMode.OpenOrCreate))
        {
            await fileSteam.WriteAsync(fileByte);
        }
    }
}