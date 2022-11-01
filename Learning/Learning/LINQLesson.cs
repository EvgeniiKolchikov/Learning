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
}




record Course(string Title);
record Student(string Name);

record CompanyL(string Name, List<PersonL> Staff);
record PersonL(string Name, int Age);