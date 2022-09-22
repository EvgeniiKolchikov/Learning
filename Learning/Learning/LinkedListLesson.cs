namespace Learning;

public class LinkedListLesson
{
    public void Run()
    {
        var linkedList = new LinkedList<string>();
        var people = new List<string>() { "Tom", "Jerry", "kim" };

        var linkedList1 = new LinkedList<string>(people);
        
        
        // Count: количество элементов в связанном списке
        //
        // First: первый узел в списке в виде объекта LinkedListNode<T>
        //
        // Last: последний узел в списке в виде объекта LinkedListNode<T>

        Console.WriteLine(linkedList1.Count);
        Console.WriteLine(linkedList1.First?.Value);//Tom
        Console.WriteLine(linkedList1.Last?.Value);//kim
        
        
        // от начала до конца списка

        var currentEl = linkedList1.First;
        while (currentEl != null)
        {
            Console.WriteLine(currentEl.Value);
            currentEl = currentEl.Next;
        }
        
        //от конца до начала списка
        currentEl = linkedList1.Last;
        while (currentEl != null)
        {
            Console.WriteLine(currentEl.Value);
            currentEl = currentEl.Previous;
        }


        var people2 = new LinkedList<string>();
        people2.AddLast("Tom");// вставляем узел со значением Tom на последнее место
                                //так как в списке нет узлов, то последнее будет также и первым
        people2.AddFirst("Jerry");// вставляем узел со значением Jerry на первое место
        // вставляем после первого узла новый узел со значением kimi
        if (people2.First != null) people2.AddAfter(people2.First, "Kimi");
        
        // теперь у нас список имеет следующую последовательность: Jerry Kimi Tom
        foreach (var person in people2) Console.WriteLine(person);

        var personLinked = new LinkedList<Person>();
        personLinked.AddLast(new Person("Timi"));
        personLinked.AddLast(new Person("Stan"));
        personLinked.AddFirst(new Person("Kartman"));

        foreach (var pers in personLinked)
        {
            Console.WriteLine(pers.Name);
        }

    }
}