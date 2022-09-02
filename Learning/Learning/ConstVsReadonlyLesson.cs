namespace Learning;

public class ConstVsReadonlyLesson
{
    public const double PI = 3.14;
    private const string SENTENCE = "Per aspera ad astra";
    private readonly string lorem = "Lorem Ipsum";
    private readonly int a;
    private static readonly int b;

    static ConstVsReadonlyLesson()
    {
        b = 333;
        Console.WriteLine("Static constructor");
        Console.WriteLine($"b = {b}");
    }
    public ConstVsReadonlyLesson(int a)
    {
        this.a = a;
        Console.WriteLine("Constructor");
    }

    public static void GetConstFields()
    {
        Console.WriteLine("\nConst Fields and static readonly");
        Console.WriteLine(PI);
        Console.WriteLine(SENTENCE);
        Console.WriteLine(b);
    }

    public void GetReadonlyFields()
    {

        Console.WriteLine("\nReadonly Fields");
        Console.WriteLine(a);
        Console.WriteLine(lorem);
        Console.WriteLine(b);
    }

}