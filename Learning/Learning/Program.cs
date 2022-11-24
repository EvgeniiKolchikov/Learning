using System.Text.Json;
using System.Threading.Channels;
using Learning;

var person = new PersonJSON("Tom", 33);

var json = JsonSerializer.Serialize(person);
Console.WriteLine(json);

var deserializedPerson = JsonSerializer.Deserialize<PersonJSON>(json);
Console.WriteLine(deserializedPerson.Name);

using(var fs = new FileStream("user.json",FileMode.Append))
{
    await JsonSerializer.SerializeAsync(fs, person);
    Console.WriteLine("Данные сохранены");
}

using (var fs = new FileStream("user.json", FileMode.OpenOrCreate))
{
    
}
