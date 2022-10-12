using Learning.HomeWorks;


//HashTableHomeWork

var hashTable = new HashTableHomeWork<Something>(1000);

hashTable.AddNewElement(new Something("Greg",54));
hashTable.AddNewElement(new Something("Hot",100));
hashTable.AddNewElement(new Something("Cold", -40));

hashTable.FindFirst(new Something("Hot",100));
hashTable.FindFirst(new Something("g",3));
hashTable.FindFirst(new Something("Cold", -40));

var indexFromTable = hashTable.IndexFromElement(new Something("Greg", 54));
Console.WriteLine(indexFromTable);

var elemensFromIndex = hashTable.ElementsFromIndex(93);

Console.WriteLine();
