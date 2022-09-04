using System.Text.Json.Nodes;
using Learning;

//Восходящие преобразования. Upcasting. Базовому классу приводим класс наследника
Employee employee = new Employee("Tom","Microsoft");
Person person = employee; //Ссылка на один объект в куче, только person доступен его функционал.

Person bob = new Client("Bob", "SberBank");// Также восходящее преобразование. bob доступен только функционал класса Person

object person1 = new Person("Person1");//у person1 функционал только класса Object.
object person2 = new Employee("Person2", "Google");// person2 не имеет полей и методов класса Employee

//Нисходящие преобразования. Downcasting. 

Employee employee1 = new Employee("Greg", "HP");
Person person3 = employee1; // Upcasting 
Employee employee2 = (Employee)person3; // явно привели person к employee. 

object obj = new Employee("Hary", "Apple");
((Person)obj).Print();
((Employee)obj).Print();
var company = ((Employee)obj).Company;

object obj1 = new Employee("Tim", "Kkk");
//var bank = ((Client)obj1).Bank; // ошибка выполнения. Нельзя привести тип Client к Employee. Так как они не наследуются друг от друга

//Employee employee3 = new Person("Nil"); // ошибка мы пытаемся преобразовать объект типа Person к типу Employee.а объект Person не является объектом Employee

Person person4 = new Person("Max");
//Employee employee3 = (Employee)person4; 
Employee? employee3 = person4 as Employee;
if(employee3 == null) Console.WriteLine("неудачно");
else Console.WriteLine(employee3.Company);

if (person4 is Employee employee5)
{
    Console.WriteLine(employee5.Company);
}
else Console.WriteLine("преобразование недопустимо");