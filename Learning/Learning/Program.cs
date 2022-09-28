using Learning;

// Yield Return Lesson

Numbers numbers = new Numbers();

foreach (var n in numbers)
{
    Console.WriteLine(n);
}

var people = new []
{
    new YPerson("Tom"),
    new YPerson("JIm"),
    new YPerson("Mic")
};

var company = new YCompany(people);

foreach (var person in company.GetEnumerator(1))
{
    Console.WriteLine(person.Name);
}