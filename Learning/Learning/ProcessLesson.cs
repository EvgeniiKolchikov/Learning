using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;

namespace Learning;

public class ProcessLesson
{
    public void WorkWithProcess()
    {
         var process = Process.GetCurrentProcess();
// Console.WriteLine($"Id: {process.Id}");
// Console.WriteLine($"Name: {process.ProcessName}");
// Console.WriteLine($"VirtualMemory: {process.VirtualMemorySize64}");

// foreach (var process in Process.GetProcesses())
// {
//     Console.WriteLine($"Id: {process.Id} Name: {process.ProcessName}");
// }

// var riderProcs = Process.GetProcessesByName("rider64");
// foreach(var proc in riderProcs)
//     Console.WriteLine($"Id: {proc.Id} Name: {proc.ProcessName}");

//var riderProcs = Process.GetProcessesByName("rider64")[0];

// var treads = riderProcs.Threads;
// foreach (ProcessThread thread in treads)
// {
//     Console.WriteLine($"ThreadId: {thread.Id}");
// }

// var modules = riderProcs.Modules;
// foreach (ProcessModule module in modules)
// {
//     Console.WriteLine($"Name: {module.ModuleName}  FileName: {module.FileName}");
// }


//Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "metanit.com");
    }
    public void WokWithDomain()
    {
        var domain = AppDomain.CurrentDomain;
        Console.WriteLine($"Name: {domain.FriendlyName}");
        Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
        Console.WriteLine();

        var assemblies = domain.GetAssemblies();
        foreach(var assemblie in assemblies)
            Console.WriteLine(assemblie.GetName().Name);
    }
    public void WorkWithAssemblyLoadcontext()
    {
        Square(6);
        GC.Collect();
        GC.WaitForPendingFinalizers();

        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            Console.WriteLine(asm.GetName().Name);
    }
    void Square(int number)
    {
        var context = new AssemblyLoadContext(name: "Square", isCollectible: true);
        // установка обработчика выгрузки
        context.Unloading += Context_Unloading;
 
        // получаем путь к сборке MyApp
        var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "MyLibrary.dll");
        // загружаем сборку
        Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);
 
        // получаем тип Program из сборки MyApp.dll
        var type = assembly.GetType("MyLibrary.Lib");
        if (type != null)
        {
            // получаем его метод Square
            var squareMethod = type.GetMethod("Square", BindingFlags.Static | BindingFlags.NonPublic);
            // вызываем метод
            var result = squareMethod?.Invoke(null, new object[] { number });
            if (result is int)
            {
                // выводим результат метода на консоль
                Console.WriteLine($"Квадрат числа {number} равен {result}");
                Console.WriteLine();
            }
        }
 
        // смотим, какие сборки у нас загружены
        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            Console.WriteLine(asm.GetName().Name);
 
        // выгружаем контекст
        context.Unload();
        Console.WriteLine();
    }


// обработчик выгрузки контекста
    void Context_Unloading(AssemblyLoadContext obj)
    {
        Console.WriteLine("Библиотека MyApp выгружена");
    }
}