using Learning;
using MyLibrary;

int Recursion(int a, int b)
{
    if (a < 0 || b < 0)  throw new Exception("а и b должны быть больше нуля");
    if (a == 0)  return b;
    if (b == 0) return a;

    return Recursion(a + 1, b - 1);
}

Console.WriteLine(Recursion(87,5).ToString());

