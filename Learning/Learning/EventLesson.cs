namespace Learning;

public class EventLesson
{
    
}

// public class EventAccount
// {
//     public delegate void AccountHandler(string message);
//
//     public event AccountHandler Notify;
//     public int Sum { get; private set; }
//
//     public EventAccount(int sum) => Sum = sum;
//
//     public void Put(int sum)
//     {
//         Sum += sum;
//         Notify.Invoke($"На счет поступило {sum}");
//     } 
//
//     public void Take(int sum)
//     {
//         if (Sum > sum)
//         {
//             Sum -= sum;
//             Notify.Invoke($"Со счета снято {sum}");
//             return;
//         }
//         Notify.Invoke($"Недостаточно средств. Текущий баланс{Sum}");
//         
//     }
// }

public class EventAccount
{
    public delegate void AccountHandler(EventAccount sender, AccountEventArgs e);

    public event AccountHandler? Notify;
    public int Sum { get; private set; }

    public EventAccount(int sum) => Sum = sum;

    public void Put(int sum)
    {
        Sum += sum;
        Notify?.Invoke(this,new AccountEventArgs($"На счет поступило {sum}",sum));
    } 

    public void Take(int sum)
    {
        if (Sum > sum)
        {
            Sum -= sum;
            Notify?.Invoke(this,new AccountEventArgs($"Со счета снято {sum}",sum));
            return;
        }
        Notify?.Invoke(this, new AccountEventArgs($"Недостаточно средств. Текущий баланс{Sum}", sum));
        
    }
}

public class AccountEventArgs
{
    public int Sum { get; }
    public string Message { get; }

    public AccountEventArgs(string message, int sum)
    {
        Message = message;
        Sum = sum;
    }
    
}
