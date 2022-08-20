using System.Threading.Channels;
using Learning;

var arrayClass = new Dz();

arrayClass.AddNewElement(12);
arrayClass.AddNewElement(12);
arrayClass.AddNewElement(11);
arrayClass.AddNewElement(11);
arrayClass.AddNewElement(11);
arrayClass.AddNewElement(11);
arrayClass.AddNewElement(11);
arrayClass.AddNewElement(11);
arrayClass.AddNewElement(1);

var intArray = arrayClass.GetArray();

var elementFromIndex = arrayClass.ElementFromIndex(2);

var indexFromElement = arrayClass.IndexFromElement(123);

var betwIndex = arrayClass.PartOfArray(0, 2);

Console.Read();