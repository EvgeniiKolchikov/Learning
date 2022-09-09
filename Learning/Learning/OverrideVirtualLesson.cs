namespace Learning;

public class OverrideVirtualLesson
{
    public class Person
    {
        public string Name { get; set; }

        private int _age = 1;

        public virtual int Age
        {
            get => _age;
            set
            {
                if (value > 0 && value < 110) _age = value;
            }
        }

        public Person(string name)
        {
            Name = name;
        }

        public virtual void Print()
        {
            Console.WriteLine(Name);
        }
    }

    public class Employee : OverrideVirtualLesson.Person
    {
        public string Company { get; set; }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 17 && value < 65)
                {
                    base.Age = value;
                }
            }
        }

        public Employee(string name, string company) : base(name)
        {
            Company = company;
            base.Age = 18;
        }

        public override void Print()
        {
            Console.WriteLine($"{Name} работает в {Company}");
        }

    }



    public class HidingLesson
    {
        public class Person
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }

            public void Print()
            {
                Console.WriteLine(Name);
            }
        }

        public class Employee : HidingLesson.Person
        {
            public string Company { get; set; }

            public Employee(string name, string company) : base(name)
            {
                Company = company;

            }

            public new void Print()
            {
                Console.WriteLine($"{Name} работает в {Company}");
            }
        }
    }



    /*public abstract class Shape
    {
        public virtual void GetPerimeter()
        {
            Console.WriteLine("Perimeter");
        }

        public virtual void GetArea()
        {
            Console.WriteLine("Area");
        }
    }

    public class Square : Shape
    {
        private int Side { get; set; }

        public Square(int side)
        {
            Side = side;
        }

        public override void GetPerimeter()
        {
            Console.WriteLine($"Периметр равен  {Side * 4}");
        }

        public override void GetArea()
        {
            base.GetArea();
            Console.WriteLine($"Площадь равна {Side * Side}");
        }

    }*/

}
