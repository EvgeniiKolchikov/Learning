using System.Threading.Channels;
using Learning;
{
var value = LogicalOperations.IfElseMethod("0");

var value2 = LogicalOperations.LogicalMethod("5");

var value3 = LogicalOperations.ParseMethod("False");


if (value3 == true)
{
    Console.WriteLine("true");
}
else if (value3 == false)
{
    Console.WriteLine("false");
}
else Console.WriteLine("null");


}