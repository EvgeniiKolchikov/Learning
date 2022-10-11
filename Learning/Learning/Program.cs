using System.Collections;
using Learning;

var hasTable = new HashTableLesson<int>(10);

// hasTable.Add(123);
// hasTable.Add(321);
// hasTable.Add(222);
// hasTable.Add(1213);
// hasTable.Add(13);
// hasTable.Add(1);
// hasTable.Add(9);
// hasTable.Add(908);
//
// Console.WriteLine(hasTable.Search(123));
// Console.WriteLine(hasTable.Search(54));
// Console.WriteLine(hasTable.Search(908));
//
// Console.ReadLine();


var personHashTable = new HashTableLesson<PersonHash>(10);

var maria = new PersonHash("Maria", 23);
personHashTable.Add(maria);

personHashTable.Add(new PersonHash("Виктор",65));
personHashTable.Add(new PersonHash("Сергей",34));
personHashTable.Add(new PersonHash("Алексей",32));
personHashTable.Add(new PersonHash("Максим",54));
personHashTable.Add(new PersonHash("Василий",42));

Console.WriteLine(personHashTable.Search(maria));
Console.WriteLine(personHashTable.Search(new PersonHash("Виктор",5)));
Console.WriteLine(personHashTable.Search(new PersonHash("Василий",42)));

//Console.WriteLine(personHashTable.Search(new PersonHash("Максим",54)));

Console.ReadLine();


