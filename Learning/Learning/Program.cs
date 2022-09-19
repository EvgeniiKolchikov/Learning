using Learning;


//var runner = new Runner();

// Console.WriteLine(IMovable.MIN_SPEED);
// IMovable.MaxSpeed = 100;
// Console.WriteLine(IMovable.MaxSpeed);
// var time = IMovable.GetTime(32, 4);
// Console.WriteLine(time);


// var bike = new Bike();
// var car = new Car();
// DoSomething(bike);
// DoSomething(car);
//
// void DoSomething(IMovabl movable) => movable.Move();
//
// var message = new Message("Nomonoyturyk");
// message.Print();


// IMessage mes = new Message("message");
//
// if(mes is Message myMes) myMes.Print();
//
// IPrint print = new Message("Printing");
// if (print is Message pr) Console.WriteLine(pr.Text);
//
// var m = new Message("d");
//
// Show(m,m);
//
// void Show(IMessage ms,IPrint pr)
// {
//     if (pr is not Message pr1) return;
//     pr1.Text = ms.Text;
//     Console.WriteLine(ms.Text + pr1.Text);
//
// }


// var per = new StudyPerson();
// ((IScool)per).Study();
// (per as IUniversity).Study();

// var tst = new TestPers();
// tst.Execute();


// BaseAction heroAction = new HeroAction();
// heroAction.Move();
//
// IAction action = new HeroAction();
// action.Move();
//
// HeroAction heroAction2 = new HeroAction();
// heroAction2.Move();


// var message1 = new Message1("Интерфейсы в обощениях");
// var messenger1 = new Messenger<Message1>();
// messenger1.Send(message1);
//
// var message2 = new PrintableMessage("Printable Message");
// var messenger2 = new Messenger<IPrintableMessage>();
// messenger2.Send(message2);


// var userInt = new User<int>(12);
// Console.WriteLine(userInt.Id);
//
// var userString = new User<string>("fer");
// Console.WriteLine(userString.Id);
//
// var intUser = new IntUser(3);
// Console.WriteLine(intUser.Id);


// var tom = new PPerson("tom", 28, new CCompany("Microsoft"));
// var bob = tom;
//
// var gir = (PPerson)tom.Clone();
// gir.Name = "gir";
// gir.Company.Name = "Google";
// Console.WriteLine(tom.Company.Name);


var tom = new ComparablePerson("tom holland",6);
var bob = new ComparablePerson("maxi",32);
var sam = new ComparablePerson("amand",90);

ComparablePerson[] people = {tom,bob,sam};
Array.Sort(people);
foreach (var per in people)
{
    Console.WriteLine($"{per.Name} - {per.Age}");
}

Array.Sort(people, new Comparator());
foreach (var per in people)
{
    Console.WriteLine($"{per.Name} - {per.Age}");
}