using Learning;

var storage = new Storage<int>();
storage.AddNewElement(122);
storage.AddNewElement(23);

foreach (var i in storage)
{
    Console.WriteLine(i);
}

var stStor = new Storage<string>();
stStor.AddNewElement("dsffsdf");
stStor.AddNewElement("dwifn");
stStor.AddNewElement("wfwf");

foreach (var element in stStor)
{
    Console.WriteLine(element);
}
