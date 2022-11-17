using System.Text;

namespace Learning;

public class FileLesson
{
    public void DriveInfo_Method()
    {
        DriveInfo[] driveInfos = DriveInfo.GetDrives();

        foreach (var driveInfo in driveInfos)
        {
            Console.WriteLine($"Название: {driveInfo.Name}");
            Console.WriteLine($"Тип: {driveInfo.DriveType}");
            if (driveInfo.IsReady)
            {
                Console.WriteLine($"Объем диска: {driveInfo.TotalSize}");
                Console.WriteLine($"Объем свободного пространства: {driveInfo.TotalFreeSpace}");
                Console.WriteLine($"Метка диска:{driveInfo.VolumeLabel}");
            }
            Console.WriteLine();
        }
    }

    public void Directory_Method()
    {
        var dirName = "D:\\";

        if (Directory.Exists(dirName))
        {
            Console.WriteLine($"Подкаталоги:");
            var dirs = Directory.GetDirectories(dirName);
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine();
            Console.WriteLine("Файлы:");
            var files = Directory.GetFiles(dirName);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
    public void DirectoryInfo_Method()
    {
        var dirName = "D:\\";
        var directory = new DirectoryInfo(dirName);
        if (directory.Exists)
        {
            Console.WriteLine("Подкаталоги:");
            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                Console.WriteLine(dir.FullName);
            }
            Console.WriteLine();
            Console.WriteLine("Файлы:");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.FullName);
            }
        }
        
        
        
    }
    public void DirectotyFiltration_Method()
    {
        var dirName = "E:\\";
        Console.WriteLine("Directories:");
        
        var dirs = Directory.GetDirectories(dirName, "GAMES*.");

        var directory = new DirectoryInfo(dirName);
        var dirs2 = directory.GetDirectories("GA*.");

        foreach (var dir in dirs2)
        {
            Console.WriteLine(dir);
        }

        Console.WriteLine("Files:");

        var files = directory.GetFiles("*.db");

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }

    }
    public void CreateDirectoty_Method()
    {
        string path = "D:\\TestDIR";
        string subPath = @"test\test";

        var dirInfo = new DirectoryInfo(path);

        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }

        dirInfo.CreateSubdirectory(subPath);
    }
    public void InfoDirectory_Method()
    {
        string dirName = @"D:\";
        var dirInfo = new DirectoryInfo(dirName);
        
        Console.WriteLine($"Название каталога: {dirInfo.Name}");
        Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
        Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
        Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
    }
    public void DeleteDirectory_Method()
    {
        var dirName = "D:\\TestDIR";

        if (Directory.Exists(dirName))
        {
            Directory.Delete(dirName,true);
            Console.WriteLine($"{dirName} Deleted");
        }
        else
        {
            Console.WriteLine("Directory Not Exist");
        }
    }
    public void MoveToDirectory_Method()
    {
        var oldPath = "D:\\TestDIR";
        var newPath = "D:\\TransferFolder";

        var dirInfo = new DirectoryInfo(oldPath);
        if (dirInfo.Exists && !Directory.Exists(newPath))
        {
            dirInfo.MoveTo(newPath);
            //Directory.Move(oldPath,newPath);
        }

    }
    public async Task FileFileInfo_Method()
    {
        FileInfo fileInfo = new FileInfo("E:\\entityApp.db");

        if (fileInfo.Exists)
        {
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
            Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Размер: {fileInfo.Length}");
        }

        var path = @"E:\test.txt";
        var originalText = "HelloWorld!";
        await File.WriteAllTextAsync(path, originalText);
        await File.AppendAllTextAsync(path, "\nGodOfWarRagnarok");

        var fileText = await File.ReadAllTextAsync(path);
        Console.WriteLine(fileText);

    }
    public async Task FileStream_Method()
    {
        var path = "D:\\note.txt";
        var text = "HelloWorld!";

        await using (var fileStream = new FileStream(path,FileMode.OpenOrCreate))
        {
            var buffer = Encoding.Default.GetBytes(text);
            await fileStream.WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine("Текст записан в файл");
        }

        await using (var fileStream = File.OpenRead(path))
        {
            var buffer = new byte[fileStream.Length];
            await fileStream.ReadAsync(buffer, 0, buffer.Length);
            var textFromFile = Encoding.Default.GetString(buffer);
            Console.WriteLine($"Текст из файла: {textFromFile}");
        }
    }
    public async Task StreamWriterReader_Method()
    {
        var path = "D:\\Test.txt";
        var text = "Test Text";

        await using (var streamWriter = new StreamWriter(path,false))
        {
            await streamWriter.WriteLineAsync(text);
        }

        await using (var streamWriter = new StreamWriter(path,true))
        {
            await streamWriter.WriteLineAsync("XXXXXXX");
            await streamWriter.WriteLineAsync("Why?");
        }

        using (var streamReader = new StreamReader(path))
        {
            // var result = await streamReader.ReadToEndAsync();
            // Console.WriteLine(result);

            string? line;
            while ((line = await streamReader.ReadLineAsync()) != null)
            {
                Console.Write(line);
            }
        }
    }
    public void BinaryWriterReader_Method()
    {
        var path = "D:\\person.dat";

        var persons = new PersonBW[]
        {
            new PersonBW("Max", 3),
            new PersonBW("Rex", 77)
        };

        using (var binaryWriter = new BinaryWriter(File.Open(path,FileMode.OpenOrCreate)))
        {
            binaryWriter.Write("Tom");
            binaryWriter.Write(37);
            foreach (var person in persons)
            {
                binaryWriter.Write(person.Name);
                binaryWriter.Write(person.Age);
            }
            Console.WriteLine("Записано в файл");
        }

        var peopleRes = new List<PersonBW>();

        using (var binaryReader = new BinaryReader(File.Open(path,FileMode.Open)))
        {
            while (binaryReader.PeekChar() > -1)
            {
                var name = binaryReader.ReadString();
                var age = binaryReader.ReadInt32();
                peopleRes.Add(new PersonBW(name,age));
            }
        }

        foreach (var pers in peopleRes)
        {
            Console.WriteLine($"{pers.Name} {pers.Age}");
        }

    }
    
}

public class PersonBW
{
    public string Name { get; set; }
    public int Age { get; set; }

    public PersonBW(string name,int age)
    {
        Name = name;
        Age = age;
    }
}