namespace Learning;

public class TryCatchLesson
{
    public void DivideToZeroWithoutTryCatch()
    {
        var x = 5;
        var y = x / 0;
        Console.WriteLine($"y = {y}"); // Получим exception
    }

    public void DivideToZeroWithTryCatch()
    {
        try
        {
            var x = 5;
            var y = x / 0;//код не выполнится, перейдет в блок catch
            Console.WriteLine($"y = {y}"); // 
        }
        catch
        {
            Console.WriteLine("Возникло исключение,выполнился блок catch");
        }
        finally
        {
            Console.WriteLine("Блок finally выполняется всегда после try или catch");
        }
    }

    public void Square(string data)
    {
        if (int.TryParse(data, out var x))
        {
            Console.WriteLine($"Квадрат числа {x * x}");
            return;
        }
        Console.WriteLine("Некорректный ввод");
    }

    public void Divide()
    {
        try
        {
            var x = 4;
            var y = x / 0;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"{ex.Message}");
            
        }
    }

    public void ExceptionFilter()
    {
        var x = 0;
        var y = 1;
        try
        {
            var result1 = x / y;
            var result2 = y / x;
        }
        catch (DivideByZeroException) when (y == 0) // если условие true, то приоритет на выполнении
        {
            Console.WriteLine("Y == 0");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public void CatchBlocks()
    {
        var t = new int[5];
        object obj = "you";
        var x = 0;
        var y = 5;
        try
        {
            var a = (int)obj;
            t[9] = 65;
            var res = y / x;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Исключение {ex.Message}");
            Console.WriteLine($"Метод: {ex.TargetSite}");
            Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
       
    }

    public void ThrowMethod()
    {
        try
        {
            try
            {
                Console.Write("введите имя: ");
                var name = Console.ReadLine();
                if (name == null || name.Length < 2)
                {
                    throw new Exception("Длина меньше 2х символов");
                }
                Console.WriteLine(name);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка");
                throw;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка {e.Message}");
            
        }
        
    }
}

public class EPerson
{
    private int _age;
    public string Name { get; set; } = "";
    public int Age
    {
        get { return _age;}
        set
        {
            if (value < 18)
            {
                throw new PersonException("Нельзя до 18",value);
            }
            _age = value;
        }
    }
}

public class PersonException : Exception
{
    public int Value { get; }
    public PersonException(string message, int value) : base(message)
    {
        Value = value;
    }
}

public class CatchExceptionFindingLesson
{
    public void Main()
    {
        try
        {
            TestClass.Method1();
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine($"Catch in Main: {e.Message}");
        }
        finally
        {
            Console.WriteLine($"Finally в Main");
        }

        Console.WriteLine($"Конец метода Main");
    }
}

public static class TestClass
{
    public static void Method1()
    {
        try
        {
            Method2();
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"Catch в Method1: {e.Message}");
        }
        finally
        {
            Console.WriteLine($"Finally block Method1");
        }

        Console.WriteLine("Конец метода1");
    }

    public static void Method2()
    {
        try
        {
            var x = 0;
            var y = 5 / x;
        }
        finally
        {
            Console.WriteLine($"Finally block in Method2");
        }

        Console.WriteLine("Конец метода 2");
    }
}
