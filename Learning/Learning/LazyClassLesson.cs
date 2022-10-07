namespace Learning;



public class Library
{
    private string[] books = new string[99];

    public void GetBook()
    {
        Console.WriteLine("Выдаем книгу читателю");
    }
}

public class Reader
{
     Lazy<Library> library = new Lazy<Library>();

    public void ReadBook()
    {
        library.Value.GetBook();
        Console.WriteLine("Читаем бумажную книгу");
    }

    public void ReadEBook()
    {
        Console.WriteLine("Читаем на ПК");
    }
}