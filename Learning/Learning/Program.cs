using Learning;


var account = new EventAccount(100);
account.Notify += DisplayMessage;

account.Put(50);
Console.WriteLine($"Total: {account.Sum}");
account.Take(100);
Console.WriteLine($"Total: {account.Sum}");
account.Take(100);
Console.WriteLine($"Total: {account.Sum}");

void DisplayMessage(EventAccount sender, AccountEventArgs e)
{
    
    Console.WriteLine($"Сумма транзакции: {e.Sum}");
    Console.WriteLine(e.Message);
    Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
}

