using System.Reflection;

namespace Learning;

public class ReflectionLesson
{
    public void Typeof_Method()
    {
        var myTipe = typeof(RPerson);
        Console.WriteLine("typeof " + myTipe);

        // RPerson pers = new RPerson("N");
        // Type myTipe2 = pers.GetType();
        // Console.WriteLine("GetType Method " + myTipe2);
        //
        // Type? myTipe3 = Type.GetType("Learning.RPerson",false,true);
        // Console.WriteLine("Type.GetType " + myTipe3);

        Console.WriteLine($"Name: {myTipe.Name}");
        Console.WriteLine($"FullName: {myTipe.FullName}");
        Console.WriteLine($"NameSpace: {myTipe.Namespace}");
        Console.WriteLine($"Is Value Type: {myTipe.IsValueType}");
        Console.WriteLine($"IS class: {myTipe.IsClass}");

        Console.WriteLine("\nРеализованные интерфейсы");
        foreach (var interf in myTipe.GetInterfaces()) Console.WriteLine(interf);
    }
    public void GetMembers_Method()
    {
        var myType = typeof(RPerson2);
        foreach (var member in myType.GetMembers())
        {
            Console.WriteLine($"{member.DeclaringType}, {member.MemberType}, {member.Name}");
        }
        
        Console.WriteLine(new string('#', 50));
        
        foreach (var member in myType.GetMembers(BindingFlags.DeclaredOnly 
                                                 | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            Console.WriteLine($"{member.DeclaringType}, {member.MemberType}, {member.Name}");
        }
    }
    public void GetMethods_Method()
    {
        var myType = typeof(PrinterR);

        Console.WriteLine("Методы: ");

        foreach (var method in myType.GetMethods()
                     .Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")))
        {
            var modificator = "";

            if (method.IsStatic) modificator += "static ";
            if (method.IsVirtual) modificator += "virtual ";

            Console.WriteLine($"{modificator}{method.ReturnType.Name},{method.Name}");
        }

        Console.WriteLine(new string('#', 50));

        foreach (var method in myType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance
                                                                           | BindingFlags.NonPublic |
                                                                           BindingFlags.Public))
            Console.WriteLine($"{method.ReturnType} {method.Name}");
    }
    public void GetParameters_Method()
    {
        var myType = typeof(PrinterR);
        foreach (MethodInfo method in myType.GetMethods())
        {
            Console.Write($"Метод: {method.ReturnType} {method.Name} (");

            ParameterInfo[] parameters = method.GetParameters();

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                var accessModificator = "";
                if (param.IsIn) accessModificator += "in";
                else if (param.IsOut) accessModificator += "out";
                Console.Write($"Параметр: {param.ParameterType.Name} {accessModificator} {param.Name}");
                if (param.HasDefaultValue) Console.Write($" = {param.DefaultValue}");
                if (i < parameters.Length) Console.Write(",");
            }
            Console.WriteLine(")");
        }
    }
    public void InvokeMethod_Method()
    {
        var printer = new PrinterInvoke("Inner Peace");
        var printMethod = typeof(PrinterInvoke).GetMethod("Print", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        printMethod?.Invoke(printer, parameters: null);
    }
    public void IntervalClassInMyLibraryReflection()
    {
        Assembly asm = Assembly.LoadFrom("MyLibrary.dll");
        Console.WriteLine(asm.FullName);
        var type = asm.GetType("MyLibrary.Interval",false,true);
        if (type is not null)
        {
            var intervalCheck = type.GetMethod("IntervalCheck", BindingFlags.Public | BindingFlags.Static);
            var res = intervalCheck?.Invoke(null, new object?[] { 12, 32, 42 });
            Console.WriteLine("Результат метода: " + res);
        }
    }
}

public class PrinterInvoke
{
    public string Text { get;}
    public PrinterInvoke(string text) => Text = text;
    private void Print() => Console.WriteLine(Text);
}

internal class PrinterR
{
    public string DefaultMessage { get; set; } = "Hello";
    public void PrintMessage(string message, int times = 1)
    {
        while (times-- > 0) Console.WriteLine(message);
    }

    public string CreateMessage()
    {
        return DefaultMessage;
    }
}

public class RPerson : IEater, IMovableR
{
    public string Name { get; }
    public RPerson(string name)
    {
        Name = name;
    }

    public void Eat()
    {
        Console.WriteLine($"{Name} eat");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} moves");
    }
}

internal interface IEater
{
    void Eat();
}

internal interface IMovableR
{
    void Move();
}

public class RPerson2
{
    private readonly string name;
    public int Age { get; set; }
    public RPerson2(string name, int age)
    {
        this.name = name;
        Age = age;
    }

    public void Print()
    {
        Console.WriteLine($"Name: {name}, Age: {Age}");
    }
}