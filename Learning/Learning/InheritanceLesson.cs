namespace Learning;

public class InheritanceLesson
{
    
}

class Person
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }

    public Person(string firstName,string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }
}

class Employee:Person
{
    public string Position { get; set; }

    public Employee(string firstName,string secondName,string position):base(firstName,secondName)
    {
        Position = position;
    }

    public void PrintName(Person person)
    {
        Console.WriteLine(person.FirstName + " " + person.SecondName);
    }
}

class Student:Person
{
    public string GroupName { get; set; }

    public Student(string firstName,string secondName,string groupName):base(firstName,secondName)
    {
        GroupName = groupName;
    }
}