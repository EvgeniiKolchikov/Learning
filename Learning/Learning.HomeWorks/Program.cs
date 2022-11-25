using Learning.HomeWorks;
 
var path = "netsettingsXML.xml";

var xmlHW = new XMLHomeWork();

 while (true)
 {
     xmlHW.ShowXMLFromFile(path);
     var DHCPCheck = xmlHW.DHCPOnCheck(path);

     if (!DHCPCheck)
     {
         Console.WriteLine("Введите 1 чтобы включить DHCP");
         var input = Console.ReadLine();
         if (input == "1")
         {
             xmlHW.DHCPWriteToXML(path,true);
         }
         else
         {
             Console.WriteLine("Неправильный ввод");
         }
     }
     else
     {
         Console.WriteLine("Введите 2, чтобы отключить DHCP, введите Ip адрес");
         var input = Console.ReadLine();
         if (input == "2")
         {
             while (true)
             {
                 Console.WriteLine("Введите Ip");
                 var inputIP = Console.ReadLine();
                 var formatMatch = xmlHW.IPAddressFormatCheck(inputIP);
                 if (formatMatch)
                 {
                     xmlHW.Ip = inputIP;
                     xmlHW.DHCPWriteToXML(path,false);
                     break;
                 }
                 Console.WriteLine("ВВедите корректный Ip");
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




