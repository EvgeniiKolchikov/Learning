namespace Learning;

public class YieldReturnLesson
{
    public void Run()
    {
        
        
        
    }
}

class Numbers
{
    
    public IEnumerator<int> GetEnumerator()
    {
        for (var i = 0; i < 7; i++)
        {
            yield return i * i;
        }
    }
}

class YPerson
{
    public string Name { get; set; }
    public YPerson(string name) => Name = name;
}

class YCompany
{
    private YPerson[] personnel;
    public YCompany(YPerson[] personnel) => this.personnel = personnel;

    public IEnumerable<YPerson> GetEnumerator(int max)
    {
        for (var i = 0; i < max; i++)
        {
            if (i == personnel.Length)
            {
                yield break;
            }
            else
            {
                yield return personnel[i];
            }
        }
    }
}