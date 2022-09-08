using System.Text.Json.Nodes;
using Learning;

OverrideVirtualLesson.HidingLesson.Person person = new OverrideVirtualLesson.HidingLesson.Person("Tom");
person.Print();

OverrideVirtualLesson.HidingLesson.Person employee = new OverrideVirtualLesson.HidingLesson.Employee("Ken", "Microsoft");
employee.Print();

OverrideVirtualLesson.Person p = new OverrideVirtualLesson.Employee("Hi","YU");
p.Print();

Console.Read();