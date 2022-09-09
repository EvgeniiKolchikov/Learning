namespace Learning;

public class GenericLesson { }

/*public class GPerson<T>
{
    public static T? code;
    public T Id { get; set; }
    public string Name { get; set; }

    public GPerson(T id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Company<P>
{
    public P CEO { get; set; }

    public Company(P ceo)
    {
        CEO = ceo;
    }
}*/

/*public class Message
{
    public string Text { get; }

    public Message(string text)
    {
        Text = text;
    }
}

public class EmailMessage : Message
{
    public EmailMessage(string message) : base(message){}
}

public class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) {}
}

public class Messenger<T,P> where T : Message where P : Person1
{
    public void SendMessage(P sender, P receiver, T message)
    {
        Console.WriteLine($"Отправитель: {sender.Name}");
        Console.WriteLine($"Получатель: {receiver.Name}");
        Console.WriteLine($"Текст сообщения: {message.Text}");
    }
}

public class Person1
{
    public string Name { get; set; }
    public Person1(string name) => Name = name;
}*/

public class GPerson<T>
{
    public T Id { get; set; }

    public GPerson(T id)
    {
        Id = id;
    }
}

public class UniversalPerson<T> : GPerson<T>
{
    public UniversalPerson(T id) : base(id)
    {
    }
}