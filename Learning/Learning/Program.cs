using System.Text.Json.Nodes;
using Learning;



var storage = new Storage<string>();


storage.AddNewElement("53");
storage.AddNewElement("wefw");
storage.AddNewElement("2dasd");
storage.AddNewElement("asdakk");
storage.AddNewElement("qwerty");
storage.AddNewElement("32");
storage.AddNewElement("9");
storage.AddNewElement("sdfskmmv");
storage.AddNewElement("cvxbf");


var a =storage.GetArray();
var b = storage.ElementFromIndex(2);
var c =storage.IndexFromElement("qwerty");
var d = storage.PartOfArray(1, 5);
storage.DeleteElement(3);
var e = storage.GetArray();
storage.AddNewElement("f");
var f = storage.GetArray();
Console.Read();



