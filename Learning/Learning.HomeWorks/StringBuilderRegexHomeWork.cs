using System.Text;
using System.Text.RegularExpressions;

namespace Learning.HomeWorks;

public class StringBuilderRegexHomeWork
{
    public static Regex RegexInit(string input)
    {
        if (input.Length == 0)
        {
            throw new ArgumentNullException(null,"Пусто, Введите значение поиска");
        }
        
        var sb = new StringBuilder();
        for (var i = 0; i < input.Length; i++)
        {
            if (Char.IsLetterOrDigit(input[i]))
            {
                sb.Append(input[i]);
                continue;
            }
            if (input[i] == '*')
            {
                sb.Append(@"\w");
                continue;
            }
            throw new ArgumentException("Некорректный формат поиска");
        }
        return new Regex(@"^" + sb + @"\w*" , RegexOptions.IgnoreCase);
    }

    public static IEnumerable<string> GetMatches(Regex regex, string[] archive)
    {
        for (var i = 0; i < archive.Length; i++)
        {
            if (Regex.IsMatch(archive[i],regex.ToString(),RegexOptions.IgnoreCase))
            {
                yield return archive[i];
            }
        }
    }

    public static void ShowMatches(IEnumerable<string> collection)
    {
        if (collection.Count() > 0)
        {
            foreach (var match in collection)
            {
                Console.WriteLine(match);
            }
        }
        else
        {
            Console.WriteLine("Совпадений не найдено");
        }
    }
    


}