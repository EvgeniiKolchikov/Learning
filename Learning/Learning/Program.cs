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

var tst = new Tst();
(tst as IFoo).Execute();
(tst as IBar).Execute();





