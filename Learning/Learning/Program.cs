using Learning;

var arrayClass = new Dz();

arrayClass.AddNewElement(12);
arrayClass.AddNewElement(83);
arrayClass.AddNewElement(2);
arrayClass.AddNewElement(33);
arrayClass.AddNewElement(8);
arrayClass.AddNewElement(25);
arrayClass.AddNewElement(666);
arrayClass.AddNewElement(76);
arrayClass.AddNewElement(56);

var intArray = arrayClass.GetArray();

var elementFromIndex = arrayClass.ElementFromIndex(3);

var indexFromElement = arrayClass.IndexFromElement(56);

var betwIndex = arrayClass.PartOfArray(0, 8);

Console.Read();