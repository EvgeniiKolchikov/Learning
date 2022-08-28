namespace Learning;

public class ClassLesson
{
    public const string ConstString = "String const";
    public string name;
    public int number;
    public int number2;
    public int number3;
    public Company company;
    
    public ClassLesson()
    {
        name = "Gary";
        number = 100;
        company = new Company();
        Console.WriteLine($"Конструктор класса без параметров + {name} + {number}");
    }
    public ClassLesson(string name)
    {
        this.name = name;
        number = 19;
        Console.WriteLine($"Конструктор класса с 1 параметром + {name} + {number}");
    }
    public ClassLesson(string name, int i)
    {
        this.name = name;
        number = i;
        Console.WriteLine($"Конструктор класса с 2 параметрами + {name} + {i}");
    }
    
    public ClassLesson(int i, int g, int h) {number = i; number2 = g; number3 = h;}

    public ClassLesson(ClassLesson classLesson)
    {
        this.name = classLesson.name;
        this.number = classLesson.number;
        this.number2 = classLesson.number2;
        this.number3 = classLesson.number3;
    }
    
    
    public void PrintName()
    {
        Console.WriteLine(name + " " + number.ToString());
    }

   
}

public class Company
{
    public string title = "Unknown";
}