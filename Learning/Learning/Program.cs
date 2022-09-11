using System.Text.Json.Nodes;
using Learning;



var storage = new Storage<int>();

storage.AddNewElement(53);
storage.AddNewElement(5377777);
storage.AddNewElement(333);

var a =storage.GetArray();

Console.Read();



