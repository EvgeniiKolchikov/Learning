namespace Learning;

public class StaticModifierLesson
{
    private static int counter;
    public static int stat;
    public int vari;
    private static int prStat;
    private static int Counter { get; set; }
    
    
    public void SetStat(int value)
    {
        prStat = value;
    }

    public void PrintStat()
    {
        Console.WriteLine(prStat);
    }

    public StaticModifierLesson()
    {
        Counter++;
        Console.WriteLine("Конструктор");
    }

    static StaticModifierLesson()
    {
        Console.WriteLine("Статический конструктор");
        Console.WriteLine(GetCount());
        
    }

    public static int GetCount()
    {
        return Counter;
    }

    public int GetObjectCount()
    {
        return Counter;
    }
}

