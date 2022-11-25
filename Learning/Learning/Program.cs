using System.Text.Json;
using System.Threading.Channels;
using Learning;

var person = new PersonJSON{Name = "tom",Age =22};
var path = "user.json";

var persons = new List<PersonJSON>();
for (int i = 0; i < 10; i++)
{
    var pers = new PersonJSON(Guid.NewGuid().ToString().Substring(0, 4), i);
    persons.Add(pers);
}

using(var fs = new FileStream(path,FileMode.Create))
{
    await JsonSerializer.SerializeAsync(fs, persons);
}

// var json = JsonSerializer.Serialize(person);
// Console.WriteLine(json);
//
// var deserializedPerson = JsonSerializer.Deserialize<PersonJSON>(json);
// Console.WriteLine(deserializedPerson.Name);

// using(var fs = new FileStream("user.json",FileMode.Append))
// { 
//     JsonSerializer.Serialize(fs, person);
//     Console.WriteLine("Данные сохранены");
// }

using(var fs = new FileStream("user.json",FileMode.Open))
{
    var des = await JsonSerializer.DeserializeAsync<List<PersonJSON>>(fs);
    foreach (var d in des)
    {
        Console.WriteLine($"{d.Name}  {d.Age}");
    }
}


