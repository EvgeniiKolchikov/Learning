// using Learning;
//
//
// var task = PrintAsync("Hello Metanit.com"); // задача начинает выполняться
// Console.WriteLine("Main Works");
//  
// //await task; // ожидаем завершения задачи
//  
// // определение асинхронного метода
// async Task PrintAsync(string message)
// {
//     await Task.Delay(0);
//     Console.WriteLine(message);
// }
//
// int n1 = await SquareAsync(5);
// int n2 = await SquareAsync(6);
// Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36
//  
// async Task<int> SquareAsync(int n)
// {
//     await Task.Delay(0);
//     return n * n;
// }
//
// var square5 = SquareAsync1(5);
// var square6 = SquareAsync1(6);
//  
// Console.WriteLine("Остальные действия в методе Main");
//  
// int n3 = await square5;
// int n4 = await square6;
// Console.WriteLine($"n1={n3}  n2={n4}"); // n1=25  n2=36
//  
// async Task<int> SquareAsync1(int n)
// {
//     await Task.Delay(0);
//     var result = n * n;
//     Console.WriteLine($"Квадрат числа {n} равен {result}");
//     return result;
// }


// определяем и запускаем задачи
// var task1 = PrintAsync("Hello C#");
// var task2 = PrintAsync("Hello World");
// var task3 = PrintAsync("Hello METANIT.COM");
//  
// // ожидаем завершения всех задач
// await Task.WhenAny(task1, task2, task3);
//  
// async Task PrintAsync(string message)
// {
//     await Task.Delay(2000);     // имитация продолжительной операции
//     Console.WriteLine(message);
// }


// определяем и запускаем задачи
// var task1 = SquareAsync(4);
// var task2 = SquareAsync(5);
// var task3 = SquareAsync(6);
//  
// // ожидаем завершения всех задач
// int[] results = await Task.WhenAll(task1, task2, task3);
// // получаем результаты:
// foreach (int result in results)
//     Console.WriteLine(result);
//  
// async Task<int> SquareAsync(int n)
// {
//     await Task.Delay(1000);
//     return n * n;
// }


// var task1 = SquareAsync(4);
// var task2 = SquareAsync(5);
// var task3 = SquareAsync(6);
//  
// //await Task.WhenAll(task1, task2, task3);
// // получаем результат задачи task2
// Console.WriteLine($"task2 result: {task3.Result}"); // task2 result: 25
//  
//  Task<int> SquareAsync(int n)
// {
//     Task.Delay(1000);
//     return  Task.Factory.StartNew(() => n * n);
// }


// try
// {
//     await PrintAsync("Hello METANIT.COM");
//     await PrintAsync("Hi");
// }
// catch (Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }
//  
// async Task PrintAsync(string message)
// {
//     // если длина строки меньше 3 символов, генерируем исключение
//     if (message.Length < 3)
//         throw new ArgumentException($"Invalid string length: {message.Length}");
//     await Task.Delay(100);     // имитация продолжительной операции
//     Console.WriteLine(message);
// }


// await foreach (var num in GetNemberAsync())
// {
//     Console.WriteLine(num);
// }
//
//
//
// async IAsyncEnumerable<int> GetNemberAsync()
// {
//     for (int i = 0; i < 10; i++)
//     {
//         await Task.Delay(100);
//         yield return i;
//     }
// }


var repo = new Repository();
var data = repo.GetDataAsync();
var list = await data.ToListAsync();


Console.WriteLine(list.Count);



class Repository
{
    string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
    public async IAsyncEnumerable<string> GetDataAsync()
    {
        for (int i = 0; i < data.Length; i++)
        {
            Console.WriteLine($"Получаем {i + 1} элемент");
            await Task.Delay(5000);
            yield return data[i];
        }
    }
}