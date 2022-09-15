using Learning;


// var del = new DelegateLesson();
// del.Run();

// var operation = Summ;
// var result = operation(4, 5);
// Console.WriteLine(result);
// operation = Multiply;
// result = operation(4, 5);
// Console.WriteLine(result);
//
// var res = new Operation(Multiply);
// Console.WriteLine(res(5,5));


// var operation = new Operation(Summ);
// operation += Multiply;
// operation();
//
// void Summ()
// {
//     Console.WriteLine("Summ");
// }
//
// void Multiply()
// {
//     Console.WriteLine("Multiply");
// }


// DoOperation(43,4,Summ);
// DoOperation(33,3,Multiply);
// DoOperation(3,3,Subtract);
//
//
//
// void DoOperation(int a, int b, Operation op)
// {
//     Console.WriteLine(op(a,b));
// }
//
// int Summ(int x, int y) => x + y;
// int Multiply(int x, int y) => x * y;
// int Subtract(int x, int y) => x - y;
// delegate int Operation(int x, int y);

var account = new Account(300);
account.RegisterHandler(PrintMessage);
account.RegisterHandler(ChangeColor);
account.Take(100);
account.Take(300);
account.UnregisterHandler(ChangeColor);
account.Take(50);


void PrintMessage(string message) => Console.WriteLine(message);

void ChangeColor(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}