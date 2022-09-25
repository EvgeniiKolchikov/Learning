namespace Learning;

public class DictionaryLesson
{
    public void Run()
    {
        Dictionary<int, string> dict = new Dictionary<int, string>(); // инициализация словаря

        //инициализация сразу значениями
        var people = new Dictionary<int, string>()
        {
            {3,"Tom"},
            {5,"Kimi"},
            {65,"Rex"}
        };
        //другой способ инициализации
        var people1 = new Dictionary<int, string>()
        {
            [4] = "Tom",
            [87] = "Jux",
            [1] = "Qty"
        };


        var mike = new KeyValuePair<int, string>(43,"Sctr");
        var empl = new List<KeyValuePair<int, string>>(){mike};
        var peeoplDict = new Dictionary<int, string>(empl);
        var peoplDict = new Dictionary<int, string>(empl)
        {
            [3] = "Tre",
            [54] = "Utr",
            [55] = "Greg"
        };
        
        //перебор значений
        foreach (var p in peoplDict)
        {
            Console.WriteLine($"{p.Key} : {p.Value} ");
        }
        
        //получить значение по ключу
        var greg = peoplDict[55];
        //переустановка значения по ключу
        peeoplDict[54] = "Tom";
        //Добавляем элемент с ключом, если ключ есть в dictionary то значение переписывается, если нет, то создается новый ключ и значение
        peeoplDict[22] = "Eugene"; // создался ключ 22 со значением Eugene
        
        //Методы Dictionary
        
        // void Add(K key, V value): добавляет новый элемент в словарь
        // void Clear(): очищает словарь
        // bool ContainsKey(K key): проверяет наличие элемента с определенным ключом и возвращает true при его наличии в словаре
        // bool ContainsValue(V value): проверяет наличие элемента с определенным значением и возвращает true при его наличии в словаре
        // bool Remove(K key): удаляет по ключу элемент из словаря
        // Другая версия этого метода позволяет получить удленный элемент в выходной параметр: bool Remove(K key, out V value)
        // bool TryGetValue(K key, out V value): получает из словаря элемент по ключу key. При успешном получении передает значение элемента в выходной параметр value и возвращает true
        // bool TryAdd(K key, V value): добавляет в словарь элемент с ключом key и значением value. При успешном добавлении возвращает true

        
        //условная телефонная книга
        var phoneBook = new Dictionary<string, string>();
        
        // добавляем элемент: ключ - номер телефона, значение - имя абонента
        phoneBook.Add("+79811111111", "Frank");
        // альтернативное добавление
        // phoneBook["+123456"] = "Tom";

        var phoneExist1 = phoneBook.ContainsKey("+79811111111"); //true
        Console.WriteLine($"+79811111111: {phoneExist1}");

        var phoneExist2 = phoneBook.ContainsKey("+7222222"); // false
        Console.WriteLine($"+7222222: {phoneExist2}");

        var abonentExist1 = phoneBook.ContainsValue("Frank"); // true
        Console.WriteLine($"Frank: {abonentExist1}");

        var abonentExist2 = phoneBook.ContainsValue("Greg"); // false
        Console.WriteLine($"Greg: {abonentExist2}");
        
        //Удаление элемента
        phoneBook.Remove("+79811111111");
        
        //Количество элементов в словаре
        Console.WriteLine(phoneBook.Count);

        Dictionary<string, string>.KeyCollection keys = phoneBook.Keys;

        foreach (var key in keys)
        {
            Console.WriteLine(key);
        }

        var values = phoneBook.Values;
        foreach (var value in values)
        {
            Console.WriteLine(value);
        }

    }
}