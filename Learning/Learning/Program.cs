using System.Text.Json.Nodes;
using Learning;

// var tom = new GPerson<int>(1,"Tom");
// var gary = new GPerson<string>("2", "Gary");
//
// var company = new Company<GPerson<int>>(tom);
// Console.WriteLine(company.CEO.Id);
// Console.WriteLine(company.CEO.Name);

/*GPerson<int>.code = 32;
var tom = new GPerson<int>(32, "Tomas");

var bob = new GPerson<string>("iddi", "Bob");
GPerson<string>.code = "jjj";
Console.WriteLine(GPerson<int>.code + " " + GPerson<string>.code);

int x = 43;
int y = 56;

string s1 = "Pistolet";
string s2 = "Mech";

void Swap<T>(ref T x, ref T y)
{
    T temp = x;
    x = y;
    y = temp;
}
Swap(ref x,ref y);
Swap(ref s1,ref s2);

Console.WriteLine(x + "\t" + y);
Console.WriteLine(s1 + "\t" + s2);*/

var messenger = new Messenger<Message, Person1>();
var tom = new Person1("Tom");
var bob = new Person1("Bob");
var message = new Message("Hi Friend!");

messenger.SendMessage(tom,bob,message);


void SendMessage<T>(T message) where T : Message
{
    Console.WriteLine($"Отправляется сообщение: {message.Text}");
}
Console.Read();