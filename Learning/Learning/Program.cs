using System.Diagnostics.CodeAnalysis;
using Learning;

//Определение операторов

// var count = new Counter(){Value = 32};
// var count2 = new Counter(){Value = 33};
//
// bool result = count > count2;
// var c3 = count + count2;
// var val = count + 12;
//
// if (result)
// {
//     Console.WriteLine("count > count 2");
//    
// }
// else
// {
//     Console.WriteLine("count < count 2");
// }
//
// Console.WriteLine(c3.Value);
//
// //Определение инкремента и декремента
//
// var c4 = count++;
// Console.WriteLine(count.Value);
// Console.WriteLine(c4.Value);


//Применение операторов преобразования в программе:

// var counter = new CCounter(){Seconds = 3};
//
// var x = (int)counter;
//
// CCounter counter2 = x;
// Console.WriteLine(counter2.Seconds);
//
// var count = new CCounter() { Seconds = 115 };
// var timer = new MyTimer() { Hours = 2, Minutes = 33, Seconds = 27};
//
// MyTimer timer2 = count;
// Console.WriteLine(timer2.Hours + ":" + timer2.Minutes + ":" + timer2.Seconds);
//
// CCounter ccounter = (CCounter)timer2;
// Console.WriteLine(ccounter.Seconds);


// var clock = new Clock();
// var val = 34;
//
// Clock clock2 = 13;
// Console.WriteLine(clock2.Hours);
//
// var hours = (int)clock2;
// Console.WriteLine(hours);


// var celcius = new Celcius() { Gradus = 0 };
// celcius = 45;
// Console.WriteLine(celcius.Gradus);
//
// var gr = (double)celcius;
// Console.WriteLine(gr);
//
// var fahrengeit = new Fahrenheit() { Gradus = 44 };
// fahrengeit = (Fahrenheit)celcius;
// Console.WriteLine(fahrengeit.Gradus);


//Методы расширения
// var s = "Lorem ipsum";
//
// var i = s.CharCount('m');
// Console.WriteLine(i);


//Partial class - Частичные классы и методы
// var man = new Man();
// man.Alive();
// man.Dead();
// man.DoSomething();


//Анонимные типы
// var tom = new {Name = "Tom",age = 45};
//
// var pers = new Person("Niki") {  };
//
// var anon = new { pers.Name };
// Console.WriteLine(anon.Name);


//Кортежи

var cort = (13,45);
Console.WriteLine(cort.Item1);
Console.WriteLine(cort.Item2);

(int, string) cort2 = (2, "gh");
var cort3 = (count: 32, name: "43");
cort3.count = 43;
Console.WriteLine(cort3.count + cort3.name);

(int, int) swapper = (98, 22);
var a = 9;
var b = 89;
(a, b) = (b, a); // Удобно использовать для свапа значений

var numbers = new[] { 12, 43, -43, 3424, 0, -78 };

for(var i = 0; i < numbers.Length - 1; i++)
{
    for (var j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] > numbers[j])
        {
            (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
        }
    }
}

foreach (var t in numbers)
{
    Console.Write(t + " ");
}

Console.WriteLine();

var tuple = GetValuesData(numbers);
Console.WriteLine(tuple.sum);
Console.WriteLine(tuple.count);


(int sum, int count) GetValuesData(int[] numb)
{
    var res = (sum: 0, count: numb.Length);
    foreach (var n in numb)
    {
        res.sum += n;
    }

    return res;
}

