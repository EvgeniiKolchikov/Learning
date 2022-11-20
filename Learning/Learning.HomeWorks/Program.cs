using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using Learning.HomeWorks;

var path = "D:\\HomeWork.txt";

var fileHW = new FileHomeWork();

while (true)
{
    await fileHW.ShowTextFromFile(path);
    var DHCPCheck = await fileHW.DHCPOnCheckAsync(path);

    if (!DHCPCheck)
    {
        Console.WriteLine("Введите 1 чтобы включить DHCP");
        var input = Console.ReadLine();
        if (input == "1")
        {
            await fileHW.DHCPWriteToFileAsync(path,true);
        }
        else
        {
            Console.WriteLine("Неправильный ввод");
        }
    }
    else
    {
        Console.WriteLine("Введите 2, чтобы отключить DHCP, введите IP адрес");
        var input = Console.ReadLine();
        if (input == "2")
        {
            while (true)
            {
                Console.WriteLine("Введите IP");
                var inputIP = Console.ReadLine();
                var formatMatch = fileHW.IPAddressFormatCheck(inputIP);
                if (formatMatch)
                {
                    fileHW.IP = inputIP;
                    await fileHW.DHCPWriteToFileAsync(path,false);
                    break;
                }
                Console.WriteLine("ВВедите корректный IP");
                Console.WriteLine();
                
            }
        }
        else
        {
            Console.WriteLine("Неправильный ввод");
        }
        Console.WriteLine();
    }
}








