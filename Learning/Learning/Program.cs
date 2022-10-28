using System.Threading.Channels;
using Learning;


var a = new AsyncAwaitLesson();
//await a.ShowMessage(); // Если await есть то код ниже ждет когда выполниться эта строка, только потом начинает выполняться код ниже
a.ShowMessageAsync(); // Без await метод выполняется асинхронно, код ниже не ждет завершения 

a.ShowMessage2Async(); // Await есть - методы работают асинхронно, 

for(int i = 0; i < 100; i++)
{
    Console.WriteLine(i);
    Thread.Sleep(100);
}
