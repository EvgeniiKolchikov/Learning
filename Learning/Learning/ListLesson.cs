namespace Learning;

public class ListLesson
{
    public void Run()
    {
        var list = new List<string>() { "Tom", "Kate", "Kimi" };
        var lis1 = new List<string>(list) { "Jerry" };// В коллекции 4 элемента, "Tom", "Kate", "Kimi","Jerry"

        var myClassList = new List<MyClass>()
        {
            new MyClass(),
            new MyClass(),
            new MyClass()
        };

        var list2 = new List<string>(16); // Можем указать количество элементов в списке и ограничить емкость.

        var firstsString = list[0]; // получаем первый элемент списка
        list[0] = "Max"; // присваиваем значение
        
        
        var count = list.Count(); // длина списка 
        
        //Добавление элементов
        var people = new List<string>() { "Tom" };
        people.Add("Jerry"); //Добавление одного элемента
        people.AddRange(new []{"Max","Kimi"}); // Добавление коллекции
        people.AddRange(list);
        
        people.Insert(0,"Lewi"); // вставка на место индекса со смещением
        people.InsertRange(2,new []{"Ghibli","Kirtan"}); // вставка массива с индекса 2
        
        // Удаление элементов
        var people2 = new List<string> () { "Eugene", "Mike", "Kate", "Tom", "Bob", "Sam", "Tom", "Alice" };
        people2.RemoveAt(1); // удаление элемента под индексом
        people2.Remove("Tom"); // удаление элемента с возващением bool, если нет подходящего возращает false
        people2.RemoveAll(p => p.Length == 3); //Удаление всех элементов, подходящих условию
        people2.RemoveRange(1,2); // удаление нескольких элементов начиная с индекса
        
        
        //Поиск и проверка элемента
        var people3 = new List<string> () { "Eugene", "Mike", "Kate", "Tom", "Bob", "Sam" };
        var containsBob = people3.Contains("Bob");
        var containsBill = people3.Contains("Bill"); // Поиск элемента, возвращает если есть true, если нет false

        // Проверка на существование элемента из условия(длина строки 3), возвращает bool
        var exist3Length = people3.Exists(p => p.Length == 3); //true     
        // Проверка на существование элемента из условия(длина строки ), возвращает bool
        var exist7Length = people3.Exists(p => p.Length == 7); //False
        
        // получаем первый элемент с длиной в 3 символа
        var find3 = people3.Find(p => p.Length == 3); // Tom
        //Последний элемент с длиной в 3 символа
        var findLast3 = people3.FindLast(p => p.Length == 3); //Sam
        //Все элементы с длиной в 3 символа в виде списка
        var findAll3 = people3.FindAll(p => p.Length == 3); //{Tom,Bob,Sam}
        
        
        //Получение диапазона и копирование в массив
        
        List<string> people4 = new List<string>() {"Eugene", "Tom", "Mike", "Sam", "Bob" };
        // получаем диапазон со второго по четвертый элемент
        var range = people4.GetRange(1, 3);
        // копируем в массив первые три элемента
        var copied = new string[3];
        people4.CopyTo(0,copied,0,3);
        
        //переворачиваем весь список
        people4.Reverse();
        
        // переворачиваем часть только 3 элемента с индекса 1
        people4.Reverse(1, 3);
        

    }
}

public class MyClass{}