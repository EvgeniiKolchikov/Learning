namespace Learning;

public class LINQLesson
{
    string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

    public void Linq1()
    {
        var selectedPeople = from p in people
            where p.ToUpper().StartsWith("T")
            orderby p
            select p;

        foreach (var s in selectedPeople)
        {
            Console.WriteLine(s);
        }
    }

    public void Linq2()
    {
        var orderedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
        foreach (var people in orderedPeople)
        {
            Console.WriteLine(people);
        }
    }

    public void Linq3()
    {
        var number = (from p in people where p.ToUpper().StartsWith("T") select p).Count();
        Console.WriteLine(number);
    }

    public void Linq4()
    {
        var people = new List<PersonL>()
        {
            new PersonL("Bob", 12),
            new PersonL("Tom", 22),
            new PersonL("Hor", 32),
            new PersonL("GGG", 1)
        };

        var names = from p in people select p.Name;

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public void Linq5()
    {
        var people = new List<PersonL>()
        {
            new PersonL("Bob", 12),
            new PersonL("Tom", 22),
            new PersonL("Hor", 32),
            new PersonL("GGG", 1)
        };

        var personel = from p in people
            select new
            {
                FirstName = p.Name,
                Year = DateTime.Now.Year - p.Age
            };

        var personnel1 = people.Select(p => new
        {
            FirstName = p.Name,
            Year = DateTime.Now.Year - p.Age
        });

        foreach (var pers in personnel1)
        {
            Console.WriteLine($"{pers.FirstName} - {pers.Year}");
        }

    }

    public void Linq6()
    {
        var people = new List<PersonL>()
        {
            new PersonL("Bob", 12),
            new PersonL("Tom", 22),
            new PersonL("Hor", 32),
            new PersonL("GGG", 1)
        };

        var personnel = from p in people
            let name = $"Mr.{p.Name}"
            let year = DateTime.Now.Year - p.Age
            select new
            {
                Name = name,
                Year = year
            };
        
        foreach (var p in personnel)
            Console.WriteLine($"{p.Name} - {p.Year}");

    }

    public void Linq7()
    {
        var courses = new List<Course> { new Course("C#"), new Course("Java") };
        var sudents = new List<Student> { new Student("Bob"), new Student("John") };

        var enrollments = from cource in courses
            from student in sudents
            select new  {Student = student.Name, Cource = cource.Title} ;

        foreach (var enrollment in enrollments)
        {
            Console.WriteLine(enrollment.Student + " " + enrollment.Cource);
        }
    }
    public void Linq8()
    {
        var companies = new List<CompanyL>
        {
            new CompanyL("Microsoft", new List<PersonL> { new PersonL("Bob", 18), new PersonL("Hary", 45) }),
            new CompanyL("Apple", new List<PersonL> { new PersonL("Tom", 18), new PersonL("Henry", 45) })
        };

        //var employees = companies.SelectMany(c => c.Staff);

        var employees = from company in companies
            from employee in company.Staff
            select employee;
        
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.Name);
        }
    }

    public void Linq9()
    {
        var companies = new List<CompanyL>
        {
            new CompanyL("Microsoft", new List<PersonL> { new PersonL("Bob", 18), new PersonL("Hary", 45) }),
            new CompanyL("Apple", new List<PersonL> { new PersonL("Tom", 18), new PersonL("Henry", 45) })
        };

       // var employees = companies.SelectMany(c => c.Staff,
        //    (c, emp) => new { Name = emp.Name, Company = c.Name });

        var employees = from company in companies
            from emp in company.Staff
            select new { Name = emp.Name, Company = company.Name };
        
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.Name + " " + employee.Company);
        }
    }

    public void Linq10()
    {
        string[] people = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };

        var selectedPeople = people.Where(p => p.Length == 3);

        var selectedPeople2 = from p in people
            where p.Length == 3
            select p;

        var selectedPeople3 = people.Where(p => p.Length % 2 == 0);

        foreach (var VARIABLE in selectedPeople3)
        {
            Console.WriteLine(VARIABLE);
        }
    }

    public void Linq11()
    {
        var rnd = new Random();
        var list = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            list.Add(rnd.Next(1,21));
        }

        var selected = list.Where(item => item % 2 == 0 && item > 10);
        var selected2 = from item in list
            where item % 2 == 0 && item > 10
            select item;

        foreach (var VARIABLE in selected2)
        {
            Console.WriteLine(VARIABLE);
        }
    }

    public void Linq12()
    {
        var people = new List<PersonL1>
        {
            new PersonL1 ("Tom", 23, new List<string> {"english", "german"}),
            new PersonL1 ("Bob", 27, new List<string> {"english", "french" }),
            new PersonL1 ("Sam", 29, new List<string>  { "english", "spanish" }),
            new PersonL1 ("Alice", 24, new List<string> {"spanish", "german" })
        };

        var selected = people.Where(p => p.Age > 25);

        var selectedPeople2 = from p in people
            from l in p.lang
            where l == "english"
            select p;
        
        foreach (var VARIABLE in selectedPeople2)
        {
            Console.WriteLine(VARIABLE.Name);
        }

    }

    public void Linq13()
    {
        var people= new List<PersonL2>
        {
            new StudentL("Tom"),
            new PersonL2("Sam"),
            new StudentL("Bob"),
            new EmployeeL("Mike")
        };

        var selected = people.OfType<StudentL>();

        foreach (var VARIABLE in selected)
        {
            Console.WriteLine(VARIABLE.Name);
        }
    }

    public void Linq14()
    {
        var n = new []{ 3, 5, 12, 33 };

        var sc = new[] { "Tom", "Bob", "Sam" };
        
        var people = new List<PersonL>
        {
            new PersonL("Tom", 37),
            new PersonL("Sam", 28),
            new PersonL("Tom", 22),
            new PersonL("Bob", 41),
        };

        var orderBy = n.OrderBy(i => i);
        
        var orderBy1 = from i in n
            orderby i
            select i;

        var orderBy2 = sc.OrderBy(s => s);

        var peopleOrdBy = from p in people
            orderby p.Name
            select p;
        
        foreach (var VARIABLE in peopleOrdBy)
        {
            Console.WriteLine(VARIABLE.Name);
        }
    }

    public void Linq15()
    {
        int[] numbers = { 3, 12, 4, 10 };
        var people = new List<PersonL>
        {
            new PersonL("Tom", 37),
            new PersonL("Sam", 28),
            new PersonL("Tom", 22),
            new PersonL("Bob", 41),
        };
        
        var descNum = from n in numbers
            orderby n descending 
            select n;

        var descNum2 = numbers.OrderByDescending(n => n);

        var peopleDesc = from person in people
            orderby person.Name descending, person.Age
            select person;

        var peopleDesc2 = people.OrderBy(p => p.Name).ThenByDescending(a => a.Age);

        foreach (var VARIABLE in peopleDesc2)
        {
            Console.WriteLine(VARIABLE.Name + " - " + VARIABLE.Age);
        }
    }

    public void Linq16()
    {
        string[] soft = { "Microsoft", "Google", "Apple", "Microsoft", "Google"};
        string[] hard = { "Apple", "IBM", "Samsung"};

        var result = soft.Except(hard);

        var intersected = soft.Intersect(hard);

        var distincted = soft.Distinct();

        var unionRes = soft.Union(hard);

        foreach (var VARIABLE in unionRes)
        {
            Console.WriteLine(VARIABLE);
        }
    }

    public void Linq17()
    {
        Person2[] people =
        {
            new Person2("Tom", "Microsoft"), new Person2("Sam", "Google"),
            new Person2("Bob", "JetBrains"), new Person2("Mike", "Microsoft"),
            new Person2("Kate", "JetBrains"), new Person2("Alice", "Microsoft")
        };

        var companies = from person in people
            group person by person.Company;

        foreach (var company in companies)
        {
            Console.WriteLine(company.Key);

            foreach (var person in company)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine();
        }
    }
}



record Person2(string Name, string Company);
record class PersonL2(string Name);
record class StudentL(string Name): PersonL2(Name);
record class EmployeeL(string Name) : PersonL2(Name);

record Course(string Title);
record Student(string Name);

record CompanyL(string Name, List<PersonL> Staff);
record PersonL(string Name, int Age);

record PersonL1(string Name, int Age, List<string> lang);