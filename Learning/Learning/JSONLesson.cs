namespace Learning;

public class JSONLesson
{
    
}

public class PersonJSON
{
    public string Name { get; set; }
    public int Age { get; set; }

    public PersonJSON()
    {
        
    }

    public PersonJSON(string name, int age)
    {
        Name = name;
        Age = age;
    }
}