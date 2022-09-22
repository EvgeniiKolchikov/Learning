namespace Learning;

public class QueueLesson
{
    public void Run()
    {
        var q = new Queue<string>();
        var qq = new Queue<string>(16); // можно указать емкость очереди

        var people = new List<string>() { "Tom", "Jerry", "Hero" };
        var qqq = new Queue<string>(people);
        foreach (var person in people) Console.WriteLine(person);

        Console.WriteLine(people.Count);


        var people2 = new Queue<string>();
        people2.Enqueue("Tom"); //Tom
        people2.Enqueue("Jerry"); //Tom,Jerry
        people2.Enqueue("Jim"); //Tom,Jerry,Jim
        
        // получаем элемент из самого начала очереди 
        var firstElement = people2.Peek(); // Tom
        
        //удаляем элементы
        var person1 = people2.Dequeue(); //Jerry,jim
        Console.WriteLine(person1); // Tom
        var person2 = people2.Dequeue(); //jim
        Console.WriteLine(person2);
        var person3 = people2.Dequeue(); // пусто
        Console.WriteLine(person3);
        
        





    }
    
}