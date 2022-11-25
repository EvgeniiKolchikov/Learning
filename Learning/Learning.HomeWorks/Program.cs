
 using Learning.HomeWorks;



var path = "netsettings.json";

 var jsonHW = new JSONHomeWork();

 while (true)
 {
     await jsonHW.ShowJsonFromFile(path);
     var DHCPCheck = await jsonHW.DHCPOnCheckAsync(path);

     if (!DHCPCheck)
     {
         Console.WriteLine("Введите 1 чтобы включить DHCP");
         var input = Console.ReadLine();
         if (input == "1")
         {
             await jsonHW.DHCPWriteToJsonAsync(path,true);
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
                 var formatMatch = jsonHW.IPAddressFormatCheck(inputIP);
                 if (formatMatch)
                 {
                     jsonHW.IP = inputIP;
                     await jsonHW.DHCPWriteToJsonAsync(path,false);
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



