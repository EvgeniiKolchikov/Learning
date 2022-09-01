using Learning;
using MyLibrary;

var count = 0;
int Recursion(int a, int b)
{
    if (a < 0 || b < 0)  throw new Exception("а и b должны быть больше нуля");
    if (a == 0)  return b + count;
    if (b == 0) return a + count;
    count++;
    return Recursion(a - 1, b - 1);
}
Console.WriteLine(Recursion(8,5).ToString());

