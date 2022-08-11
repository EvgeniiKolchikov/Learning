

namespace Learning
{
    public class HelloWorld
    {
        public void Run()
        {
            Console.WriteLine("Insert your name");
            var name = Console.ReadLine();
            if (name != null && name.All(char.IsLetter))
            {
                Console.WriteLine($"Hello, {name}");
            }
            else Console.WriteLine("Incorrect input");
        }
    }
}

