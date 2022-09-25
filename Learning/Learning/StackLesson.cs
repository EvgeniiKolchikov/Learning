using System.Collections;

namespace Learning;

public class StackLesson
{
    public void Run()
    {
        //Стек Stack<T> - это коллекция, принцип щапроса которой Последний зашел - первый вышел

        Stack<string> myStack = new Stack<string>();
        //Stack<string> myStack = new Stack<string>(16); Можно указать в параметре емкость стека 
        //Stack<string> myStack = new Stack<string>(new[] {"Tom", "Niko"}); Можно вставить в параметр другую коллекцию 

        // Clear: очищает стек
        // Contains: проверяет наличие в стеке элемента и возвращает true при его наличии
        // Push: добавляет элемент в стек в верхушку стека
        // Pop: извлекает и возвращает первый элемент из стека
        // Peek: просто возвращает первый элемент из стека без его удаления
        
        //Добавление элементов
        myStack.Push("Limo");
        myStack.Push("Foxtrot");
        myStack.Push("Golf");

        foreach (var person in myStack)
        {
            Console.WriteLine(person); //получим Golf,Foxtrot,Limo 
        }
        
        
        //получим первый элемент стека без удаления элемента
        var firstEl = myStack.Peek();
        //{Golf,Foxtrot,Limo}
        
        //первый элемент с удалением из стека
        var firstDel = myStack.Pop();
        //{Limo,Foxtrot}
        var sec = myStack.Pop();
        //{Limo}

        
        // методы TryPeek, TryPop

        var people = new Stack<string>();
        
        people.Push("Mick");

        var success1 = people.TryPop(out var result);//true 
        if (success1) { Console.WriteLine(result); }

        var success2 = people.TryPeek(out var resultPeek);// false
        if (!success2) { Console.WriteLine(false); }

    }
}