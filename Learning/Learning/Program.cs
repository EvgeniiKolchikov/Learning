using Learning;

var storage = new ExceptionHomeWork<int>();
storage.AddNewElement(34);

try
{
    storage.DeleteElement(3);
}
catch (MyException e)
{
    Console.WriteLine(e.Message);
}

try
{
    storage.PartOfArray(1, 4);
}
catch (MyException e)
{
    Console.WriteLine(e.Message);
}


